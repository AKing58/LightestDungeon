using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleric : Entity
{
    //Initializes the Cleric Entity
    public override void init(string name)
    {
        createEntity(name, 1, 10, 8, new int[] { 1, 6 }, 12);
        ClassType = Vocation.Cleric;
        Friendly = true;
        md1 = new MoveDesc("Healing Touch", "Single", "0", "+2", "Heal", "Heal a target");
        md2 = new MoveDesc("Mind Blast", "Single", "-2", "+5", "None", "High amount of damage, low amount to hit");
        md3 = new MoveDesc("Group Heal", "Friendly", "0", "-2", "None", "Heal all friendlies for a lesser amount");
        md4 = new MoveDesc("Smite", "Single", "+2", "0", "Heal", "Target an enemy. If they are damaged, heal a random Friendly for half as much");
        md5 = new MoveDesc("Favour", "Single", "0", "0", "Buff", "Buff a target's attack by 5");
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
        InitAnimation("Heal", target);
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
            InitAnimation("MindBlast", target);
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
    /// Dam: -2
    /// Target: Single
    /// Status: None
    /// </summary>
    /// <param name="target"></param>
    public override void move3(Entity target)
    {
        Move move = new Move("Group Heal", rollDice(1, Attack), 0, rollDice(Damage[0], Damage[1]) - 2);
        foreach(Entity e in GameObject.Find("DungeonManager").GetComponent<DungeonManager>().playerList)
        {
            InitAnimation("Heal", e);
            e.Health += move.Dam;
        }
        Debug.Log("Healing for " + move.Dam + " on party");
    }

    /// <summary>
    /// Smite
    /// Att: +2
    /// Dam: 0
    /// Target: Single
    /// Status: None
    /// </summary>
    /// <param name="target"></param>
    public override void move4(Entity target)
    {
        Move move = new Move("Smite", rollDice(1, Attack) + 2, rollDice(1, target.Defence), rollDice(Damage[0], Damage[1]));
        Debug.Log("Att: " + move.Att + " vs Def: " + move.Def);
        if (move.Att > move.Def)
        {
            InitAnimation("Flash", target);
            List<Entity> tempList = GameObject.Find("DungeonManager").GetComponent<DungeonManager>().playerList;
            Debug.Log(Name + ": " + move.Name + " on " + target.Name + " for " + move.Dam);
            target.Health -= move.Dam;
            tempList[rollDice(0, tempList.Count)].Health += (move.Dam / 2);
        }
        else
        {
            Debug.Log(move.Name + " on " + target.Name + " missed!");
        }
    }
    /// <summary>
    /// Favour
    /// -------Attack Buff
    /// Att: NA
    /// Dam: NA
    /// Target: Single
    /// Status: AttBuff
    /// </summary>
    /// <param name="target"></param>
    public override void move5(Entity target)
    {
        InitAnimation("Buff", target);
        string moveName = "Favor";
        target.StatusEffects["AttBuff"] += 5;
        Debug.Log(moveName + " on " + target.Name);
    }

    void InitAnimation(string ani, Entity target)
    {
        GameObject prefab = Resources.Load("Prefabs/" + ani) as GameObject;
        GameObject temp = Instantiate(prefab, target.transform.position, Quaternion.identity);
        RectTransform tempRect = temp.GetComponent<RectTransform>();
        temp.transform.SetParent(target.transform);
        temp.transform.localPosition = prefab.transform.localPosition;
        temp.transform.localScale = prefab.transform.localScale;
        temp.transform.localRotation = prefab.transform.localRotation;

        temp.GetComponent<Animator>().SetTrigger(ani);
        Destroy(temp.gameObject, 2);
    }

    void InitAnimationSelf(string ani)
    {
        GameObject prefab = Resources.Load("Prefabs/" + ani) as GameObject;
        GameObject temp = Instantiate(prefab, gameObject.transform.position, Quaternion.identity);
        RectTransform tempRect = temp.GetComponent<RectTransform>();
        temp.transform.SetParent(gameObject.transform);
        temp.transform.localPosition = prefab.transform.localPosition;
        temp.transform.localScale = prefab.transform.localScale;
        temp.transform.localRotation = prefab.transform.localRotation;

        temp.GetComponent<Animator>().SetTrigger(ani);
        Destroy(temp.gameObject, 2);
    }

}
