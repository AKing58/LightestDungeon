using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        //thisBattle.addPlayer(parseClassType(dropdownClass1.transform.Find("Label").GetComponent<Text>().text, nameField1.transform.Find("Text").GetComponent<Text>().text));
        playerPreFab = Resources.Load("Prefabs/" + dropdownClass1.transform.Find("Label").GetComponent<Text>().text) as GameObject;
        playerObject = Instantiate(playerPreFab, parent.transform.position + new Vector3(-4.5F, 0, 0), Quaternion.identity);
        playerObject.transform.parent = parent.transform;
        thisPlayer = playerObject.GetComponent<Entity>();
        thisPlayer.parseClassName(dropdownClass1.transform.Find("Label").GetComponent<Text>().text, nameField1.transform.Find("Text").GetComponent<Text>().text);
        thisDungeon.playerList.Add(thisPlayer);

        //thisBattle.addPlayer(parseClassType(dropdownClass2.transform.Find("Label").GetComponent<Text>().text, nameField2.transform.Find("Text").GetComponent<Text>().text));
        playerPreFab = Resources.Load("Prefabs/" + dropdownClass2.transform.Find("Label").GetComponent<Text>().text) as GameObject;
        playerObject = Instantiate(playerPreFab, parent.transform.position + new Vector3(-1.5F, 0, 0), Quaternion.identity);
        playerObject.transform.parent = parent.transform;
        thisPlayer = playerObject.GetComponent<Entity>();
        thisPlayer.parseClassName(dropdownClass2.transform.Find("Label").GetComponent<Text>().text, nameField2.transform.Find("Text").GetComponent<Text>().text);
        thisDungeon.playerList.Add(thisPlayer);

        //thisBattle.addPlayer(parseClassType(dropdownClass3.transform.Find("Label").GetComponent<Text>().text, nameField3.transform.Find("Text").GetComponent<Text>().text));
        playerPreFab = Resources.Load("Prefabs/" + dropdownClass3.transform.Find("Label").GetComponent<Text>().text) as GameObject;
        playerObject = Instantiate(playerPreFab, parent.transform.position + new Vector3(1.5F, 0, 0), Quaternion.identity);
        playerObject.transform.parent = parent.transform;
        thisPlayer = playerObject.GetComponent<Entity>();
        thisPlayer.parseClassName(dropdownClass3.transform.Find("Label").GetComponent<Text>().text, nameField3.transform.Find("Text").GetComponent<Text>().text);
        thisDungeon.playerList.Add(thisPlayer);

        //thisBattle.addPlayer(parseClassType(dropdownClass4.transform.Find("Label").GetComponent<Text>().text, nameField4.transform.Find("Text").GetComponent<Text>().text));
        playerPreFab = Resources.Load("Prefabs/" + dropdownClass4.transform.Find("Label").GetComponent<Text>().text) as GameObject;
        playerObject = Instantiate(playerPreFab, parent.transform.position + new Vector3(4.5F, 0, 0), Quaternion.identity);
        playerObject.transform.parent = parent.transform;
        thisPlayer = playerObject.GetComponent<Entity>();
        thisPlayer.parseClassName(dropdownClass4.transform.Find("Label").GetComponent<Text>().text, nameField4.transform.Find("Text").GetComponent<Text>().text);
        thisDungeon.playerList.Add(thisPlayer);

        attachMovement();
        partyWindow.SetActive(false);
    }

    



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
