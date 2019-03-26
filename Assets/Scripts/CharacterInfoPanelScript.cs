using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfoPanelScript : MonoBehaviour
{
    public enum SelectedSkill { MOVE1 = 1, MOVE2, MOVE3, MOVE4, MOVE5}
    public DungeonManager thisDungeon;
    public Text ClassTxt;
    public Text NameTxt;
    public Text HPTxt;
    public Text AttackTxt;
    public Text DefenceTxt;
    public GameObject SkillPanel;
    public SelectedSkill selectedSkill;

    public int panelNo;

    public Entity thisEntity;
    
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
            thisEntity = thisDungeon.playerList[panelNo];
            ClassTxt.text = thisEntity.ClassType.ToString();
            NameTxt.text = thisDungeon.playerList[panelNo].Name;
            HPTxt.text = "HP: " + thisDungeon.playerList[panelNo].Health.ToString();
            AttackTxt.text = "Attack: " + thisDungeon.playerList[panelNo].Attack.ToString();
            DefenceTxt.text = "Defence: " + thisDungeon.playerList[panelNo].Defence.ToString();
            thisEntity.myPanel = this.gameObject; 
        }
    }

    public void changeSelectedSkill(int newSkill)
    {
        selectedSkill = (SelectedSkill)newSkill;
        Debug.Log("Selected skill: " + newSkill);
    }

    public void setThisPanel(bool state)
    {
        this.gameObject.SetActive(state);
    }
}
