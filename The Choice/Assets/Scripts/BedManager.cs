using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BedManager : MonoBehaviour
{
    //mag pas naar bed als alle video dingen van die act zijn gezien
    //act 1: 1,2,8,6 -> 0,1,7,5
    //act 2: 7,10,4 -> 6,9,3
    //act3: 9,5,3 -> 8,4,2

    public VideoPlay videoPlay;
    public AreaInhibiter areaInhibiter;
    public textScript textScript;
    [SerializeField] private int bedstate;

    public GameObject choiceScreen;
    public GameObject environment;
    public AudioSource leave;
    public AudioSource die;
    public GameObject blackScreen;

    private int chosenFate;
    public LogsManager logmanager;

    public GameObject acts;
    public GameObject act1Text;
    public GameObject act2Text;
    public GameObject act3Text;

    private bool playedYawn1;
    private bool playedYawn2;
    private bool playedYawn3;

    private void Start()
    {
        StartCoroutine(act1());
    }

    private void Update()
    {
        switch (bedstate)
        {
            case 0:
                if (videoPlay.hasSeenVideo[0] && videoPlay.hasSeenVideo[1] && videoPlay.hasSeenVideo[7] && videoPlay.hasSeenVideo[5] && !playedYawn1)
                { textScript.StartCoroutine(textScript.displayText("*yawn*"));      playedYawn1 = true; }
                break;
            case 1:
                if (videoPlay.hasSeenVideo[6] && videoPlay.hasSeenVideo[9] && videoPlay.hasSeenVideo[3] && !playedYawn2)
                { textScript.StartCoroutine(textScript.displayText("*yawn*")); playedYawn2 = true; }
                break;
            case 2:
                if (videoPlay.hasSeenVideo[8] && videoPlay.hasSeenVideo[4] && videoPlay.hasSeenVideo[2] && !playedYawn3)
                { textScript.StartCoroutine(textScript.displayText("*yawn*")); playedYawn3 = true; }
                break;
        }
    }

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

    public void choose(int fate)
    {
        closeBed();
        switch (bedstate)
        {
            case 0:
                areaInhibiter.areaIndex++;
                videoPlay.knowsCode[6] = true;
                bedstate++;
                StartCoroutine(act2());
                break;
            case 1:
                areaInhibiter.areaIndex++;
                videoPlay.knowsCode[8] = true;
                bedstate++;
                StartCoroutine(act3());
                break;
            case 2:
                finishGame(fate);
                break;
        }
    }

    public IEnumerator act1()
    {
        acts.SetActive(true);
        act1Text.SetActive(true);
        environment.SetActive(false);
        yield return new WaitForSecondsRealtime(4f);
        acts.SetActive(false);
        act1Text.SetActive(false);
        environment.SetActive(true);
        logmanager.vPlayers[0].enabled = true;
    }

    public IEnumerator act2()
    {
        acts.SetActive(true);
        act2Text.SetActive(true);
        environment.SetActive(false);
        yield return new WaitForSecondsRealtime(4f);
        acts.SetActive(false);
        act2Text.SetActive(false);
        environment.SetActive(true);
        textScript.StartCoroutine(textScript.displayText("Oh, a colour code and a key."));
    }

    public IEnumerator act3()
    {
        acts.SetActive(true);
        act3Text.SetActive(true);
        environment.SetActive(false);
        yield return new WaitForSecondsRealtime(4f);
        acts.SetActive(false);
        act3Text.SetActive(false);
        environment.SetActive(true);
        textScript.StartCoroutine(textScript.displayText("Oh, a colour code and a key."));
    }

    public void finishGame(int fate)
    {
        switch(fate)
        {
            case 0: //worthy
                StartCoroutine(worty());
                break;
            case 1: //unsure
                StartCoroutine(unsure());
                break;
            case 2: //unworthy
                StartCoroutine(unworty());
                break;
        }
    }

    public IEnumerator worty()
    {
        blackScreen.SetActive(true);
        environment.SetActive(false);
        leave.Play();
        yield return new WaitForSecondsRealtime(6f);
        SceneManager.LoadScene("MainMenu");
    }

    public IEnumerator unsure()
    {
        logmanager.vPlayers[0].enabled = true;
        yield return new WaitForSecondsRealtime(8f);
        SceneManager.LoadScene("MainMenu");
    }

    public IEnumerator unworty()
    {
        blackScreen.SetActive(true);
        environment.SetActive(false);
        die.Play();
        yield return new WaitForSecondsRealtime(11f);
        SceneManager.LoadScene("MainMenu");
    }

    public void notAllowedBed()
    {
        textScript.StartCoroutine(textScript.displayText("I'm not tired yet."));
        Debug.Log("not enough videos collected");
    }
}
