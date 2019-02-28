using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    private string _name;
    private string _classname;
    private int _health;

    public string Name { get; set; }
    public string Classname { get; set; }
    public int Health { get; set; }

    public Player(string name, string classname, int health)
    {
        _name = name;
        _classname = classname;
        _health = health;
    }
    
}
