using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class InfoScript : MonoBehaviour
{
    public Text infotxt;
    public StringBuilder info;
    private BattleScript thisBattle;
    // Start is called before the first frame update
    void Start()
    {
        thisBattle = BattleScript.instance;
    }

    // Update is called once per frame
    void Update()
    {
        info = new StringBuilder("Classes:\n");
        for(int i = 0; i < thisBattle.playerList.Count; i++)
        {
            info.Append(thisBattle.playerList[i].Name + "\n");
            info.Append(thisBattle.playerList[i].Classname + "\n");
            info.Append(thisBattle.playerList[i].Health + "\n");
            if(i != thisBattle.playerList.Count - 1)
                info.Append("-------------\n");
        }
        infotxt.text = info.ToString();
    }
}
