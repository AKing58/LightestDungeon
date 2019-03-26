using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Entity
{
    //Initializes the Mage Entity
    public override void init(string name)
    {
        createEntity(name, 1, 10, 12, 8, 10);
        ClassType = Vocation.Mage;
        Friendly = true;
    }
    //Mage Move 1
    public override void move1(Entity target)
    {
        Debug.Log("Mage Move1 on " + target.Name);
    }
    //Mage Move 2
    public override void move2(Entity target)
    {
        Debug.Log("Mage Move2 on " + target.Name);
    }
    //Mage Move 3
    public override void move3(Entity target)
    {
        Debug.Log("Mage Move3 on " + target.Name);
    }
    //Mage Move 4
    public override void move4(Entity target)
    {
        Debug.Log("Mage Move4 on " + target.Name);
    }
    //Mage Move 5
    public override void move5(Entity target)
    {
        Debug.Log("Mage Move5 on " + target.Name);
    }
}
