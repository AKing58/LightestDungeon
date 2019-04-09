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
            InitFireball();
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
        foreach (Entity e in GameObject.Find("DungeonManager").GetComponent<BattleManager>().enemyList)
        {
            Move move = new Move("Earthquake", rollDice(1, Attack), rollDice(1, e.Defence), rollDice(Damage[0], Damage[1]) - 3);
            Debug.Log(Name + ": " + move.Name + " on " + e.Name + " for " + move.Dam);
            e.Health += move.Dam;
        }
        Debug.Log("Earthquake!");
    }
    /// <summary>
    /// Chain Lightning
    /// ------If it damages an enemy, attempts attack on an adjacent enemy and get -1 att for the turn
    /// Att: 0
    /// Dam: -3
    /// Target: Single
    /// Status: None
    /// </summary>
    /// <param name="target"></param>
    public override void move3(Entity target)
    {
        Move move = new Move("Chain Lightning", rollDice(1, Attack), rollDice(1, target.Defence), rollDice(Damage[0], Damage[1])-3);
        BattleManager battleRef = GameObject.Find("DungeonManager").GetComponent<BattleManager>();
        List<Entity> tempList = battleRef.enemyList;
        int targetLocation = battleRef.returnEnemyLocation(target);

        Debug.Log("Att: " + move.Att + " vs Def: " + move.Def);
        if (move.Att > move.Def)
        {
            Debug.Log(Name + ": " + move.Name + " on " + target.Name + " for " + move.Dam);
            target.StatusEffects["AttBuff"] -= 1;
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

    void InitFireball()
    {
        GameObject fireball = Resources.Load("Prefabs/Fireball") as GameObject;
        GameObject temp = Instantiate(fireball, gameObject.transform.position, Quaternion.identity);
        RectTransform tempRect = temp.GetComponent<RectTransform>();
        temp.transform.SetParent(gameObject.transform);
        temp.transform.localPosition = fireball.transform.localPosition;
        temp.transform.localScale = fireball.transform.localScale;
        temp.transform.localRotation = fireball.transform.localRotation;

        temp.GetComponent<Animator>().SetTrigger("FireballCast");
        Destroy(temp.gameObject, 2);
    }
}
