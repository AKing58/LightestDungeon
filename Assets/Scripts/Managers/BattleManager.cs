using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class that controls the game logic for when battles are initiated in the game
/// </summary>
public class BattleManager : MonoBehaviour
{
    //Scoring
    private int orcDefeated;
    private int orcBlueDefeated;
    private int orcRedDefeated;
    private int skeletonDefeated;
    private int zombieDefeated;
    private int minotaurDefeated;

    public BattleManager instance;
    public List<Entity> enemyList;
    public DungeonManager thisDungeon;
    public List<Entity> turnOrder;
    public int turnNo;

    public int rollDice()
    {
        DungeonManager d = GameObject.Find("DungeonManager").GetComponent<DungeonManager>();
        return d.randSeed.Next(0, d.challengeRating / 4);
    }

    public string randomUnlockedEnemy()
    {
        string outEnemy = "Skeleton";
        switch (rollDice())
        {
            case 0:
                outEnemy = "Skeleton";
                break;
            case 1:
                outEnemy = "Zombie";
                break;
            case 2:
                outEnemy = "Orc";
                break;
            case 3:
                outEnemy = "BlueOrc";
                break;
            case 4:
                outEnemy = "RedOrc";
                break;
            case 5:
                outEnemy = "Minotaur";
                break;
        }
        return outEnemy;
    }

    /// <summary>
    /// Method to start the battle sequence
    /// Loads the enemy prefabs and game objects
    /// </summary>
    public void initBattle(int cr)
    {
        thisDungeon = GameObject.Find("DungeonManager").GetComponent<DungeonManager>();
        turnNo = 0;
        enemyList = new List<Entity>();
        GameObject enemyPreFab;
        GameObject enemyObject;
        GameObject parent = GameObject.Find("Enemies");
        Entity thisEnemy;
        
        for(int i=0; i<4; i++)
        {
            string enemyType = randomUnlockedEnemy();
            enemyPreFab = Resources.Load("Prefabs/" + enemyType) as GameObject;
            enemyObject = Instantiate(enemyPreFab, parent.transform.position + new Vector3(thisDungeon.position[enemyList.Count], 0, 1.5f), Quaternion.identity);
            enemyObject.transform.parent = parent.transform;
            parseClassName(enemyObject, enemyType, enemyType + "man");
            thisEnemy = enemyObject.GetComponent<Entity>();
            GameObject.Find("UI/RightPanel/EnemyInfo/EnemyInfoPanel" + (i+1)).GetComponent<EnemyInfoPanelScript>().thisEntity = thisEnemy;
            enemyList.Add(thisEnemy);
        }

        orcDefeated = 0;
        orcBlueDefeated = 0;
        orcRedDefeated = 0;
        skeletonDefeated = 0;
        zombieDefeated = 0;
        minotaurDefeated = 0;

        initTurnOrder();
        for(int i=0; i<turnOrder.Count; i++)
        {
            Debug.Log(i + " " + turnOrder[i].Name + " " + turnOrder[i].ClassType);
        }
    }

    /// <summary>
    /// Adds enemy components dependant on the class name variable
    /// </summary>
    /// <param name="g"></param>
    /// <param name="className"></param>
    /// <param name="name"></param>
    public void parseClassName(GameObject g, string className, string name)
    {
        if (className == "Skeleton")
        {
            Skeleton o = g.AddComponent<Skeleton>() as Skeleton;
            o.init(name);
        }
        else if (className == "Zombie")
        {
            Zombie o = g.AddComponent<Zombie>() as Zombie;
            o.init(name);
        }
        else if (className == "Orc")
        {
            Orc o = g.AddComponent<Orc>() as Orc;
            o.init(name);
        }
        if (className == "BlueOrc")
        {
            BlueOrc o = g.AddComponent<BlueOrc>() as BlueOrc;
            o.init(name);
        }
        else if (className == "RedOrc")
        {
            RedOrc o = g.AddComponent<RedOrc>() as RedOrc;
            o.init(name);
        }
        else if (className == "Minotaur")
        {
            Minotaur o = g.AddComponent<Minotaur>() as Minotaur;
            o.init(name);
        }
        else
        {
            Orc o = g.AddComponent<Orc>() as Orc;
            o.init(name);
        }

    }

    /// <summary>
    /// Method that starts the turn order for players and enemies
    /// </summary>
    public void initTurnOrder()
    {
        turnOrder = new List<Entity>();
        for(int i=0; i<thisDungeon.playerList.Count; i++)
        {
            turnOrder.Add(thisDungeon.playerList[i]);
        }
        for (int i = 0; i < enemyList.Count; i++)
        {
            turnOrder.Add(enemyList[i]);
        }
        for(int i=0; i < turnOrder.Count; i++)
        {
            turnOrder[i].isTurn = false;
        }
    }

