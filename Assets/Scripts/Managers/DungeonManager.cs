using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Dungeon manager class that will handle all the different aspects of the dungeon such as initiating battles and events
/// </summary>
public class DungeonManager : MonoBehaviour
{
    public int challengeRating;
    public int orcDefeated;
    public int orcBlueDefeated;
    public int orcRedDefeated;
    public int skeletonDefeated;
    public int zombieDefeated;
    public int minotaurDefeated;

    public float[] position = { -4.5F, -1.5F, 1.5F, 4.5F };
    public static DungeonManager instance = null;
    public List<Entity> playerList;
    public BattleManager curBattle;

    public BattleWinScreen winScreen;
    public BattleWinScreen loseScreen;

    public System.Random randSeed;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        randSeed = new System.Random();
    }

    /// <summary>
    /// Starts the battle through the battle manager class
    /// </summary>
    public void startBattle()
    {
        if(curBattle == null)
        {
            curBattle = gameObject.AddComponent<BattleManager>() as BattleManager;
            curBattle.initBattle(challengeRating);
            curBattle.currentTurn();
            Debug.Log("created");
        }
    }

    /// <summary>
    /// Starts the next turn of the current battle
    /// </summary>
    public void doNextTurn()
    {
        curBattle.currentTurn();
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
