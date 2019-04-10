using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur : Entity
{
    //Initializes the Minotaur Entity
    public override void init(string name)
    {
        createEntity(name, 1, 12, 12, new int[] { 4, 12 }, 12);
        ClassType = Vocation.Minotaur;
        Friendly = false;
    }

    public override void move1(Entity target)
    {
        Move move = new Move("Crush", rollDice(1, Attack), rollDice(1, target.Defence), rollDice(Damage[0], Damage[1]));
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
