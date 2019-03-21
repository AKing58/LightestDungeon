using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public BattleManager instance;
    public List<Entity> enemyList;
    public DungeonManager thisDungeon;
    public List<Entity> turnOrder;
    public int turnNo;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
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

    public void currentTurn()
    {
        if (turnNo == 0)
            turnOrder[turnOrder.Count - 1].isTurn = false;
        else
            turnOrder[turnNo - 1].isTurn = false;
        turnOrder[turnNo].isTurn = true;
        Debug.Log(turnOrder[turnNo].Name);
    }
    public void nextTurn()
    {
        Debug.Log(turnOrder[turnNo++].Name);
        if (turnNo > turnOrder.Count - 1)
            turnNo = 0;
    }
}
