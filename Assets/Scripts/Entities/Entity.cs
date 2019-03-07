using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
