﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaySelection : MonoBehaviour
{
    Camera cam;
    public BattleScript thisBattle;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        thisBattle = BattleScript.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.name.Contains("Player") ||
                    hit.collider.gameObject.name.Contains("Enemy")
                    )
                {
                    InfoDisplay.changeName(hit.collider.gameObject.name);
                    if (hit.collider.gameObject.name.Contains("Enemy")){
                        InfoDisplay.changeName(hit.collider.gameObject.name);
                    }
                }

            }
        }
    }
}
