using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class SetPartyScript : MonoBehaviour
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
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    public GameObject[] gameObjects;
    private Material mat1;
    private Material mat2;
    private Material mat3;
    private Material mat4;

    public BattleScript thisBattle;
    // Start is called before the first frame update
    void Start()
    {
        if(BattleScript.instance == null)
            Instantiate(thisBattle);
        mat1 = Resources.Load<Material>("Assets/Resources/Textures/Materials/Knight");
        mat2 = Resources.Load<Material>("Assets/Resources/Textures/Materials/Rogue");
        mat3 = Resources.Load<Material>("Assets/Resources/Textures/Materials/Cleric");
        mat4 = Resources.Load<Material>("Assets/Resources/Textures/Materials/Mage");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Takes the inputs on the Party Select Screen and creates a party.
    public void lockInParty()
    {
        thisBattle.addPlayer(parseClassType(dropdownClass1.transform.Find("Label").GetComponent<Text>().text, nameField1.transform.Find("Text").GetComponent<Text>().text));
        thisBattle.addPlayer(parseClassType(dropdownClass2.transform.Find("Label").GetComponent<Text>().text, nameField2.transform.Find("Text").GetComponent<Text>().text));
        thisBattle.addPlayer(parseClassType(dropdownClass3.transform.Find("Label").GetComponent<Text>().text, nameField3.transform.Find("Text").GetComponent<Text>().text));
        thisBattle.addPlayer(parseClassType(dropdownClass4.transform.Find("Label").GetComponent<Text>().text, nameField4.transform.Find("Text").GetComponent<Text>().text));

        
        

        player1.name = thisBattle.playerList[0].Name;
        MeshRenderer myMeshRend = player1.GetComponent<MeshRenderer>();
        myMeshRend.material = Resources.Load<Material>("Assets/Resources/Textures/Materials/" + thisBattle.playerList[0].Classname);

        player2.name = thisBattle.playerList[1].Name;
        myMeshRend = player2.GetComponent<MeshRenderer>();
        myMeshRend.material = Resources.Load<Material>("Assets/Resources/Textures/Materials/" + thisBattle.playerList[1].Classname);

        player3.name = thisBattle.playerList[2].Name;
        myMeshRend = player3.GetComponent<MeshRenderer>();
        myMeshRend.material = Resources.Load<Material>("Assets/Resources/Textures/Materials/" + thisBattle.playerList[2].Classname);

        player4.name = thisBattle.playerList[3].Name;
        myMeshRend = player4.GetComponent<MeshRenderer>();
        myMeshRend.material = Resources.Load<Material>("Assets/Resources/Textures/Materials/" + thisBattle.playerList[3].Classname);

        //player1.name = thisBattle.playerList[0].Name;

        //player2.name = thisBattle.playerList[1].Name;

        //player3.name = thisBattle.playerList[2].Name;

        //player4.name = thisBattle.playerList[3].Name;



        partyWindow.SetActive(false);
    }

    public Entity parseClassType(string classType, string name)
    {
        
        switch (classType)
        {
            case "Knight":
                return (new Knight(name, 1, 10, 10, 10));
            case "Rogue":
                return (new Rogue(name, 1, 8, 14, 8));
            case "Cleric":
                return (new Cleric(name, 1, 10, 8, 14));
            case "Mage":
                return (new Mage(name, 1, 10, 12, 8));
            default:
                return (new Knight("Failed" , 1, 10, 10, 10));
        }
        
    }
}
