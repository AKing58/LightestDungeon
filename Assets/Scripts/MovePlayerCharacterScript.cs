using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerCharacterScript : MonoBehaviour
{
    public Entity entity;

    public float locPosx;
    public float locPosy;
    public float locPosz;

    // Start is called before the first frame update
    void Start()
    {
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
        if(entity.CurPosition == Entity.Position.Front)
        {
            transform.localPosition = new Vector3(locPosx, locPosy, locPosz-(float)1.5);
            entity.CurPosition = Entity.Position.Back;
        }
        else
        {
            transform.localPosition = new Vector3(locPosx, locPosy, locPosz);
            entity.CurPosition = Entity.Position.Front;
        }
        
    }
}
