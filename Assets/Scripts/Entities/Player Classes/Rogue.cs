using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Rogue : Entity
{
    public Rogue(int lv, int hp, int att, int def) : base(lv, hp, att, def)
    {
        Classname = "Rogue";
        Level = lv;
        Health = hp;
        Attack = att;
        Defence = def;
    }
}
