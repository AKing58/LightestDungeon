using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogue : Entity
{
    public override void init(string name)
    {
        createEntity(name, 1, 8, 14, 8, 12);
        ClassType = Vocation.Rogue;
        Friendly = true;
    }
    public override void move1(Entity target)
    {
        Debug.Log("Rogue Move1 on " + target.Name);
    }

    public override void move2(Entity target)
    {
        Debug.Log("Rogue Move2 on " + target.Name);
    }

    public override void move3(Entity target)
    {
        Debug.Log("Rogue Move3 on " + target.Name);
    }

    public override void move4(Entity target)
    {
        Debug.Log("Rogue Move4 on " + target.Name);
    }

    public override void move5(Entity target)
    {
        Debug.Log("Rogue Move5 on " + target.Name);
    }
}
