using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Entity
{
    public void init(string name)
    {
        createEntity(name, 1, 10, 12, 8, 10);
        ClassType = Vocation.Mage;
        Friendly = true;
    }
}
