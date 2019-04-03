using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleric : Entity
{
    //Initializes the Cleric Entity
    public override void init(string name)
    {
        createEntity(name, 1, 10, 8, new int[] { 1, 6 }, 14, 8);
        ClassType = Vocation.Cleric;
        Friendly = true;
    }

    /// <summary>
    /// Healing touch
    /// Att: NA
    /// Dam: +2
    /// Target: Single
    /// Status: None
    /// </summary>
    /// <param name="target"></param>
    public override void move1(Entity target)
    {
        Move move = new Move("Healing Touch", rollDice(1, Attack), 0, rollDice(Damage[0], Damage[1] + 2));
        target.Health += move.Dam;
        Debug.Log("Healing for " + move.Dam + " on " + target.Name);
    }
    /// <summary>
    /// Mind Blast
    /// ----High Damage, Low Chance to Hit
    /// Att: -2
    /// Dam: +5
    /// Target: Single
    /// Status: None
    /// </summary>
    /// <param name="target"></param>
    public override void move2(Entity target)
    {
        Move move = new Move("Mind Blast", rollDice(1, Attack - 2), rollDice(1, target.Defence), rollDice(Damage[0], Damage[1]));
        Debug.Log("Att: " + move.Att + " vs Def: " + move.Def);
        if (move.Att > move.Def)
        {
            move.Dam = rollDice(Damage[0], Damage[1]);
            Debug.Log(Name + ": " + move.Name + " on " + target.Name + " for " + move.Dam);
            target.Health -= move.Dam;
        }
        else
        {
            Debug.Log(move.Name + " on " + target.Name + " missed!");
        }
    }
    /// <summary>
    /// Group Heal
    /// Att: NA
    /// Dam: 0
    /// Target: Single
    /// Status: None
    /// </summary>
    /// <param name="target"></param>
    public override void move3(Entity target)
    {
        Move move = new Move("Group Heal", rollDice(1, Attack), 0, rollDice(Damage[0], Damage[1]));
        foreach(Entity e in GameObject.Find("DungeonManager").GetComponent<DungeonManager>().playerList)
        {
            e.Health += move.Dam;
        }
        Debug.Log("Healing for " + move.Dam + " on party");
    }

    /// <summary>
    /// Bash
    /// Att: 0
    /// Dam: 0
    /// Target: Single
    /// Status: None
    /// </summary>
    /// <param name="target"></param>
    public override void move4(Entity target)
    {
        Move move = new Move("Bash", rollDice(1, Attack), rollDice(1, target.Defence), rollDice(Damage[0], Damage[1]));
        Debug.Log("Att: " + move.Att + " vs Def: " + move.Def);
        if (move.Att > move.Def)
        {
            move.Dam = rollDice(Damage[0], Damage[1]);
            Debug.Log(Name + ": " + move.Name + " on " + target.Name + " for " + move.Dam);
            target.Health -= move.Dam;
        }
        else
        {
            Debug.Log(move.Name + " on " + target.Name + " missed!");
        }
    }
    /// <summary>
    /// 
    /// Att: 0
    /// Dam: 0
    /// Target: Single
    /// Status: None
    /// </summary>
    /// <param name="target"></param>
    public override void move5(Entity target)
    {
        Debug.Log("Cleric Move5 on " + target.Name);
    }
}
