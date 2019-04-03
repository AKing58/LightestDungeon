using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Entity
{
    //Initializes the Mage Entity
    public override void init(string name)
    {
        createEntity(name, 1, 10, 8, new int[] { 6, 8 }, 8, 10);
        ClassType = Vocation.Mage;
        Friendly = true;
    }
    /// <summary>
    /// Fireball
    /// Att: 0
    /// Dam: 2
    /// Target: Single
    /// Status: None
    /// </summary>
    /// <param name="target"></param>
    public override void move1(Entity target)
    {
        Move move = new Move("Fireball", rollDice(1, Attack), rollDice(1, target.Defence), rollDice(Damage[0], Damage[1]));
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
    /// Earthquake
    /// Att: 0
    /// Dam: 3
    /// Target: All
    /// Status: None
    /// </summary>
    /// <param name="target"></param>
    public override void move2(Entity target)
    {
        foreach (Entity e in GameObject.Find("DungeonManager").GetComponent<DungeonManager>().playerList)
        {
            Move move = new Move("Group Heal", rollDice(1, Attack), rollDice(1, e.Defence), rollDice(Damage[0], Damage[1]) - 3);
            e.Health += move.Dam;
        }
        Debug.Log("Earthquake!");
    }
    /// <summary>
    /// Chain Lightning
    /// ------If it damages an enemy, attempts attack on an adjacent enemy
    /// Att: 0
    /// Dam: -1
    /// Target: Single
    /// Status: None
    /// </summary>
    /// <param name="target"></param>
    public override void move3(Entity target)
    {
        Move move = new Move("Chain Lightning", rollDice(1, Attack), rollDice(1, target.Defence), rollDice(Damage[0], Damage[1] - 1));
        List<Entity> tempList = GameObject.Find("DungeonManager").GetComponent<BattleManager>().enemyList;
        int targetLocation = 0;
        for(int i=0; i < tempList.Count; i++)
        {
            if (tempList[i] = target)
                targetLocation = i;
        }
        
        if (move.Att > move.Def)
        {
            Debug.Log("Att: " + move.Att + " vs Def: " + move.Def);
            Debug.Log(Name + ": " + move.Name + " on " + target.Name + " for " + move.Dam);
            if(move.Att > move.Def)
            {
                target.StatusEffects["AttBuff"] -= 1;
                target.Health -= move.Dam;
                if (tempList.Count == 1)
                    return;
                if (rollDice(0, 1) == 1)
                {
                    if (targetLocation > tempList.Count - 1)
                        targetLocation -= 2;
                    else
                        targetLocation++;
                }
                else
                {
                    if (targetLocation > tempList.Count - 1)
                        targetLocation -= 2;
                    else
                        targetLocation--;
                }
                move3(tempList[targetLocation]);
            }
        }
        else
        {
            Debug.Log(move.Name + " on " + target.Name + " missed!");
        }
    }
    //Mage Move 4
    public override void move4(Entity target)
    {
        Debug.Log("Mage Move4 on " + target.Name);
    }
    //Mage Move 5
    public override void move5(Entity target)
    {
        Debug.Log("Mage Move5 on " + target.Name);
    }
}
