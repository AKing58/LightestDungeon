using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaySelection : MonoBehaviour
{
    Camera cam;
    //public DungeonManager thisDungeon;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        //thisDungeon = DungeonManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                //hit.collider.gameObject.transform.Find("SelectionUI").gameObject;
            }
            
        }
        
    }
}
