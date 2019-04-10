using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Entity : MonoBehaviour{
    //Custom Enums
    public enum Vocation { Knight, Rogue, Cleric, Mage, Orc };
    public enum Position { Front, Back };

    public bool Friendly { get; set; }
    private Vocation classType;
    public Vocation ClassType { get { return classType;  } set { classType = value; } }
    public string Name { get; set; }

    //Stats
    public int Level { get; set; }
    public int Max_Health;
    private int health;
    public int Health {
        get { return health; }
        set
        {
            if (StatusEffects["TempHealth"] > 0 && value < health)
            {
                int tempTempHealth = StatusEffects["TempHealth"];
                if (value * -1 > tempTempHealth)
                    value += StatusEffects["TempHealth"];
                else
                    StatusEffects["TempHealth"] += value;
            }
            else
            {
                health = value;
            }
            if (health > Max_Health)
                health = Max_Health;
            if (health <= 0)
            {
                BattleManager bm = GameObject.Find("DungeonManager").GetComponent<BattleManager>();
                if (!Friendly)
                    bm.incrementDefeated(ClassType.ToString());
                Debug.Log(Name + " Died");
                //bm.nextTurn();
                bm.turnOrder.Remove(this);
                GameObject.Find("DungeonManager").GetComponent<DungeonManager>().playerList.Remove(this);
                bm.enemyList.Remove(this);
                if(myPanel != null && Friendly)
                    Destroy(myPanel.gameObject);
                if (myPanel!=null && !Friendly)
                    myPanel.GetComponent<EnemyInfoPanelScript>().defeatedPanel();
                Destroy(gameObject);
            }
        }
    }
    private int attack;
    public int Attack {
        get
        {
            int tempValue = attack + StatusEffects["AttBuff"];
            return tempValue;
        }
        set { attack = value; }
    }
    private int[] damage;
    public int[] Damage
    {
        get {
            int[] tempDam = damage;
            for(int i=0; i<2; i++)
            {
                tempDam[i] += StatusEffects["DamBuff"];;
            }
            
            return tempDam; }
        set { damage = value; }
    }
    private int defence;
    public int Defence
    {
        get
        {
            int tempDef = defence + StatusEffects["DefBuff"];
            return tempDef;
        }
        set { defence = value; }
    }
    public int Speed { get; set; }

    public MoveDesc md1;
    public MoveDesc md2;
    public MoveDesc md3;
    public MoveDesc md4;
    public MoveDesc md5;

    //Status
    /// <summary>
    /// DefBuff
    /// AttBuff
    /// DamBuff
    /// Stun
    /// Bleed
    /// </summary>
    public Dictionary<string, int> StatusEffects;

    //Bonuses
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
        StatusEffects = new Dictionary<string, int>();
        StatusEffects.Add("AttBuff", 0);
        StatusEffects.Add("DefBuff", 0);
        StatusEffects.Add("DamBuff", 0);
        StatusEffects.Add("TempHealth", 0);
        StatusEffects.Add("Stun", 0);
        StatusEffects.Add("Bleed", 0);

        Name = name;
        Level = lv;
        Max_Health = hp;
        Health = hp;
        Attack = att;
        Defence = def;
        Damage = dam;

        
        CurPosition = Position.Back;
        locPosx = transform.localPosition.x;
        locPosy = transform.localPosition.y;
        locPosz = transform.localPosition.z;

        //if(Friendly)
        //    parent = GameObject.Find("Players");
        //else
        //    parent = GameObject.Find("Enemies");
        //
        //destination = parent.transform.position + new Vector3(locPosx, locPosy, locPosz);

    }

    public void refreshStatusEffects()
    {
        StatusEffects["AttBuff"] = 0;
        StatusEffects["DefBuff"] = 0;
        StatusEffects["DamBuff"] = 0;
        StatusEffects["TempHealth"] = 0;
    }

    //To be overrided by derived classes for initialization of a derived entity
    public virtual void init(string name) { }

    //Moves positions
    public void switchPosition()
    {
        float movementAmount;
        if (Friendly)
            movementAmount = 1F;
        else
            movementAmount = -1F;
        //CurPosition = CurPosition == Position.Front ? Position.Back : Position.Front;
        if (CurPosition == Entity.Position.Back)
        {
            transform.localPosition = new Vector3(locPosx, locPosy, locPosz + movementAmount);
            CurPosition = Entity.Position.Front;
            Debug.Log("Front to back");
        }
        else
        {
            Debug.Log("Back to front");
            transform.localPosition = new Vector3(locPosx, locPosy, locPosz);
            CurPosition = Entity.Position.Back;
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
        DungeonManager d = GameObject.Find("DungeonManager").GetComponent<DungeonManager>();
        return d.randSeed.Next(min, max);
    }

    //Once the Entity performs the move on a target, moves on to the next turn
    public void didMove()
    {
        switchPosition();
        refreshStatusEffects();
        myPanel.transform.Find("SkillPanel").gameObject.SetActive(false);
        GameObject.Find("DungeonManager").GetComponent<BattleManager>().nextTurn();
    }

    private static int minOne(int input)
    {
        if (input < 1)
            return 1;
        return input;
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
            Att = minOne(att);
            Dam = minOne(dam);
            Def = minOne(def);
        }
    }

    public struct MoveDesc
    {
        public string Name;
        public string Target;
        public string AttMod;
        public string DamMod;
        public string Status;
        public string Desc;

        public MoveDesc(string name, string target, string att, string dam, string status, string desc)
        {
            Name = name;
            Target = target;
            AttMod = att;
            DamMod = dam;
            Status = status;
            Desc = desc;
        }
    }

    //  void InitCBT(string text, bool d)
    //  {
    //      GameObject parent = gameObject;
    //      GameObject prefab = Resources.Load("Prefabs/CBT") as GameObject;
    //      GameObject temp = Instantiate(prefab, parent.transform.position, Quaternion.identity, parent.transform);
    //
    //      temp.GetComponent<Text>().text = text;
    //
    //      if (d)
    //      {
    //          temp.GetComponent<Text>().color = new Color(255, 0, 0);
    //      } else
    //      {
    //          temp.GetComponent<Text>().color = new Color(0, 255, 0);
    //      }
    //
    //      temp.GetComponent<Animator>().SetTrigger("Hit");
    //      Destroy(temp.gameObject, 2);
    //  }

    //Vector3 originalPosition;
    //Vector3 destination;
    //bool needsMovement = false;
    //float speed = 5f;
    //GameObject parent;
    //
    //void Update()
    //{
    //
    //    if (Friendly)
    //        parent = GameObject.Find("Players");
    //    else
    //        parent = GameObject.Find("Enemies");
    //    originalPosition = parent.transform.position + new Vector3(locPosx, locPosy, locPosz);
    //    if (needsMovement)
    //    {
    //        destination = parent.transform.position + new Vector3(locPosx, locPosy, 4f);
    //        needsMovement = false;
    //    }
    //    if(!isTurn)
    //        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
    //    if (Vector3.Distance(transform.position, destination) < 0.001f)
    //    {
    //        destination = originalPosition;
    //    }
    //}
}
