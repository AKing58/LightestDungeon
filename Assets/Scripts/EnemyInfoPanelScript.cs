using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyInfoPanelScript : MonoBehaviour
{
    public DungeonManager thisDungeon;
    public Text NameTxt;
    public Text AttackTxt;
    public Text HealthTxt;

    public int panelNo;
    public Entity thisEntity;
    // Start is called before the first frame update
    void Start()
    {
        panelNo--;
    }

    // Update is called once per frame
    void Update()
    {
        if (thisDungeon.curBattle != null && panelNo < thisDungeon.curBattle.enemyList.Count)
        {
            thisEntity = thisDungeon.curBattle.enemyList[panelNo];
            NameTxt.text = thisDungeon.curBattle.enemyList[panelNo].Name;
            HealthTxt.text = thisDungeon.curBattle.enemyList[panelNo].Health.ToString();
            AttackTxt.text = thisDungeon.curBattle.enemyList[panelNo].Attack.ToString();
            thisEntity.myPanel = this.gameObject;
        }
    }

    public void setPanelActive(bool state)
    {
        this.gameObject.SetActive(state);
    }
}
