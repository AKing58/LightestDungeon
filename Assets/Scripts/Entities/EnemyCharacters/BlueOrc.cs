﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueOrc : Entity
{
    //Initializes the BlueOrc Entity
    public override void init(string name)
    {
        createEntity(name, 1, 9, 9, new int[] { 2, 7 }, 9);
        ClassType = Vocation.BlueOrc;
        Friendly = false;
    }

    /// <summary>
    /// Bash action that the BlueOrc uses
    /// </summary>
    /// <param name="target"></param>
    public override void move1(Entity target)
    {
        Move move = new Move("Bash", rollDice(1, Attack), rollDice(1, target.Defence), rollDice(Damage[0], Damage[1]));
        Debug.Log("Att: " + move.Att + " vs Def: " + move.Def);
        if (move.Att > move.Def)
        {
            InitAnimation("Bonk", target);
            Debug.Log(Name + ": " + move.Name + " on " + target.Name + " for " + move.Dam);
            target.Health -= move.Dam;
        }
        else
        {
            Debug.Log(move.Name + " on " + target.Name + " missed!");
        }
    }

    /// <summary>
    /// Initiates animations, loading a prefab as a gameobject
    /// </summary>
    /// <param name="ani"></param>
    /// <param name="target"></param>
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
