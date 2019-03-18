using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class InfoScript : MonoBehaviour
{
    public Text infotxt;
    public StringBuilder info;
    public DungeonManager thisDungeon;
    // Start is called before the first frame update
    void Start()
    {
        if (DungeonManager.instance == null)
            Instantiate(thisDungeon);
    }

    // Update is called once per frame
    void Update()
    {
        info = new StringBuilder("Party:\n");
        for(int i = 0; i < thisDungeon.playerList.Count; i++)
        {
            info.Append(thisDungeon.playerList[i].Name + "\n");
            info.Append(thisDungeon.playerList[i].ClassType.ToString() + "\n");
            info.Append("HP: " + thisDungeon.playerList[i].Health + "\n");
            info.Append("Att: " + thisDungeon.playerList[i].Attack + "\n");
            info.Append("Def: " + thisDungeon.playerList[i].Defence + "\n");
            if (i != thisDungeon.playerList.Count - 1)
                info.Append("-------------\n");
        }
        infotxt.text = info.ToString();
    }
}
