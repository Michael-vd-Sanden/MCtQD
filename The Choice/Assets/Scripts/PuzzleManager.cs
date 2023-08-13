using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public AreaInhibiter areaInhibiter;
    public VideoPlay videoPlay;
    public GameObject environment;
    public GameObject puzzle1;
    public GameObject puzzle2;

    private bool openedArea;

    private void Start()
    {
        openedArea = false;
    }

    public void togglePuzzle1()
    {
        puzzle1.SetActive(!puzzle1.activeSelf);
        if(puzzle1.activeSelf) 
        { 
            environment.SetActive(false) ;
        }
        else
        {
            environment.SetActive(true) ;
        }
    }

    public void togglePuzzle2()
    {
        puzzle2.SetActive(!puzzle2.activeSelf);
        if (puzzle2.activeSelf)
        {
            environment.SetActive(false);
        }
        else
        {
            environment.SetActive(true);
        }

        if(!openedArea)
        {
            areaInhibiter.areaIndex++;
            videoPlay.unlockCertainVideo(4);
            openedArea = true;
        }
    }
}
