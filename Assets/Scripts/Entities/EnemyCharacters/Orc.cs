﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : Entity
{
    public void init(string name)
    {
        createEntity(name, 1, 8, 8, 8, 10);
        ClassType = Vocation.Orc;
        Friendly = false;
    }
}
