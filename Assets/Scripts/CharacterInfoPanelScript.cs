using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfoPanelScript : MonoBehaviour
{
    public DungeonManager thisDungeon;
    public Text ClassTxt;
    public Text NameTxt;
    public Text HPTxt;
    public Text AttackTxt;
    public Text DefenceTxt;
    public GameObject SkillPanel;

    public int panelNo;
    
    // Start is called before the first frame update
    void Start()
    {
        //panelNo = (int)System.Char.GetNumericValue(gameObject.name[gameObject.name.Length - 1])-1;
        panelNo--;
        if (DungeonManager.instance == null)
            Instantiate(thisDungeon);
        SkillPanel = transform.Find("SkillPanel").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(panelNo < thisDungeon.playerList.Count)
        {
            ClassTxt.text = thisDungeon.playerList[panelNo].ClassType.ToString();
            NameTxt.text = thisDungeon.playerList[panelNo].Name;
            HPTxt.text = "HP: " + thisDungeon.playerList[panelNo].Health.ToString();
            AttackTxt.text = "Attack: " + thisDungeon.playerList[panelNo].Attack.ToString();
            DefenceTxt.text = "Defence: " + thisDungeon.playerList[panelNo].Defence.ToString();
            if (thisDungeon.playerList[panelNo].isTurn)
            {
                SkillPanel.SetActive(true);
            }
            else
            {
                SkillPanel.SetActive(false);
            }
        }

        
    }
}
