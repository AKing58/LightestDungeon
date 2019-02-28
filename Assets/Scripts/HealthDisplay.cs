using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    private static int health = 5;
    public Text healthText;

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + health;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            health--;
        }
    }

    public static void healthChange(int change)
    {
        health += change;
    }
}
