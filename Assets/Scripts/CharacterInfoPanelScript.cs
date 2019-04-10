using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterInfoPanelScript : MonoBehaviour
{
    public enum SelectedSkill { MOVE1 = 1, MOVE2, MOVE3, MOVE4, MOVE5}
    public DungeonManager thisDungeon;
    public Text ClassTxt;
    public Text NameTxt;
    public Text HPTxt;
    public Text AttackTxt;
    public Text DamageTxt;
    public Text DefenceTxt;
    public GameObject SkillPanel;
    public SelectedSkill selectedSkill;

    public int panelNo;

    public Entity thisEntity;
    public GameObject toolTip;
    
    // Start is called before the first frame update
    void Start()
    {
        //panelNo = (int)System.Char.GetNumericValue(gameObject.name[gameObject.name.Length - 1])-1;
        panelNo--;
        if (DungeonManager.instance == null)
            Instantiate(thisDungeon);
        SkillPanel = transform.Find("SkillPanel").gameObject;
        selectedSkill = SelectedSkill.MOVE1;
    }

    // Update is called once per frame
    void Update()
    {
        if (panelNo < thisDungeon.playerList.Count)
        {
            //thisEntity = thisDungeon.playerList[panelNo];
            ClassTxt.text = thisEntity.ClassType.ToString();
            NameTxt.text = thisEntity.Name;
            if (thisEntity.StatusEffects["TempHealth"] > 0)
                HPTxt.text = "HP: " + thisEntity.Health.ToString() + "+(" + thisEntity.StatusEffects["TempHealth"] + ")" + "/" + thisEntity.Max_Health;
            else
                HPTxt.text = "HP: " + thisEntity.Health.ToString() + "/" + thisEntity.Max_Health;
            AttackTxt.text = "Attack: " + thisEntity.Attack.ToString();
            DamageTxt.text = "Damage: " + thisEntity.Damage[0].ToString() + "-" + thisEntity.Damage[1].ToString();
            DefenceTxt.text = "Defence: " + thisEntity.Defence.ToString();

            thisEntity.myPanel = this.gameObject;
        }
    }

    /// <summary>
    /// Method to change what skill is being selected
    /// </summary>
    /// <param name="newSkill"></param>
    public void changeSelectedSkill(int newSkill)
    {
        selectedSkill = (SelectedSkill)newSkill;
        Debug.Log("Selected skill: " + newSkill);
    }

    /// <summary>
    /// Method to set the game object panel to active
    /// </summary>
    /// <param name="state"></param>
    public void setThisPanel(bool state)
    {
        this.gameObject.SetActive(state);
    }


}
