using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class that controls the game logic for when battles are initiated in the game
/// </summary>
public class BattleManager : MonoBehaviour
{
    public BattleManager instance;
    public List<Entity> enemyList;
    public DungeonManager thisDungeon;
    public List<Entity> turnOrder;
    public int turnNo;
    
    /// <summary>
    /// Method to start the battle sequence
    /// Loads the enemy prefabs and game objects
    /// </summary>
    public void initBattle()
    {
        thisDungeon = GameObject.Find("DungeonManager").GetComponent<DungeonManager>();
        turnNo = 0;
        GameObject.Find("UI/RightPanel/Button").GetComponent<Button>().onClick.AddListener(thisDungeon.curBattle.currentTurn);
        enemyList = new List<Entity>();
        GameObject enemyPreFab;
        GameObject enemyObject;
        GameObject parent = GameObject.Find("Enemies");
        Entity thisEnemy;
        
        for(int i=0; i<4; i++)
        {
            enemyPreFab = Resources.Load("Prefabs/Orc") as GameObject;
            enemyObject = Instantiate(enemyPreFab, parent.transform.position + new Vector3(thisDungeon.position[enemyList.Count], 0, 0), Quaternion.identity);
            enemyObject.transform.parent = parent.transform;
            parseClassName(enemyObject, "Orc", "Orcman");
            thisEnemy = enemyObject.GetComponent<Entity>();
            enemyList.Add(thisEnemy);
        }
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
        if (className == "Orc")
        {
            Orc o = g.AddComponent<Orc>() as Orc;
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
        if (turnOrder[turnNo].Friendly)
        {
            turnOrder[turnNo].myPanel.transform.Find("SkillPanel").gameObject.SetActive(true);
        }
        else
        {
            DungeonManager d = GameObject.Find("DungeonManager").GetComponent<DungeonManager>();
            int newTarget = d.randSeed.Next(0, d.playerList.Count-1);
            turnOrder[turnNo].move1(d.playerList[newTarget]);
            nextTurn();
        }
    }

    /// <summary>
    /// Method that causes the next turn to start
    /// </summary>
    public void nextTurn()
    {
        if (turnOrder[turnNo].Friendly)
        {
            turnOrder[turnNo].myPanel.transform.Find("SkillPanel").gameObject.SetActive(false);
        }
        turnNo++;
        //Debug.Log(turnOrder[turnNo++].Name);

        if (turnNo > turnOrder.Count - 1)
        {
            turnNo = 0;
            foreach (Entity e in turnOrder)
                e.refreshStatusEffects();
        }

        if(turnOrder[turnNo].StatusEffects["Bleed"] > 0)
        {
            turnOrder[turnNo].Health -= turnOrder[turnNo].StatusEffects["Bleed"]--;
            Debug.Log(turnOrder[turnNo].Name + " took " + (turnOrder[turnNo].StatusEffects["Bleed"] + 1) + " bleed damage.");
        }

        if (turnOrder[turnNo].StatusEffects["Stun"] > 0)
        {
            turnOrder[turnNo].StatusEffects["Stun"]--;
            Debug.Log(turnOrder[turnNo].Name + " missed a turn (Stun).");
            nextTurn();
        }
        else
        {
            currentTurn();
        }
        
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
}
