using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Entity
{
    //Initializes the Knight Entity
    public override void init(string name)
    {
        createEntity(name, 1, 10, 10, new int[] { 4, 8 }, 10, 8);
        ClassType = Vocation.Knight;
        Friendly = true;
    }

    /// <summary>
    /// Slash
    /// Att: 0
    /// Dam: 0
    /// Target: Single
    /// Status: None
    /// </summary>
    /// <param name="target"></param>
    public override void move1(Entity target)
    {
        Move move = new Move("Slash", rollDice(1, Attack),rollDice(1, target.Defence), rollDice(Damage[0], Damage[1]));
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
    /// Shoulder Bash
    /// -------50% Stun chance
    /// Att: 0
    /// Dam: -3
    /// Target: Single
    /// Status: Stun
    /// </summary>
    /// <param name="target"></param>
    public override void move2(Entity target)
    {
        string moveName = "Shoulder Bash";
        int tempDef = rollDice(1, target.Defence);
        int tempAtt = rollDice(1, Attack);
        int tempDam;
        Debug.Log("Att: " + tempAtt + " vs Def: " + tempDef);
        if (tempAtt > tempDef)
        {
            tempDam = rollDice(Damage[0], Damage[1]) - 3;
            Debug.Log(Name  + ": " + moveName + " on " + target.Name + " for " + tempDam);
            if(rollDice(0,1) == 1)
                target.StatusEffects["Stun"] += 1;
            target.Health -= tempDam;
        }
        else
        {
            Debug.Log(Name + ": " + moveName + " on " + target.Name + " missed!");
        }
        
    }
    /// <summary>
    /// Cleave --------------NEEDS IMPLEMENTATION-----
    /// Att: -1
    /// Dam: -2
    /// Target: Single
    /// Status: None
    /// </summary>
    /// <param name="target"></param>
    public override void move3(Entity target)
    {
        string moveName = "Cleave";
        int tempDef = rollDice(1, target.Defence);
        int tempAtt = rollDice(1, Attack) - 1;
        int tempDam;
        Debug.Log("Att: " + tempAtt + " vs Def: " + tempDef);
        if (tempAtt > tempDef)
        {
            tempDam = rollDice(Damage[0], Damage[1]) - 2;
            Debug.Log(Name + ": " + moveName + " on " + target.Name + " for " + tempDam);
            target.Health -= tempDam;
        }
        else
        {
            Debug.Log(Name + ": " + moveName + " on " + target.Name + " missed!");
        }
    }
    /// <summary>
    /// Bolster
    /// Att: NA
    /// Dam: NA
    /// Target: Single
    /// Status: DefBuff
    /// </summary>
    /// <param name="target"></param>
    public override void move4(Entity target)
    {
        string moveName = "Bolster";
        target.StatusEffects["DefBuff"] += 5;
        Debug.Log(moveName + " on " + target.Name);
    }

    /// <summary>
    /// 
    /// Att: NA
    /// Dam: NA
    /// Target: Single
    /// Status: None
    /// </summary>
    /// <param name="target"></param>
    public override void move5(Entity target)
    {
        Debug.Log("Knight Move5 on" + target.Name);
    }
}
