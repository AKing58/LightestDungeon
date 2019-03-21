using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleric : Entity
{
    public void init(string name)
    {
        createEntity(name, 1, 10, 8, 14, 8);
        ClassType = Vocation.Cleric;
        Friendly = true;
    }
}
