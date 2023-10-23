using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WiresScript : MonoBehaviour
{
    public VideoPlay videoPlay;
    public AreaInhibiter areaInhibiter;
    public GameObject environment;
    public List<GameObject> wires;
    public List<bool> hasWon;

    [SerializeField] private int wiresActive;
    private bool progressed1;
    private bool progressed2;
    private bool progressed3;

    public Button btnPressed;
    public AudioSource error;

    public List<GameObject> completeWires1;
    public List<GameObject> completeWires2;
    public List<GameObject> completeWires3;

    public GameObject wires1;
    public GameObject wires2;
    public GameObject wires3;

    public textScript textScript;

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
            if (!progressed1)
            {
                videoPlay.unlockCertainVideo(5);
                wires1.SetActive(false);
                textScript.StartCoroutine(textScript.displayText("Oh, a colour code."));
                progressed1 = true;
            }
        }
        if (hasWon[1])
        {
            if(!progressed2)
            {
                areaInhibiter.areaIndex++;
                wires2.SetActive(false);
                textScript.StartCoroutine(textScript.displayText("Hey, a key."));
                progressed2 = true;
            }
        }
        if (hasWon[2])
        {
            if (!progressed3)
            {
                videoPlay.unlockCertainVideo(2);
                wires3.SetActive(false);
                textScript.StartCoroutine(textScript.displayText("Oh, a colour code."));
                progressed3 = true;
            }
        }
    }


    public void checkAndCompare(Button btn)
    {
        if(btnPressed == null)
        {
            btnPressed = btn;
        }
        else if(btn.name == btnPressed.name) 
        { 
            //correct
            switch (wiresActive)
            {
                case 0:
                    foreach (GameObject g in completeWires1)
                    {
                        if(btn.name == g.name)
                        {
                            g.SetActive(true) ;
                            btnPressed = null;
                        }
                    }
                    checkIfWin(completeWires1);
                    break;
                case 1:
                    foreach (GameObject g in completeWires2)
                    {
                        if (btn.name == g.name)
                        {
                            g.SetActive(true);
                            btnPressed = null;
                        }
                    }
                    checkIfWin(completeWires2);
                    break;
                case 2:
                    foreach (GameObject g in completeWires3)
                    {
                        if (btn.name == g.name)
                        {
                            g.SetActive(true);
                            btnPressed = null;
                        }
                    }
                    checkIfWin(completeWires3);
                    break;
            }
        }
        else
        {
            btnPressed = null;
            error.Play();
        }
    }

    public void checkIfWin(List<GameObject> wiresList)
    {
        foreach(GameObject g in wiresList)
        {
            if(!g.activeSelf)
            {
                return;
            }
        }
        win();
    }
}
