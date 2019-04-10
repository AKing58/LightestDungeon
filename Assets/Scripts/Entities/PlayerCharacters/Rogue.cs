using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogue : Entity
{
    public int bleedValue;
    //Initializes the Rogue Entity
    public override void init(string name)
    {
        createEntity(name, 1, 8, 12, new int[] { 2, 10 }, 8);
        ClassType = Vocation.Rogue;
        Friendly = true;
        bleedValue = 2;
        md1 = new MoveDesc("Shank", "Single", "0", "0", "None", "Damage a target, apply " + bleedValue + " bleed which damages at the start of their turn. Lowers by 1 at the start of their turn");
        md2 = new MoveDesc("Poison Weapon", "Self", "0", "0", "Buff", "Give self +5 damage");
        md3 = new MoveDesc("Mark", "Single", "0", "-4", "Debuff", "Deals a low amount of damage and lowers a target's defence by 5");
        md4 = new MoveDesc("Disarm", "Single", "0", "0", "Debuff", "Deals a low amount of damage and lowers a target's attack by 5");
        md5 = new MoveDesc("Dodge", "Self", "0", "0", "Buff", "Give self +100 defence");
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
            target.StatusEffects["Bleed"] += bleedValue;
            Debug.Log(target.Name + ": Bleed is now " + target.StatusEffects["Bleed"] + " per turn");
            target.Health -= move.Dam;
        }
        else
        {
            Debug.Log(Name + ": " + move.Name + " on " + target.Name + " missed!");
        }
        
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
        StatusEffects["DamBuff"] += 5;
        Debug.Log(moveName + " on " + Name + " Current Damage Buff: " + StatusEffects["DamBuff"]);
    }

    /// <summary>
    /// Mark
    /// -------Applies a defence debuff for the next attack against a target of your choice
    /// -------Any damage from will reset this debuff
    /// Att: 0
    /// Dam: -4
    /// Target: Single
    /// Status: DefBuff (negative)
    /// </summary>
    /// <param name="target"></param>
    public override void move3(Entity target)
    {
        Move move = new Move("Mark", rollDice(1, Attack), rollDice(1, target.Defence), rollDice(Damage[0], Damage[1]) - 4);
        Debug.Log("Att: " + move.Att + " vs Def: " + move.Def);
        if (move.Att > move.Def)
        {
            Debug.Log(Name + ": " + move.Name + " on " + target.Name + " for " + move.Dam);
            target.StatusEffects["DefBuff"] -= 5;
            target.Health -= move.Dam;
        }
        else
        {
            Debug.Log(move.Name + " on " + target.Name + " missed!");
        }
        Debug.Log(target.Name + " has been Marked by " + Name + " Current Defence Debuff: " + target.StatusEffects["DefBuff"]);
    }

    /// <summary>
    /// Disarm
    /// -------Applies an attack debuff for the next against a target of your choice
    /// Att: +1
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
            target.StatusEffects["AttBuff"] -= 5;
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
        StatusEffects["DefBuff"] += 100;
        Debug.Log(moveName + " on " + Name);
    }
}
