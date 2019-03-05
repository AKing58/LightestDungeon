using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
class Rogue : Entity
{
    public Rogue(string name, int lv, int hp, int att, int def) : base(name, lv, hp, att, def)
    {
        Classname = "Rogue";
        Level = lv;
        Health = hp;
        Attack = att;
        Defence = def;
    }
}
