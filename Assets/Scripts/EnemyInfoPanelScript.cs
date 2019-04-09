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

    public Entity thisEntity;

    // Start is called before the first frame update
    void Start()
    {
        panelNo--;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("DungeonManager").GetComponent<DungeonManager>().curBattle != null)
        {
            NameTxt.text = thisEntity.Name;
            HealthTxt.text = "HP: " + thisEntity.Health.ToString();
            AttackTxt.text = "Attack: " + thisEntity.Attack.ToString();
            thisEntity.myPanel = this.gameObject;
        }
    }
}
