using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogue : Entity
{
    //Initializes the Rogue Entity
    public override void init(string name)
    {
        createEntity(name, 1, 8, 12, new int[] { 2, 10 }, 8, 12);
        ClassType = Vocation.Rogue;
        Friendly = true;
    }
    /// <summary>
    /// Shank
    /// -------Bleeds for 2 on hit, can stack
    /// -------Max damage - 5
    /// Att: +1
    /// Dam: -5
    /// Target: Single
    /// Status: None
    /// </summary>
    /// <param name="target"></param>
    public override void move1(Entity target)
    {
        Move move = new Move("Shank", rollDice(1, Attack) + 1, rollDice(1, target.Defence), rollDice(Damage[0], Damage[1]) - 5);
        Debug.Log("Att: " + move.Att + " vs Def: " + move.Def);
        if (move.Att > move.Def)
        {
            Debug.Log(Name + ": " + move.Name + " on " + target.Name + " for " + move.Dam);
            target.StatusEffects["Bleed"] += 2;
            Debug.Log(target.Name + ": Bleed is now " + target.StatusEffects["Bleed"] + " per turn");
            target.Health -= move.Dam;
        }
        else
        {
            Debug.Log(Name + ": " + move.Name + " on " + target.Name + " missed!");
        }

        resetDefDebuff(target);
    }
    /// <summary>
    /// Poison Weapon
    /// -------Damage Buff on next attack
    /// Att: NA
    /// Dam: NA
    /// Target: Single
    /// Status: DamBuff
    /// </summary>
    /// <param name="target"></param>
    public override void move2(Entity target)
    {
        string moveName = "Poison Weapon";
        StatusEffects["DamBuffNext"] += 5;
        Debug.Log(moveName + " on " + Name + " Current Damage Buff: " + StatusEffects["DamBuffNext"]);
    }

    /// <summary>
    /// Mark
    /// -------Applies a defence debuff for the next attack against a target of your choice
    /// -------Any damage from will reset this debuff
    /// Att: 0
    /// Dam: -3
    /// Target: Single
    /// Status: DefBuff (negative)
    /// </summary>
    /// <param name="target"></param>
    public override void move3(Entity target)
    {
        Move move = new Move("Mark", rollDice(1, Attack), rollDice(1, target.Defence), rollDice(Damage[0], Damage[1]) - 3);
        Debug.Log("Att: " + move.Att + " vs Def: " + move.Def);
        if (move.Att > move.Def)
        {
            resetDefDebuff(target);
            Debug.Log(Name + ": " + move.Name + " on " + target.Name + " for " + move.Dam);
            target.StatusEffects["DefBuffNext"] -= 5;
            target.Health -= move.Dam;
        }
        else
        {
            resetDefDebuff(target);
            Debug.Log(move.Name + " on " + target.Name + " missed!");
        }
        Debug.Log(target.Name + " has been Marked by " + Name + " Current Defence Debuff: " + target.StatusEffects["DefBuffNext"]);
    }

    /// <summary>
    /// Disarm
    /// -------Applies an attack debuff for the next against a target of your choice
    /// Att: 0
    /// Dam: -3
    /// Target: Single
    /// Status: DefBuff (negative)
    /// </summary>
    /// <param name="target"></param>
    public override void move4(Entity target)
    {
        Move move = new Move("Disarm", rollDice(1, Attack) + 1, rollDice(1, target.Defence), rollDice(Damage[0], Damage[1]) - 5);
        Debug.Log("Att: " + move.Att + " vs Def: " + move.Def);
        if (move.Att > move.Def)
        {
            Debug.Log(Name + ": " + move.Name + " on " + target.Name + " for " + move.Dam);
            target.StatusEffects["AttBuff"] -= 3;
            target.Health -= move.Dam;
        }
        else
        {
            Debug.Log(Name + ": " + move.Name + " on " + target.Name + " missed!");
        }
    }

    /// <summary>
    /// Dodge
    /// -------Increases defence by an extremely high amount against the next attack
    /// Att: NA
    /// Dam: NA
    /// Target: Self
    /// Status: DefBuff
    /// </summary>
    /// <param name="target"></param>
    public override void move5(Entity target)
    {
        string moveName = "Dodge";
        StatusEffects["DefBuffNext"] += 100;
        Debug.Log(moveName + " on " + Name);
    }
    private void resetDefDebuff(Entity e)
    {
        e.StatusEffects["DefBuffNext"] = 0;
    }
}
