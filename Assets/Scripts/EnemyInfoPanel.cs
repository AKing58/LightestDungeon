using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyInfoPanel : MonoBehaviour
{
    public BattleManager thisBattle;
    public Text NameTxt;
    public Text HPTxt;
    public Text AttackTxt;

    public int panelNo;
 
    // Start is called before the first frame update
    void Start()
    {
        panelNo--;
    }

    // Update is called once per frame
    void Update()
    {
        if(thisBattle != null && panelNo < thisBattle.enemyList.Count)
        {
            NameTxt.text = thisBattle.enemyList[panelNo].ClassType.ToString();
            HPTxt.text = "HP: " + thisBattle.enemyList[panelNo].Health.ToString();
            AttackTxt.text = "Attack: " + thisBattle.enemyList[panelNo].Attack.ToString();
        }
    }
}
