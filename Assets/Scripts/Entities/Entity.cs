using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Entity : MonoBehaviour{
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
    public int Speed { get; set; }
    
    public Position CurPosition { get; set; }
    public bool isTurn { get; set; }
    public Equipment[] Loadout { get; set; }

    public float locPosx;
    public float locPosy;
    public float locPosz;

    public GameObject myPanel;

    public void createEntity(string name, int lv, int hp, int att, int def, int speed)
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

    public virtual void init(string name) { }

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
    
    public void doTurn()
    {
        if(Friendly)
            myPanel.transform.Find("SkillPanel").gameObject.SetActive(true);
    }
    
    void OnMouseOver()
    {
        transform.Find("SelectionUI").gameObject.SetActive(true);
    }
    void OnMouseExit() 
    {
        transform.Find("SelectionUI").gameObject.SetActive(false);
    }

    public virtual void move1(Entity target)
    {
        Debug.Log("Move1");
    }

    public virtual void move2(Entity target)
    {
        Debug.Log("Move2");
    }

    public virtual void move3(Entity target)
    {
        Debug.Log("Move3");
    }

    public virtual void move4(Entity target)
    {
        Debug.Log("Move4");
    }

    public virtual void move5(Entity target)
    {
        Debug.Log("Move5");
    }

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
    public void didMove()
    {
        GameObject.Find("DungeonManager").GetComponent<BattleManager>().nextTurn();
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
