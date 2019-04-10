using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Entity
{
    //Initializes the Zombie Entity
    public override void init(string name)
    {
        createEntity(name, 1, 6, 6, new int[] { 1, 5 }, 6);
        ClassType = Vocation.Zombie;
        Friendly = false;
    }

    public override void move1(Entity target)
    {
        Move move = new Move("Swipe", rollDice(1, Attack), rollDice(1, target.Defence), rollDice(Damage[0], Damage[1]));
        Debug.Log("Att: " + move.Att + " vs Def: " + move.Def);
        if (move.Att > move.Def)
        {
            Debug.Log(Name + ": " + move.Name + " on " + target.Name + " for " + move.Dam);
            target.Health -= move.Dam;
        }
        else
        {
            Debug.Log(move.Name + " on " + target.Name + " missed!");
        }
    }
}
