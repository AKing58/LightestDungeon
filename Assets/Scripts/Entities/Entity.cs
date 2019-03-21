using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Entity : MonoBehaviour {
    public enum Vocation { Knight, Rogue, Cleric, Mage, Orc };
    public enum Position { Front, Back };
    //public string Classname { get; set; }

    public bool Friendly { get; set; }
    public Vocation ClassType { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    public int Health { get; set; }
    public int Attack { get; set; }
    public int Defence { get; set; }
    public Position CurPosition { get; set; }
    public Equipment[] Loadout { get; set; }

    public float locPosx;
    public float locPosy;
    public float locPosz;

    public void createEntity(string name, int lv, int hp, int att, int def)
    {
        Name = name;
        Level = lv;
        Health = hp;
        Attack = att;
        Defence = def;
        CurPosition = Position.Front;
        locPosx = transform.localPosition.x;
        locPosy = transform.localPosition.y;
        locPosz = transform.localPosition.z;
    }
    /**
     * Friendlies
     */
    public void initKnight(string name)
    {
        createEntity(name, 1, 10, 10, 10);
        ClassType = Vocation.Knight;
        Friendly = true;
    }
    public void initRogue(string name)
    {
        createEntity(name, 1, 8, 14, 8);
        ClassType = Vocation.Rogue;
        Friendly = true;
    }
    public void initCleric(string name)
    {
        createEntity(name, 1, 10, 8, 14);
        ClassType = Vocation.Cleric;
        Friendly = true;
    }
    public void initMage(string name)
    {
        createEntity(name, 1, 10, 12, 8);
        ClassType = Vocation.Mage;
        Friendly = true;
    }

    /**
     * Enemies
     */
    public void initOrc(string name)
    {
        createEntity(name, 1, 8, 8, 8);
        ClassType = Vocation.Orc;
        Friendly = false;
    }

    public void switchPosition()
    {
        float movementAmount;
        if (Friendly)
            movementAmount = -1.5F;
        else
            movementAmount = 1.5F;
        //CurPosition = CurPosition == Position.Front ? Position.Back : Position.Front;
        if (CurPosition == Entity.Position.Front)
        {
            transform.localPosition = new Vector3(locPosx, locPosy, locPosz + movementAmount);
            CurPosition = Entity.Position.Back;
            Debug.Log("Front to back");
        }
        else
        {
            Debug.Log("Back to front");
            transform.localPosition = new Vector3(locPosx, locPosy, locPosz);
            CurPosition = Entity.Position.Front;
        }
    }

    public void parseClassName(string className, string name)
    {
        switch (className)
        {
            case "Knight":
                initKnight(name);
                break;
            case "Rogue":
                initRogue(name);
                break;
            case "Cleric":
                initCleric(name);
                break;
            case "Mage":
                initMage(name);
                break;
            case "Orc":
                initOrc("Orc");
                break;
            default:
                initKnight(name);
                break;
        }
    }
}

/*
[System.Serializable]
public class Entity
{
    public string Classname { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    public int Health { get; set; }
    public int Attack { get; set; }
    public int Defence { get; set; }
    public string Position { get; set; }
    public Equipment[] Loadout { get; set; }

    public Entity(string name, int lv, int hp, int att, int def)
    {
        Name = name;
        Level = lv;
        Health = hp;
        Attack = att;
        Defence = def;
        Position = "Front";
    }

}
*/
