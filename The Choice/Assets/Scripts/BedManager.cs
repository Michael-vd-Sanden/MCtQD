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
    [SerializeField] private int bedstate;

    public GameObject choiceScreen;
    public GameObject environment;
    public AudioSource leave;
    public AudioSource die;
    public GameObject blackScreen;

    private int chosenFate;

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
                break;
            case 1:
                areaInhibiter.areaIndex++;
                videoPlay.knowsCode[8] = true;
                bedstate++;
                break;
            case 2:
                finishGame(fate);
                break;
        }
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
        leave.Play();
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene("MainMenu");
    }

    public IEnumerator unsure()
    {
        SceneManager.LoadScene("SampleScene");
        yield return new WaitForSecondsRealtime(6f);
        SceneManager.LoadScene("MainMenu");
    }

    public IEnumerator unworty()
    {
        blackScreen.SetActive(true);
        die.Play();
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene("MainMenu");
    }

    public void notAllowedBed()
    {
        Debug.Log("not enough videos collected");
    }
}
