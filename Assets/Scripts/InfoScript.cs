using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class InfoScript : MonoBehaviour
{
    public Text infotxt;
    public StringBuilder info;
    public BattleScript thisBattle;
    // Start is called before the first frame update
    void Start()
    {
        if (BattleScript.instance == null)
            Instantiate(thisBattle);
    }

    // Update is called once per frame
    void Update()
    {
        info = new StringBuilder("Party:\n");
        for(int i = 0; i < thisBattle.playerList.Count; i++)
        {
            info.Append(thisBattle.playerList[i].Name + "\n");
            info.Append(thisBattle.playerList[i].ClassType.ToString() + "\n");
            info.Append("HP: " + thisBattle.playerList[i].Health + "\n");
            info.Append("Att: " + thisBattle.playerList[i].Attack + "\n");
            info.Append("Def: " + thisBattle.playerList[i].Defence + "\n");
            if (i != thisBattle.playerList.Count - 1)
                info.Append("-------------\n");
        }
        infotxt.text = info.ToString();
    }
}
