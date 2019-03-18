using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    public static DungeonManager instance = null;
    public List<Entity> playerList;
    public BattleManager curBattle;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
            instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
