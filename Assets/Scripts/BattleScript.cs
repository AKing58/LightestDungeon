using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScript : MonoBehaviour
{
    public static List<Player> playerList;
    // Start is called before the first frame update
    void Start()
    {
        playerList.Add(new Player("Reynauld", "Knight", 15));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addPlayer(Player player)
    {
        playerList.Add(player);
    }
}
