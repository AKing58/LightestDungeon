﻿using System.Collections;
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
        md1 = new MoveDesc("Slash", "Single", "0", "0", "None", "Damage a target");
        md2 = new MoveDesc("Shoulder Bash", "Single", "0", "-3", "Stun", "Lower damage, high chance to stun");
        md3 = new MoveDesc("Cleave", "Single/Multi", "-1", "-2", "None", "Target an enemy and its neighbors");
        md4 = new MoveDesc("Bolster", "Single", "0", "0", "Buff", "Give a target +5 defence");
        md5 = new MoveDesc("Tank up", "Single", "0", "0", "Buff", "Give a target temporary health based on your damage");
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
        Move move = new Move("Shoulder Bash", rollDice(1, Attack), rollDice(1, target.Defence), rollDice(Damage[0], Damage[1]) - 3);
        Debug.Log("Att: " + move.Att + " vs Def: " + move.Def);
        if (move.Att > move.Def)
        {
            Debug.Log(Name + ": " + move.Name + " on " + target.Name + " for " + move.Dam);
            if (rollDice(1,10) <= 7)
            {
                Debug.Log("Stunned!");
                target.StatusEffects["Stun"] += 1;
            }
            target.Health -= move.Dam;
        }
        else
        {
            Debug.Log(Name + ": " + move.Name + " on " + target.Name + " missed!");
        }
        
    }
    /// <summary>
    /// Cleave --------------NEEDS IMPLEMENTATION-----
    /// Att: -1
    /// Dam: -2
    /// Target: Group
    /// Status: None
    /// </summary>
    /// <param name="target"></param>
    public override void move3(Entity target)
    {
        Move move;
        BattleManager battleRef = GameObject.Find("DungeonManager").GetComponent<BattleManager>();
        List<Entity> tempList = battleRef.enemyList;


        if (battleRef.returnEnemyLocation(target) < tempList.Count - 1)
        {
            move = new Move("Cleave", rollDice(1, Attack) - 1, rollDice(1, tempList[battleRef.returnEnemyLocation(target) + 1].Defence), rollDice(Damage[0], Damage[1]) - 2);
            Debug.Log("Att: " + move.Att + " vs Def: " + move.Def);
            if (move.Att > move.Def)
            {
                Debug.Log(Name + ": " + move.Name + " on " + tempList[battleRef.returnEnemyLocation(target) + 1].Name + " for " + move.Dam + ". Place: " + (battleRef.returnEnemyLocation(target) + 1));
                tempList[battleRef.returnEnemyLocation(target) + 1].Health -= move.Dam;
            }
            else
            {
                Debug.Log(Name + ": " + move.Name + " on " + tempList[battleRef.returnEnemyLocation(target) + 1].Name + " missed! Place: " + (battleRef.returnEnemyLocation(target) + 1));
            }
        }

        move = new Move("Cleave", rollDice(1, Attack) - 1, rollDice(1, target.Defence), rollDice(Damage[0], Damage[1]) - 2);
        Debug.Log("Att: " + move.Att + " vs Def: " + move.Def);
        if (move.Att > move.Def)
        {
            Debug.Log(Name + ": " + move.Name + " on " + target.Name + " for " + move.Dam + ". Main");
            target.Health -= move.Dam;
        }
        else
        {
            Debug.Log(Name + ": " + move.Name + " on " + target.Name + " missed! Main");
        }
        if (battleRef.returnEnemyLocation(target) > 0)
        {
            move = new Move("Cleave", rollDice(1, Attack) - 1, rollDice(1, tempList[battleRef.returnEnemyLocation(target) - 1].Defence), rollDice(Damage[0], Damage[1]) - 2);
            Debug.Log("Att: " + move.Att + " vs Def: " + move.Def);
            if (move.Att > move.Def)
            {
                Debug.Log(Name + ": " + move.Name + " on " + tempList[battleRef.returnEnemyLocation(target) - 1].Name + " for " + move.Dam + ". Place: " + (battleRef.returnEnemyLocation(target) - 1));
                tempList[battleRef.returnEnemyLocation(target) - 1].Health -= move.Dam;
            }
            else
            {
                Debug.Log(Name + ": " + move.Name + " on " + tempList[battleRef.returnEnemyLocation(target) - 1].Name + " missed! Place: " + (battleRef.returnEnemyLocation(target) - 1));
            }
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
    /// Tank Up
    /// Att: NA
    /// Dam: NA
    /// Target: Single
    /// Status: None
    /// </summary>
    /// <param name="target"></param>
    public override void move5(Entity target)
    {
        string moveName = "Tank Up";
        target.StatusEffects["TempHealth"] += rollDice(Damage[0], Damage[1]);
        Debug.Log(moveName + " on " + target.Name);
    }
}
