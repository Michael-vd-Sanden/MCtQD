using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedManager : MonoBehaviour
{
    //mag pas naar bed als alle video dingen van die act zijn gezien
    //act 1: 1,2,8,6 -> 0,1,7,5
    //act 2: 7,10,4 -> 6,9,3
    //act3: 9,5,3 -> 8,4,2

    public VideoPlay videoPlay;
    public AreaInhibiter areaInhibiter;
    [SerializeField] private int bedstate;

    public GameObject choiceScreen;
    public GameObject environment;

    public void checkIfAllowedBed()
    {
        switch (bedstate)
        {
            case 0:
                if (videoPlay.hasSeenVideo[0] && videoPlay.hasSeenVideo[1] && videoPlay.hasSeenVideo[7] && videoPlay.hasSeenVideo[5])
                { goToBed(); }
                else
                { notAllowedBed(); }
                break;
            case 1:
                if (videoPlay.hasSeenVideo[6] && videoPlay.hasSeenVideo[9] && videoPlay.hasSeenVideo[3])
                { goToBed(); }
                else
                { notAllowedBed(); }
                break;
            case 2:
                if (videoPlay.hasSeenVideo[8] && videoPlay.hasSeenVideo[4] && videoPlay.hasSeenVideo[2])
                { goToBed(); }
                else
                { notAllowedBed(); }
                break;
        }
    }

    public void goToBed()
    {
        choiceScreen.SetActive(true);
        environment.SetActive(false);
    }

    public void closeBed()
    {
        choiceScreen.SetActive(false);
        environment.SetActive(true);
    }

    public void choose()
    {
        closeBed();
        switch (bedstate)
        {
            case 0:
                areaInhibiter.areaIndex++;
                videoPlay.knowsCode[6] = true;
                bedstate++;
                break;
            case 1:
                areaInhibiter.areaIndex++;
                videoPlay.knowsCode[8] = true;
                bedstate++;
                break;
            case 2:
                Debug.Log("Finished game");
                break;
        }
    }

    public void notAllowedBed()
    {
        Debug.Log("not enough videos collected");
    }
}
