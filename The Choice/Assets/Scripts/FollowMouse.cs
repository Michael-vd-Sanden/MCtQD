using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public bool allowedToMove;
    public RectTransform MovingObject;
    public Camera cam;

    private void Update()
    {
        if(allowedToMove && MovingObject != null) 
        { 
            MoveObject();
        }
    }

    public void MoveObject()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = cam.nearClipPlane;
        MovingObject.position = cam.ScreenToWorldPoint(pos);

        if(Input.GetMouseButtonDown(0)) 
        {
            toggleMove(MovingObject);
        }
    }

    public void toggleMove(RectTransform r)
    {
        allowedToMove = !allowedToMove;
        if(allowedToMove) 
        { 
            MovingObject = r;
        }
        else
        {
            Vector3 pos = Input.mousePosition;
            pos.z = 1000;
            MovingObject.position = cam.ScreenToWorldPoint(pos);
            MovingObject = null;
        }
    }
}
