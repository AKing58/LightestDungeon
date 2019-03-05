using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Mage : Entity
{
    public Mage(int lv, int hp, int att, int def) : base(lv, hp, att, def)
    {
        Classname = "Mage";
    }
}
