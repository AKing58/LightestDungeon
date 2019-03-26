using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Entity
{
    //Initializes the Knight Entity
    public override void init(string name)
    {
        createEntity(name, 1, 10, 10, 10, 8);
        ClassType = Vocation.Knight;
        Friendly = true;
    }

    //Knight Move 1
    public override void move1(Entity target)
    {
        Debug.Log("Knight Move1 on " + target.Name);
    }
    //Knight Move 2
    public override void move2(Entity target)
    {
        Debug.Log("Knight Move2 on " + target.Name);
    }
    //Knight Move 3
    public override void move3(Entity target)
    {
        Debug.Log("Knight Move3 on " + target.Name);
    }
    //Knight Move 4
    public override void move4(Entity target)
    {
        Debug.Log("Knight Move4 on " + target.Name);
    }
    //Knight Move 5
    public override void move5(Entity target)
    {
        Debug.Log("Knight Move5 on" + target.Name);
    }
}
