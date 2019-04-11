using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Sets the text and updates the score for each enemy killed
/// </summary>
public class ScoreScript : MonoBehaviour
{
    private Text orcCountTxt;
    private Text orcBlueCountTxt;
    private Text orcRedCountTxt;
    private Text skeletonCountTxt;
    private Text zombieCountTxt;
    private Text minotaurCountTxt;
    private Text cRTxt;

    private DungeonManager thisDungeon;
    // Start is called before the first frame update
    void Start()
    {
        thisDungeon = GameObject.Find("DungeonManager").GetComponent<DungeonManager>();
        skeletonCountTxt = GameObject.Find("UI/RightPanel/DungeonScore/Panel/Score/SkeletonCount").GetComponent<Text>();
        zombieCountTxt = GameObject.Find("UI/RightPanel/DungeonScore/Panel/Score/ZombieCount").GetComponent<Text>();
        orcCountTxt = GameObject.Find("UI/RightPanel/DungeonScore/Panel/Score/OrcCount").GetComponent<Text>();
        orcBlueCountTxt = GameObject.Find("UI/RightPanel/DungeonScore/Panel/Score/BlueOrcCount").GetComponent<Text>();
        orcRedCountTxt = GameObject.Find("UI/RightPanel/DungeonScore/Panel/Score/RedOrcCount").GetComponent<Text>();
        minotaurCountTxt = GameObject.Find("UI/RightPanel/DungeonScore/Panel/Score/MinotaurCount").GetComponent<Text>();
        cRTxt = GameObject.Find("UI/RightPanel/DungeonScore/ChallengeRating").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        skeletonCountTxt.text = "Skeletons: " + thisDungeon.skeletonDefeated; 
        zombieCountTxt.text = "Zombies: " + thisDungeon.zombieDefeated;
        orcCountTxt.text = "Orcs: " + thisDungeon.orcDefeated;
        orcBlueCountTxt.text = "Blue Orcs: " + thisDungeon.orcBlueDefeated;
        orcRedCountTxt.text = "Red Orcs: " + thisDungeon.orcRedDefeated;
        minotaurCountTxt.text = "Minotaurs: " + thisDungeon.minotaurDefeated;
        cRTxt.text = "Challenge Rating: " + thisDungeon.challengeRating;
    }
}
