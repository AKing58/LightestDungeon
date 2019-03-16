using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Entity : MonoBehaviour {
    public enum Vocation { Knight, Rogue, Cleric, Mage };
    public enum Position { Front, Back };
    //public string Classname { get; set; }
    public Vocation ClassType { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    public int Health { get; set; }
    public int Attack { get; set; }
    public int Defence { get; set; }
    public Position CurPosition { get; set; }
    public Equipment[] Loadout { get; set; }

    public void createEntity(string name, int lv, int hp, int att, int def)
    {
        Name = name;
        Level = lv;
        Health = hp;
        Attack = att;
        Defence = def;
        CurPosition = Position.Front;
    }
    public void initKnight(string name)
    {
        createEntity(name, 1, 10, 10, 10);
        ClassType = Vocation.Knight;
    }
    public void initRogue(string name)
    {
        createEntity(name, 1, 8, 14, 8);
        ClassType = Vocation.Rogue;
    }
    public void initCleric(string name)
    {
        createEntity(name, 1, 10, 8, 14);
        ClassType = Vocation.Cleric;
    }
    public void initMage(string name)
    {
        createEntity(name, 1, 10, 12, 8);
        ClassType = Vocation.Mage;
    }

    public void switchPosition()
    {
        CurPosition = CurPosition == Position.Front ? Position.Back : Position.Front;
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
