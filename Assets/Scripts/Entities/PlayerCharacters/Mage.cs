using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Entity
{
    //Initializes the Mage Entity
    public override void init(string name)
    {
        createEntity(name, 1, 10, 9, new int[] { 6, 8 }, 8, 10);
        ClassType = Vocation.Mage;
        Friendly = true;
        md1 = new MoveDesc("Fireball", "Single", "0", "+2", "None", "Shoot a fireball");
        md2 = new MoveDesc("Earthquake", "Enemies", "0", "-5", "None", "Deals a small amount of guaranteed damage to all enemies");
        md3 = new MoveDesc("Chain Lightning", "Single/Multi", "0", "-2", "None", "Target an enemy. If they are hit, target a random adjacent enemy until it misses");
        md4 = new MoveDesc("Flash", "Enemies", "0", "0", "Stun", "Low chance to stun applied to all enemies");
        md5 = new MoveDesc("Magic Missile", "Random", "-1", "-3", "None", "Randomly targets 3 enemies");
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
            InitAnimation("Fireball", target);
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
    /// Dam: -5
    /// Target: All
    /// Status: None
    /// </summary>
    /// <param name="target"></param>
    public override void move2(Entity target)
    {
        List<Entity> e = GameObject.Find("DungeonManager").GetComponent<BattleManager>().enemyList;
        for (int i=0; i < e.Count; i++)
        {
            Move move = new Move("Earthquake", rollDice(1, Attack), rollDice(1, e[i].Defence), rollDice(Damage[0], Damage[1]) - 5);
            Debug.Log(Name + ": " + move.Name + " on " + e[i].Name + " for " + move.Dam);
            e[i].Health -= move.Dam;
        }
        Debug.Log("Earthquake!");
    }
    /// <summary>
    /// Chain Lightning
    /// ------If it damages an enemy, attempts attack on an adjacent enemy and get -1 att for the turn
    /// Att: 0
    /// Dam: -2
    /// Target: Single
    /// Status: None
    /// </summary>
    /// <param name="target"></param>
    public override void move3(Entity target)
    {
        Move move = new Move("Chain Lightning", rollDice(1, Attack), rollDice(1, target.Defence), rollDice(Damage[0], Damage[1])-2);
        BattleManager battleRef = GameObject.Find("DungeonManager").GetComponent<BattleManager>();
        List<Entity> tempList = battleRef.enemyList;
        int targetLocation = battleRef.returnEnemyLocation(target);

        Debug.Log("Att: " + move.Att + " vs Def: " + move.Def);
        if (move.Att > move.Def)
        {
            Debug.Log(Name + ": " + move.Name + " on " + target.Name + " for " + move.Dam);
            StatusEffects["AttBuff"] -= 1;
            target.Health -= move.Dam;
            if (tempList.Count == 1)
                return;
            if (rollDice(0, 1) == 1)
            {
                if (targetLocation >= 1)
                    targetLocation--;
                else
                    targetLocation++;
            }
            else
            {
                if (targetLocation <= tempList.Count - 1)
                    targetLocation++;
                else
                    targetLocation--;
            }
            move3(tempList[targetLocation]);
        }
        else
        {
            Debug.Log(move.Name + " on " + target.Name + " missed!");
        }
    }
    /// <summary>
    /// Flash
    /// ------Low chance to stun
    /// Att: 0
    /// Dam: 0
    /// Target: All
    /// Status: stun
    /// </summary>
    /// <param name="target"></param>
    public override void move4(Entity target)
    {

        foreach (Entity e in GameObject.Find("DungeonManager").gameObject.GetComponent<BattleManager>().enemyList)
        {
            if (rollDice(1, 5) <= 2)
            {
                Debug.Log("Stunned!");
                e.StatusEffects["Stun"] += 1;
            }
        }
    }
    /// <summary>
    /// Magic Missiles
    /// ------Hits 3 targets randomly
    /// Att: -1
    /// Dam: -3
    /// Target: All
    /// Status: stun
    /// </summary>
    /// <param name="target"></param>
    public override void move5(Entity target)
    {
        BattleManager bm = GameObject.Find("DungeonManager").gameObject.GetComponent<BattleManager>();
        int targetLoc;
        for (int i=0; i<3; i++)
        {
            targetLoc = rollDice(0, bm.enemyList.Count);
            Move move = new Move("Magic Missiles", rollDice(1, Attack)-1, rollDice(1, bm.enemyList[targetLoc].Defence), rollDice(Damage[0], Damage[1]) - 3);
            if(move.Att > move.Def)
            {
                Debug.Log(bm.enemyList[targetLoc].Name + " hit for " + move.Dam);
                bm.enemyList[targetLoc].Health -= move.Dam;
            }
            else
            {
                Debug.Log("Missed " + bm.enemyList[targetLoc].Name);
            }
            if (bm.enemyList.Count == 0)
                break;
        }
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
}
