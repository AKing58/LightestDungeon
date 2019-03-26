using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleric : Entity
{
    //Initializes the Cleric Entity
    public override void init(string name)
    {
        createEntity(name, 1, 10, 8, 14, 8);
        ClassType = Vocation.Cleric;
        Friendly = true;
    }
    //Cleric Move 1
    public override void move1(Entity target)
    {
        Debug.Log("Cleric Move1 on " + target.Name);
    }
    //Cleric Move 2
    public override void move2(Entity target)
    {
        Debug.Log("Cleric Move2 on " + target.Name);
    }
    //Cleric Move 3
    public override void move3(Entity target)
    {
        Debug.Log("Cleric Move3 on " + target.Name);
    }
    //Cleric Move 4
    public override void move4(Entity target)
    {
        Debug.Log("Cleric Move4 on " + target.Name);
    }
    //Cleric Move 5
    public override void move5(Entity target)
    {
        Debug.Log("Cleric Move5 on " + target.Name);
    }
}
