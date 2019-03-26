using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{

    public float[] position = { -4.5F, -1.5F, 1.5F, 4.5F };
    public static DungeonManager instance = null;
    public List<Entity> playerList;
    public BattleManager curBattle;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startBattle()
    {
        if(curBattle == null)
        {
            curBattle = gameObject.AddComponent<BattleManager>() as BattleManager;
            curBattle.initBattle();
            Debug.Log("created");
        }
    }

    public void doNextTurn()
    {
        curBattle.currentTurn();
    }
}
