using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowsEnabled : MonoBehaviour
{
    public bool isPanelActive;
    public MoveCamera moveCamera;

    public bool UpAllowed;
    public bool DownAllowed;
    public bool LeftAllowed;
    public bool RightAllowed;

    public GameObject btnUp;
    public GameObject btnDown;
    public GameObject btnLeft;
    public GameObject btnRight;

    public Vector3 moveUpBy;
    public Vector3 moveDownBy;
    public Vector3 moveLeftBy;
    public Vector3 moveRightBy;

    void Start()
    {
        
    }

    void Update()
    {
        if(isPanelActive) 
        {
            moveCamera.upBy = moveUpBy;
            moveCamera.downBy = moveDownBy;
            moveCamera.leftBy = moveLeftBy;
            moveCamera.rightBy = moveRightBy;

            if (UpAllowed) { btnUp.SetActive(true); }
            else { btnUp.SetActive(false); }

            if (DownAllowed) { btnDown.SetActive(true); }
            else { btnDown.SetActive(false); }

            if (LeftAllowed) { btnLeft.SetActive(true); }
            else { btnLeft.SetActive(false); }

            if (RightAllowed) { btnRight.SetActive(true); }
            else { btnRight.SetActive(false); }
        }
    }

    private void OnBecameVisible()
    {
        isPanelActive = true;
    }

    private void OnBecameInvisible() 
    { 
        isPanelActive = false;
    }
}
