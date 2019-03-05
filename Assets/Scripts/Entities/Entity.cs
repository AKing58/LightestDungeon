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
    public List<Move> Moveset { get; set; }
    public Equipment[] Loadout { get; set; }

    public Entity(int lv, int hp, int att, int def)
    {
        Level = lv;
        Health = hp;
        Attack = att;
        Defence = def;
    }

}
