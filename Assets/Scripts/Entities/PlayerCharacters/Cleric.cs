using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleric : Entity
{
    public override void init(string name)
    {
        createEntity(name, 1, 10, 8, 14, 8);
        ClassType = Vocation.Cleric;
        Friendly = true;
    }
    public override void move1(Entity target)
    {
        Debug.Log("Cleric Move1 on " + target.Name);
    }

    public override void move2(Entity target)
    {
        Debug.Log("Cleric Move2 on " + target.Name);
    }

    public override void move3(Entity target)
    {
        Debug.Log("Cleric Move3 on " + target.Name);
    }

    public override void move4(Entity target)
    {
        Debug.Log("Cleric Move4 on " + target.Name);
    }

    public override void move5(Entity target)
    {
        Debug.Log("Cleric Move5 on " + target.Name);
    }
}
