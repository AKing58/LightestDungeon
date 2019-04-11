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
        skeletonCountTxt = transform.Find("Killed/Panel/LeftScore/SkeletonCount").GetComponent<Text>();
        zombieCountTxt = transform.Find("Killed/Panel/LeftScore/ZombieCount").GetComponent<Text>();
        orcCountTxt = transform.Find("Killed/Panel/LeftScore/OrcCount").GetComponent<Text>();
        orcBlueCountTxt = transform.Find("Killed/Panel/RightScore/BlueOrcCount").GetComponent<Text>();
        orcRedCountTxt = transform.Find("Killed/Panel/RightScore/RedOrcCount").GetComponent<Text>();
        minotaurCountTxt = transform.Find("Killed/Panel/RightScore/MinotaurCount").GetComponent<Text>();
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
        checkLevelUp();
        Debug.Log("Win Screen Activated");
    }

    public void battleLoseScreen()
    {
        DungeonManager thisDungeon = GameObject.Find("DungeonManager").GetComponent<DungeonManager>();
        gameObject.SetActive(true);
        skeletonCountTxt.text = "Skeletons: " + thisDungeon.skeletonDefeated;
        zombieCountTxt.text = "Zombies: " + thisDungeon.zombieDefeated;
        orcCountTxt.text = "Orcs: " + thisDungeon.orcDefeated;
        orcBlueCountTxt.text = "Blue Orcs: " + thisDungeon.orcBlueDefeated;
        orcRedCountTxt.text = "Red Orcs: " + thisDungeon.orcRedDefeated;
        minotaurCountTxt.text = "Minotaurs: " + thisDungeon.minotaurDefeated;
        Debug.Log("Lose Screen Activated");
    }

    private void checkLevelUp()
    {
        DungeonManager dm = GameObject.Find("DungeonManager").GetComponent<DungeonManager>();
        List<Entity> eList = dm.playerList;
        if(eList[0].Level - 1 < (dm.challengeRating / 8) && eList[0].Level <= 5)
        {
            foreach (Entity e in eList)
                e.levelUp();
        }
    }

    public void closeWinScreen()
    {
        gameObject.SetActive(false);
        GameObject.Find("DungeonManager").GetComponent<DungeonManager>().startBattle();
    }
}
