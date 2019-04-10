using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleWinScreen : MonoBehaviour
{
    private Text orcCountTxt;
    private Text orcBlueCountTxt;
    private Text orcRedCountTxt;
    private Text skeletonCountTxt;
    private Text zombieCountTxt;
    private Text minotaurCountTxt;
    // Start is called before the first frame update
    void Awake()
    {
        skeletonCountTxt = GameObject.Find("UI/WinScreen/Killed/Panel/LeftScore/SkeletonCount").GetComponent<Text>();
        zombieCountTxt = GameObject.Find("UI/WinScreen/Killed/Panel/LeftScore/ZombieCount").GetComponent<Text>();
        orcCountTxt = GameObject.Find("UI/WinScreen/Killed/Panel/LeftScore/OrcCount").GetComponent<Text>();
        orcBlueCountTxt = GameObject.Find("UI/WinScreen/Killed/Panel/RightScore/BlueOrcCount").GetComponent<Text>();
        orcRedCountTxt = GameObject.Find("UI/WinScreen/Killed/Panel/RightScore/RedOrcCount").GetComponent<Text>();
        minotaurCountTxt = GameObject.Find("UI/WinScreen/Killed/Panel/RightScore/MinotaurCount").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void battleWonScreen(int skeleton, int zombie, int orc, int blueOrc, int redOrc, int minotaur)
    {
        gameObject.SetActive(true);
        skeletonCountTxt.text = "Skeletons: " + skeleton.ToString();
        zombieCountTxt.text = "Zombies: " + zombie.ToString();
        orcCountTxt.text = "Orcs: " + orc.ToString();
        orcBlueCountTxt.text = "Blue Orcs: " + blueOrc.ToString();
        orcRedCountTxt.text = "Red Orcs" + redOrc.ToString();
        minotaurCountTxt.text = "Minotaurs: " + minotaur.ToString();
        Debug.Log("Win Screen Activated");
    }

    public void closeWinScreen()
    {
        gameObject.SetActive(false);
        GameObject.Find("DungeonManager").GetComponent<DungeonManager>().startBattle();
    }
}
