using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Cleric : Entity
{
    public Cleric(int lv, int hp, int att, int def) : base(lv, hp, att, def)
    {
        Classname = "Cleric";
    }
}
