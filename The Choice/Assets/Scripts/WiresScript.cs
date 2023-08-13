using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiresScript : MonoBehaviour
{
    public VideoPlay videoPlay;
    public AreaInhibiter areaInhibiter;
    public GameObject environment;
    public List<GameObject> wires;
    public List<bool> hasWon;

    private int wiresActive;
    private bool progressed2;

    private void Start()
    {
        progressed2 = false;
    }

    public void startWires(int w)
    {
        if (!hasWon[w])
        {
            environment.SetActive(false);
            wires[w].SetActive(true);
            wiresActive = w;
        }
    }

    public void win()
    {
        environment.SetActive(true);
        wires[wiresActive].SetActive(false);
        hasWon[wiresActive] = true;
        checkUpdates();
    }

    public void checkUpdates()
    {
        if (hasWon[0])
        {
            videoPlay.unlockCertainVideo(5);
        }
        if (hasWon[1])
        {
            if(!progressed2)
            {
                areaInhibiter.areaIndex++;
                progressed2 = true;
            }
        }
        if (hasWon[2])
        {
            videoPlay.unlockCertainVideo(2);
        }
    }
}
