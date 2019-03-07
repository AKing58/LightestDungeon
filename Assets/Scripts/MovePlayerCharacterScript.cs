using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerCharacterScript : MonoBehaviour
{

    public string entityPosition;

    public float locPosx;
    public float locPosy;
    public float locPosz;


    // Start is called before the first frame update
    void Start()
    {
        entityPosition = "front";
        locPosx = transform.localPosition.x;
        locPosy = transform.localPosition.y;
        locPosz = transform.localPosition.z;

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void moveCharacter()
    {
        if(entityPosition == "front")
        {
            transform.localPosition = new Vector3(locPosx, locPosy, locPosz-(float)1.5);
            entityPosition = "back";
        }
        else
        {
            transform.localPosition = new Vector3(locPosx, locPosy, locPosz);
            entityPosition = "front";
        }
        
    }
}
