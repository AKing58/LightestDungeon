using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogue : Entity
{
    public void init(string name)
    {
        createEntity(name, 1, 8, 14, 8, 12);
        ClassType = Vocation.Rogue;
        Friendly = true;
    }
}
