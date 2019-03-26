using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    /// <summary>
    /// Displays the location of the game object
    /// Currently used for debugging purposes
    /// </summary>
    public void displayLocation()
    {
        Debug.Log("hello" + GameObject.Find("Players").transform.GetChild(0).transform.localPosition.x + GameObject.Find("Players").transform.GetChild(0).transform.localPosition.y);
        for(int i = 0; i < GameObject.Find("Players").transform.childCount ; i++)
            Debug.Log("hello" + GameObject.Find("Players").transform.GetChild(i).transform.name);
    }
}
