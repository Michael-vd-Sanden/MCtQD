using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryptexScript : MonoBehaviour
{
    public GameObject environment;
    public VideoPlay videoPlay;
    public AreaInhibiter areaInhibiter;
    public GameObject cryptex1;

    public bool complete1;

    public void start1()
    {
        if (!complete1)
        { 
            cryptex1.SetActive(true);
            environment.SetActive(false);
        }
    }

    public void win1()
    {
        cryptex1.SetActive(false);
        complete1 = true;
        areaInhibiter.areaIndex++;
        videoPlay.knowsCode[1] = true;
        environment.SetActive(true);
    }
}
