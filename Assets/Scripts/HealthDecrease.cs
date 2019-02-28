using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDecrease : MonoBehaviour
{
    public void healthDown()
    {
        HealthDisplay.healthChange(-1);
    }
}
