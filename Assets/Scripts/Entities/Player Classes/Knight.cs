using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Entity
{
    public Knight(int lv, int hp, int att, int def) : base(lv, hp, att, def)
    {
        Classname = "Knight";
    }
}
