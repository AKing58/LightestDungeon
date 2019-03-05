using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScript : MonoBehaviour
{
    public static BattleScript instance = null;
    public List<Entity> playerList;
    public List<Entity> enemyList;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        playerList.Add(new Knight("Reynauld", 1, 10, 10, 10));
        playerList.Add(new Rogue("Dismas", 1, 8, 14, 8));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addPlayer(Entity player)
    {
        playerList.Add(player);
    }
    public void addEntity(Entity enemy)
    {
        enemyList.Add(enemy);
    }
}
