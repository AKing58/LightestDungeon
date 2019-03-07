using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Cleric : Entity
{
    public Cleric(string name, int lv, int hp, int att, int def) : base(name, lv, hp, att, def)
    {
        Classname = "Cleric";
    }
}
