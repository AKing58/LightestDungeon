using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class InfoScript : MonoBehaviour
{
    public Text infotxt;
    public StringBuilder info;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        info = new StringBuilder("Classes:\n");
        for(int i = 0; i < BattleScript.playerList.Count; i++)
        {
            info.Append(BattleScript.playerList[i].Name + "\n");
            info.Append(BattleScript.playerList[i].Classname + "\n");
            info.Append(BattleScript.playerList[i].Health + "\n");
            if(i != BattleScript.playerList.Count - 1)
                info.Append("-------------\n");
        }
        infotxt.text = info.ToString();
    }
}
