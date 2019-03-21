using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance = null;
    public List<Entity> enemyList;
    public DungeonManager thisDungeon;
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
            thisEnemy = enemyObject.GetComponent<Entity>();
            thisEnemy.parseClassName("Orc", "Orc");
            enemyList.Add(thisEnemy);
        }

        for (int i = 1; i < enemyList.Count + 1; i++)
        {
            EnemyInfoPanel thing = GameObject.Find("UI/RightPanel/EnemyInfo/EnemyInfoPanel" + i).GetComponent<EnemyInfoPanel>();
            thing.thisBattle = this;
        }
    }
}