    /// <summary>
    /// Method that keeps track of the current turn during a battle
    /// </summary>
    public void currentTurn()
    {
        if (turnNo == 0)
            turnOrder[turnOrder.Count - 1].isTurn = false;
        else
            turnOrder[turnNo - 1].isTurn = false;
        turnOrder[turnNo].isTurn = true;
        turnOrder[turnNo].switchPosition();
        if (turnOrder[turnNo].Friendly)
        {
            Debug.Log(turnOrder[turnNo].Name + " Panel enable");
            turnOrder[turnNo].myPanel.transform.Find("SkillPanel").gameObject.SetActive(true);
        }
        else
        {
            DungeonManager d = GameObject.Find("DungeonManager").GetComponent<DungeonManager>();
            int newTarget = d.randSeed.Next(0, d.playerList.Count-1);
            turnOrder[turnNo].switchPosition();
            turnOrder[turnNo].move1(d.playerList[newTarget]);
            nextTurn();
        }
    }

    /// <summary>
    /// Method that causes the next turn to start
    /// </summary>
    public void nextTurn()
    {
        if (GameObject.Find("DungeonManager").GetComponent<DungeonManager>().playerList.Count == 0)
        {
            Debug.Log("You Lose");
            gameOver();
            return;
        }
        if(enemyList.Count == 0)
        {
            Debug.Log("You Win!");
            Debug.Log(skeletonDefeated + zombieDefeated + orcDefeated + orcBlueDefeated+ orcRedDefeated+ minotaurDefeated);
            thisDungeon.winScreen.battleWonScreen(skeletonDefeated, zombieDefeated, orcDefeated, orcBlueDefeated, orcRedDefeated, minotaurDefeated);

            gameOver();
            return;
        }
        
        turnNo++;
        if (turnNo > turnOrder.Count - 1)
        {
            turnNo = 0;
        }
        //Debug.Log(turnOrder[turnNo++].Name);

        if (turnOrder[turnNo].StatusEffects["Bleed"] > 0)
        {
            Debug.Log(turnOrder[turnNo].Name + " took " + (turnOrder[turnNo].StatusEffects["Bleed"] + 1) + " bleed damage.");
            if (turnOrder[turnNo].Health - turnOrder[turnNo].StatusEffects["Bleed"] <= 0)
            {
                turnOrder[turnNo].Health -= turnOrder[turnNo].StatusEffects["Bleed"]--;
                if (enemyList.Count == 0)
                {
                    Debug.Log("You Win!");
                    gameOver();
                    return;
                }
                if (turnNo > turnOrder.Count - 1)
                {
                    turnNo = 0;
                }
                currentTurn();
                return;
            }
            turnOrder[turnNo].Health -= turnOrder[turnNo].StatusEffects["Bleed"]--;
            if(turnOrder[turnNo].StatusEffects["Bleed"] <= 0)
                turnOrder[turnNo].transform.Find("StatusUI/Bleed").gameObject.SetActive(false);
        }
        

        if (turnOrder[turnNo].StatusEffects["Stun"] > 0)
        {
            Debug.Log(turnOrder[turnNo].Name + " missed a turn (Stun).");
            turnOrder[turnNo].StatusEffects["Stun"]--;

            if (turnOrder[turnNo].StatusEffects["Stun"] <= 0)
                turnOrder[turnNo].transform.Find("StatusUI/Stun").gameObject.SetActive(false);
            nextTurn();
        }
        else
        {
            currentTurn();
        }
        
    }

    IEnumerator waitToLoad()
    {
        yield return new WaitForSeconds(0.2f);
    }

    private void gameOver()
    {
        foreach (Entity e in enemyList)
            Destroy(e.gameObject);
        foreach (Entity e in thisDungeon.playerList)
        {
            e.myPanel.transform.Find("SkillPanel").gameObject.SetActive(false);
            e.refreshStatusEffects();
        }
        for(int i=1; i<=4; i++)
        {
            GameObject.Find("UI/RightPanel/EnemyInfo/EnemyInfoPanel" + i).GetComponent<EnemyInfoPanelScript>().resetPanel();
        }

        thisDungeon.orcDefeated += orcDefeated;
        thisDungeon.orcBlueDefeated += orcBlueDefeated;
        thisDungeon.orcRedDefeated += orcRedDefeated;
        thisDungeon.skeletonDefeated += skeletonDefeated;
        thisDungeon.zombieDefeated += zombieDefeated;
        thisDungeon.minotaurDefeated += minotaurDefeated;


        Destroy(this);
    }


    public int returnEnemyLocation(Entity target)
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            if (enemyList[i] == target)
                return i;
        }
        return -1;
    }

    public int returnPlayerLocation(Entity target)
    {
        List<Entity> pList = GameObject.Find("DungeonManager").GetComponent<DungeonManager>().playerList;
        for (int i = 0; i < pList.Count; i++)
        {
            if (pList[i] == target)
                return i;
        }
        return -1;
    }

    public void incrementDefeated(string input)
    {
        switch (input)
        {
            case "Skeleton":
                thisDungeon.challengeRating++;
                skeletonDefeated++;
                break;
            case "Zombie":
                thisDungeon.challengeRating += 2;
                zombieDefeated++;
                break;
            case "Orc":
                thisDungeon.challengeRating += 3;
                orcDefeated++;
                break;
            case "BlueOrc":
                thisDungeon.challengeRating += 4;
                orcBlueDefeated++;
                break;
            case "RedOrc":
                thisDungeon.challengeRating += 5;
                orcRedDefeated++;
                break;
            case "Minotaur":
                thisDungeon.challengeRating += 6;
                minotaurDefeated++;
                break;
        }
    }
}
