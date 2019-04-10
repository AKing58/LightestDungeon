using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleric : Entity
{
    //Initializes the Cleric Entity
    public override void init(string name)
    {
        createEntity(name, 1, 10, 8, new int[] { 1, 6 }, 12, 8);
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
        InitHeal(target);
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
        Move move = new Move("Mind Blast", rollDice(1, Attack)-2, rollDice(1, target.Defence), rollDice(Damage[0], Damage[1]) + 5);
        Debug.Log("Att: " + move.Att + " vs Def: " + move.Def);
        if (move.Att > move.Def)
        {
            InitMB(target);
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
            InitHeal(e);
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
            Debug.Log(Name + ": " + move.Name + " on " + target.Name + " for " + move.Dam);
            target.Health -= move.Dam;
        }
        else
        {
            Debug.Log(move.Name + " on " + target.Name + " missed!");
        }
    }
    /// <summary>
    /// Favor
    /// -------Attack Buff
    /// Att: NA
    /// Dam: NA
    /// Target: Single
    /// Status: AttBuff
    /// </summary>
    /// <param name="target"></param>
    public override void move5(Entity target)
    {
        InitBuff(target);
        string moveName = "Favor";
        target.StatusEffects["AttBuff"] += 5;
        Debug.Log(moveName + " on " + target.Name);
    }

    void InitHeal(Entity target)
    {
        GameObject heal = Resources.Load("Prefabs/Heal") as GameObject;
        GameObject temp = Instantiate(heal, target.transform.position, Quaternion.identity);
        RectTransform tempRect = temp.GetComponent<RectTransform>();
        temp.transform.SetParent(target.transform);
        temp.transform.localPosition = heal.transform.localPosition;
        temp.transform.localScale = heal.transform.localScale;
        temp.transform.localRotation = heal.transform.localRotation;

        temp.GetComponent<Animator>().SetTrigger("HealCast");
        Destroy(temp.gameObject, 2);
    }

    void InitMB(Entity target)
    {
        GameObject mind = Resources.Load("Prefabs/MindBlast") as GameObject;
        GameObject temp = Instantiate(mind, target.transform.position, Quaternion.identity);
        RectTransform tempRect = temp.GetComponent<RectTransform>();
        temp.transform.SetParent(target.transform);
        temp.transform.localPosition = mind.transform.localPosition;
        temp.transform.localScale = mind.transform.localScale;
        temp.transform.localRotation = mind.transform.localRotation;

        temp.GetComponent<Animator>().SetTrigger("MindCast");
        Destroy(temp.gameObject, 2);
    }

    void InitBuff(Entity target)
    {
        GameObject buff = Resources.Load("Prefabs/Buff") as GameObject;
        GameObject temp = Instantiate(buff, target.transform.position, Quaternion.identity);
        RectTransform tempRect = temp.GetComponent<RectTransform>();
        temp.transform.SetParent(target.transform);
        temp.transform.localPosition = buff.transform.localPosition;
        temp.transform.localScale = buff.transform.localScale;
        temp.transform.localRotation = buff.transform.localRotation;

        temp.GetComponent<Animator>().SetTrigger("Buff");
        Destroy(temp.gameObject, 2);
    }

}
