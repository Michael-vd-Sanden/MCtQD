using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaInhibiter : MonoBehaviour
{
    public int areaIndex;

    public GameObject cryptex;
    public GameObject kastje1;
    public GameObject hallwayDoor;
    public GameObject showerDoor;
    public GameObject keukenDoor;
    public GameObject kastje2;

    private void Start()
    {
        areaIndex = 0;
        cryptex.SetActive(false);
        kastje1.SetActive(false);
        hallwayDoor.SetActive(false);
        showerDoor.SetActive(false);
        keukenDoor.SetActive(false);
        kastje2.SetActive(false);
    }

    private void Update()
    {
        checkAreaState();
    }

    public void checkAreaState()
    {
        switch (areaIndex) 
        {
            case 0:
                //bedroom only, cryptex & kastje1 not active
                break;
            case 1:
                //cryptex active
                cryptex.SetActive(true);
                break;
            case 2:
                //+ hallway, shower not active
                hallwayDoor.SetActive(true);
                break;
            case 3:
                //kastje1 active
                kastje1 .SetActive(true);
                break;
            case 4:
                //+ keuken, kastje 2 not active
                keukenDoor.SetActive(true);
                break;
            case 5:
                //douce active
                showerDoor.SetActive(true);
                break;
            case 6:
                //kastje 2 active
                kastje2.SetActive(true);
                break;
            case 7:
                //bedroom pillow only
                kastje1.SetActive(false);
                hallwayDoor.SetActive(false);
                break;
        }
    }
}
