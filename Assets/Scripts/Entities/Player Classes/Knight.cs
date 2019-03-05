using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Knight : Entity
{
    public Knight(string name, int lv, int hp, int att, int def) : base(name, lv, hp, att, def)
    {
        Classname = "Knight";
    }
}
