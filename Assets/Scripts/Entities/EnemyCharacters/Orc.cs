using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : Entity
{
    //Initializes the Orc Entity
    public override void init(string name)
    {
        createEntity(name, 1, 8, 8, new int[] { 2, 6 }, 8, 10);
        ClassType = Vocation.Orc;
        Friendly = false;
    }
}
