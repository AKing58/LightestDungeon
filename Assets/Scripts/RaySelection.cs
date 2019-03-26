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

            //GameObject g= hit.collider.gameObject;
            if (Input.GetMouseButtonDown(0) && !hit.collider.name.ToLower().Contains("ground"))
            {
                if (GameObject.Find("DungeonManager").GetComponent<BattleManager>()!= null)
                {
                    BattleManager tempBattle = GameObject.Find("DungeonManager").GetComponent<BattleManager>();
                    tempBattle.turnOrder[tempBattle.turnNo].doMove(hit.collider.gameObject.GetComponent<Entity>());
                }
            }
        }
        
    }
}
