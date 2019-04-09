using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class that sets the player party after inputting the values into the info fields
/// Created by: Adam
/// </summary>
public class SetParty : MonoBehaviour
{
    public GameObject nameField1;
    public GameObject nameField2;
    public GameObject nameField3;
    public GameObject nameField4;

    public GameObject dropdownClass1;
    public GameObject dropdownClass2;
    public GameObject dropdownClass3;
    public GameObject dropdownClass4;

    public GameObject partyWindow;

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

    }

    //Takes the inputs on the Party Select Screen and creates a party.
    public void lockInParty()
    {
        GameObject playerPreFab;
        GameObject playerObject;
        GameObject parent = GameObject.Find("Players");
        Entity thisPlayer;

        // Creates the first player object, setting name, prefab, and class type
        playerPreFab = Resources.Load("Prefabs/" + dropdownClass1.transform.Find("Label").GetComponent<Text>().text) as GameObject;
        playerObject = Instantiate(playerPreFab, parent.transform.position + new Vector3(thisDungeon.position[0], 0, -1.5f), Quaternion.identity);
        playerObject.transform.parent = parent.transform;
        parseClassName(playerObject, dropdownClass1.transform.Find("Label").GetComponent<Text>().text, nameField1.transform.Find("Text").GetComponent<Text>().text);
        thisPlayer = playerObject.GetComponent<Entity>();
        thisDungeon.playerList.Add(thisPlayer);
        GameObject.Find("UI/LeftPanel/CharacterInfoPanel1").GetComponent<CharacterInfoPanelScript>().thisEntity = thisPlayer;

        // Creates the second player object, setting name, prefab, and class type
        playerPreFab = Resources.Load("Prefabs/" + dropdownClass2.transform.Find("Label").GetComponent<Text>().text) as GameObject;
        playerObject = Instantiate(playerPreFab, parent.transform.position + new Vector3(thisDungeon.position[1], 0, -1.5f), Quaternion.identity);
        playerObject.transform.parent = parent.transform;
        parseClassName(playerObject, dropdownClass2.transform.Find("Label").GetComponent<Text>().text, nameField2.transform.Find("Text").GetComponent<Text>().text);
        thisPlayer = playerObject.GetComponent<Entity>();
        thisDungeon.playerList.Add(thisPlayer);
        GameObject.Find("UI/LeftPanel/CharacterInfoPanel2").GetComponent<CharacterInfoPanelScript>().thisEntity = thisPlayer;

        // Creates the third player object, setting name, prefab, and class type
        playerPreFab = Resources.Load("Prefabs/" + dropdownClass3.transform.Find("Label").GetComponent<Text>().text) as GameObject;
        playerObject = Instantiate(playerPreFab, parent.transform.position + new Vector3(thisDungeon.position[2], 0, -1.5f), Quaternion.identity);
        playerObject.transform.parent = parent.transform;
        parseClassName(playerObject, dropdownClass3.transform.Find("Label").GetComponent<Text>().text, nameField3.transform.Find("Text").GetComponent<Text>().text);
        thisPlayer = playerObject.GetComponent<Entity>();
        thisDungeon.playerList.Add(thisPlayer);
        GameObject.Find("UI/LeftPanel/CharacterInfoPanel3").GetComponent<CharacterInfoPanelScript>().thisEntity = thisPlayer;

        // Creates the fourth player object, setting name, prefab, and class type
        playerPreFab = Resources.Load("Prefabs/" + dropdownClass4.transform.Find("Label").GetComponent<Text>().text) as GameObject;
        playerObject = Instantiate(playerPreFab, parent.transform.position + new Vector3(thisDungeon.position[3], 0, -1.5f), Quaternion.identity);
        playerObject.transform.parent = parent.transform;
        parseClassName(playerObject, dropdownClass4.transform.Find("Label").GetComponent<Text>().text, nameField4.transform.Find("Text").GetComponent<Text>().text);
        thisPlayer = playerObject.GetComponent<Entity>();
        thisDungeon.playerList.Add(thisPlayer);
        GameObject.Find("UI/LeftPanel/CharacterInfoPanel4").GetComponent<CharacterInfoPanelScript>().thisEntity = thisPlayer;


        attachMovement();
        partyWindow.SetActive(false);
    }

    //Creates a default party
    public void defaultParty()
    {
        GameObject playerPreFab;
        GameObject playerObject;
        GameObject parent = GameObject.Find("Players");
        Entity thisPlayer;

        // Creates the first player object, setting name, prefab, and class type
        playerPreFab = Resources.Load("Prefabs/Knight") as GameObject;
        playerObject = Instantiate(playerPreFab, parent.transform.position + new Vector3(thisDungeon.position[0], 0, -1.5f), Quaternion.identity);
        playerObject.transform.parent = parent.transform;
        parseClassName(playerObject, "Knight", "Reynauld");
        thisPlayer = playerObject.GetComponent<Entity>();
        thisDungeon.playerList.Add(thisPlayer);
        GameObject.Find("UI/LeftPanel/CharacterInfoPanel1").GetComponent<CharacterInfoPanelScript>().thisEntity = thisPlayer;



        // Creates the second player object, setting name, prefab, and class type
        playerPreFab = Resources.Load("Prefabs/Rogue") as GameObject;
        playerObject = Instantiate(playerPreFab, parent.transform.position + new Vector3(thisDungeon.position[1], 0, -1.5f), Quaternion.identity);
        playerObject.transform.parent = parent.transform;
        parseClassName(playerObject, "Rogue", "Dismas");
        thisPlayer = playerObject.GetComponent<Entity>();
        thisDungeon.playerList.Add(thisPlayer);
        GameObject.Find("UI/LeftPanel/CharacterInfoPanel2").GetComponent<CharacterInfoPanelScript>().thisEntity = thisPlayer;

        // Creates the third player object, setting name, prefab, and class type
        playerPreFab = Resources.Load("Prefabs/Cleric") as GameObject;
        playerObject = Instantiate(playerPreFab, parent.transform.position + new Vector3(thisDungeon.position[2], 0, -1.5f), Quaternion.identity);
        playerObject.transform.parent = parent.transform;
        parseClassName(playerObject, "Cleric", "Tyrande");
        thisPlayer = playerObject.GetComponent<Entity>();
        thisDungeon.playerList.Add(thisPlayer);
        GameObject.Find("UI/LeftPanel/CharacterInfoPanel3").GetComponent<CharacterInfoPanelScript>().thisEntity = thisPlayer;

        // Creates the fourth player object, setting name, prefab, and class type
        playerPreFab = Resources.Load("Prefabs/Mage") as GameObject;
        playerObject = Instantiate(playerPreFab, parent.transform.position + new Vector3(thisDungeon.position[3], 0, -1.5f), Quaternion.identity);
        playerObject.transform.parent = parent.transform;
        parseClassName(playerObject, "Mage", "Blue");
        thisPlayer = playerObject.GetComponent<Entity>();
        thisDungeon.playerList.Add(thisPlayer);
        GameObject.Find("UI/LeftPanel/CharacterInfoPanel4").GetComponent<CharacterInfoPanelScript>().thisEntity = thisPlayer;


        attachMovement();
        partyWindow.SetActive(false);
    }

    /// <summary>
    /// Creates a class component depending on the class name input
    /// </summary>
    /// <param name="g"></param>
    /// <param name="className"></param>
    /// <param name="name"></param>
    public void parseClassName(GameObject g, string className, string name)
    {
        if(className == "Knight")
        {
            Knight k = g.AddComponent<Knight>() as Knight;
            k.init(name);
        }
        else if(className == "Rogue")
        {
            Rogue r = g.AddComponent<Rogue>() as Rogue;
            r.init(name);
        }
        else if(className == "Cleric")
        {
            Cleric c = g.AddComponent<Cleric>() as Cleric;
            c.init(name);
        }
        else if(className == "Mage")
        {
            Mage m = g.AddComponent<Mage>() as Mage;
            m.init(name);
        }
        else
        {
            Knight k = g.AddComponent<Knight>() as Knight;
            k.init(name);
        }
        
    }

    /// <summary>
    /// Method that creates the movement button on the UI
    /// </summary>
    public void attachMovement()
    {
        GameObject movementButton;
        Button moveBtn;
        for (int i=0; i <thisDungeon.playerList.Count; i++)
        {
            movementButton = GameObject.Find("UI/LeftPanel/CharacterInfoPanel" + (i + 1) + "/SkillPanel/SkillBtn6");
            moveBtn = movementButton.GetComponent<Button>();
            moveBtn.onClick.AddListener(thisDungeon.playerList[i].switchPosition);
        }
    }
}
