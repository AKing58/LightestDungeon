using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoDisplay : MonoBehaviour
{
    private static string nameString;
    public Text infoText;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        nameString = "Unselected";
    }

    // Update is called once per frame
    void Update()
    {
        infoText.text = nameString;
    }

    public static void changeName(string input)
    {
        nameString = input;
    }
    
}
