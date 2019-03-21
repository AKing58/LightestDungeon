using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Entity
{
    public void init(string name)
    {
        createEntity(name, 1, 10, 10, 10, 8);
        ClassType = Vocation.Knight;
        Friendly = true;
    }
}
