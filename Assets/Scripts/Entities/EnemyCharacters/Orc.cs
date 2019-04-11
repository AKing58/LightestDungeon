using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : Entity
{
    //Initializes the Orc Entity
    public override void init(string name)
    {
        createEntity(name, 1, 8, 8, new int[] { 2, 6 }, 8);
        ClassType = Vocation.Orc;
        Friendly = false;
    }

    /// <summary>
    /// Bash action that the Orc uses
    /// </summary>
    /// <param name="target"></param>
    public override void move1(Entity target)
    {
        Move move = new Move("Bash", rollDice(1, Attack), rollDice(1, target.Defence), rollDice(Damage[0], Damage[1]));
        Debug.Log("Att: " + move.Att + " vs Def: " + move.Def);
        if (move.Att > move.Def)
        {
            InitBash(target);
            Debug.Log(Name + ": " + move.Name + " on " + target.Name + " for " + move.Dam);
            target.Health -= move.Dam;
        }
        else
        {
            Debug.Log(move.Name + " on " + target.Name + " missed!");
        }
    }

    /// <summary>
    /// Initiates bash animations, loading a prefab as a gameobject
    /// </summary>
    /// <param name="target"></param>
    void InitBash(Entity target)
    {
        GameObject bash = Resources.Load("Prefabs/Bonk") as GameObject;
        GameObject temp = Instantiate(bash, target.transform.position, Quaternion.identity);
        RectTransform tempRect = temp.GetComponent<RectTransform>();
        temp.transform.SetParent(target.transform);
        temp.transform.localPosition = bash.transform.localPosition;
        temp.transform.localScale = bash.transform.localScale;
        temp.transform.localRotation = bash.transform.localRotation;

        temp.GetComponent<Animator>().SetTrigger("Bonk");
        Destroy(temp.gameObject, 2);
    }
}
