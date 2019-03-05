﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
class Mage : Entity
{
    public Mage(string name, int lv, int hp, int att, int def) : base(name, lv, hp, att, def)
    {
        Classname = "Mage";
    }
}
