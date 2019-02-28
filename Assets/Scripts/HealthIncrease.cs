using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIncrease : MonoBehaviour
{
    public void healthUp()
    {
        HealthDisplay.healthChange(1);
    }
}
