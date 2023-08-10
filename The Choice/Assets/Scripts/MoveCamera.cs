using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveCamera : MonoBehaviour
{
    public Camera cam;

    public Vector3 upBy;
    public Vector3 downBy;
    public Vector3 leftBy;
    public Vector3 rightBy;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        
    }

    public void moveRight()
    {
        cam.transform.position += rightBy;
    }

    public void moveLeft() 
    {
        cam.transform.position += leftBy;
    }

    public void moveUp()
    {        
        cam.transform.position += upBy;
    }

    public void moveDown()
    {
        cam.transform.position += downBy;
    }

    public void OddMove(Vector3 pos)
    {
        cam.transform.position += pos;
    }
}
