using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfoPanelScript : MonoBehaviour
{
    public BattleScript thisBattle;
    public Text ClassTxt;
    public Text NameTxt;
    public Text HPTxt;
    public Text AttackTxt;
    public Text DefenceTxt;

    public int panelNo;
    
    // Start is called before the first frame update
    void Start()
    {
        //panelNo = (int)System.Char.GetNumericValue(gameObject.name[gameObject.name.Length - 1])-1;
        panelNo--;
        if (BattleScript.instance == null)
            Instantiate(thisBattle);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(panelNo < thisBattle.playerList.Count)
        {
            ClassTxt.text = thisBattle.playerList[panelNo].ClassType.ToString();
            NameTxt.text = thisBattle.playerList[panelNo].Name;
            HPTxt.text = "HP: " + thisBattle.playerList[panelNo].Health.ToString();
            AttackTxt.text = "Attack: " + thisBattle.playerList[panelNo].Attack.ToString();
            DefenceTxt.text = "Defence: " + thisBattle.playerList[panelNo].Defence.ToString();
        }
    }
}
