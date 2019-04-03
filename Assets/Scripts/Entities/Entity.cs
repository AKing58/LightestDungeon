using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class Entity : MonoBehaviour{
    System.Random r;
    //Custom Enums
    public enum Vocation { Knight, Rogue, Cleric, Mage, Orc };
    public enum Position { Front, Back };

    public bool Friendly { get; set; }
    public Vocation ClassType { get; set; }
    public string Name { get; set; }

    //Stats
    public int Level { get; set; }
    public int Health { get; set; }
    public int Attack {
        get { return Attack + StatusEffects["AttBuff"]; }
        set { Attack = value; }
    }
    public int[] Damage
    {
        get {
            int[] tempDam = Damage;
            for(int i=0; i<2; i++)
                tempDam[i]++;
            return tempDam; }
        set { Damage = value; }
    }
    public int Defence
    {
        get { return Defence + StatusEffects["AttBuff"]; }
        set { Defence = value; }
    }
public int Speed { get; set; }

    //Status
    /// <summary>
    /// DefBuff
    /// AttBuff
    /// </summary>
    public Dictionary<string, int> StatusEffects;

    //Bonuses
    private int AttBonus { get; set; }
    private int DamBonus { get; set; }
    public Equipment[] Loadout { get; set; }

    public Position CurPosition { get; set; }
    public bool isTurn { get; set; }

    

    //Physical location
    public float locPosx;
    public float locPosy;
    public float locPosz;

    //Used to access this character's info panel
    public GameObject myPanel;

    //Basically a constructor
    public void createEntity(string name, int lv, int hp, int att, int[] dam,int def, int speed)
    {
        Name = name;
        Level = lv;
        Health = hp;
        Attack = att;
        Defence = def;
        Damage = dam;

        StatusEffects = new Dictionary<string, int>();

        CurPosition = Position.Front;
        locPosx = transform.localPosition.x;
        locPosy = transform.localPosition.y;
        locPosz = transform.localPosition.z;
    }

    //To be overrided by derived classes for initialization of a derived entity
    public virtual void init(string name) { }

    //Moves positions
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
    //On mouse over event used to activate the selection UI
    void OnMouseOver()
    {
        transform.Find("SelectionUI").gameObject.SetActive(true);
    }
    //On mouse exit event used to deactivate the selection UI
    void OnMouseExit() 
    {
        transform.Find("SelectionUI").gameObject.SetActive(false);
    }
    //First move for derived entities to override
    public virtual void move1(Entity target)
    {
        Debug.Log("Move1");
    }
    //Second move for derived entities to override
    public virtual void move2(Entity target)
    {
        Debug.Log("Move2");
    }
    //Third move for derived entities to override
    public virtual void move3(Entity target)
    {
        Debug.Log("Move3");
    }
    //Fourth move for derived entities to override
    public virtual void move4(Entity target)
    {
        Debug.Log("Move4");
    }
    //Fifth move for derived entities to override
    public virtual void move5(Entity target)
    {
        Debug.Log("Move5");
    }
    //Determines this entity's currently selected skill and performs it on the entity selected
    public void doMove(Entity target)
    {
        switch (myPanel.GetComponent<CharacterInfoPanelScript>().selectedSkill)
        {
            case CharacterInfoPanelScript.SelectedSkill.MOVE1:
                move1(target);
                break;
            case CharacterInfoPanelScript.SelectedSkill.MOVE2:
                move2(target);
                break;
            case CharacterInfoPanelScript.SelectedSkill.MOVE3:
                move3(target);
                break;
            case CharacterInfoPanelScript.SelectedSkill.MOVE4:
                move4(target);
                break;
            case CharacterInfoPanelScript.SelectedSkill.MOVE5:
                move5(target);
                break;
            default:
                move1(target);
                Debug.Log("Defaulted");
                break;
        }
        didMove();
    }

    public int rollDice(int min, int max)
    {
        r = new System.Random();
        return r.Next(min, max);
    }

    //Once the Entity performs the move on a target, moves on to the next turn
    public void didMove()
    {
        GameObject.Find("DungeonManager").GetComponent<BattleManager>().nextTurn();
    }
    public struct Move
    {
        public string Name;
        public int Att;
        public int Dam;
        public int Def;
        public Move(string name, int att, int def, int dam)
        {
            Name = name;
            Att = att;
            Dam = dam;
            Def = def;
        }
    }
}
