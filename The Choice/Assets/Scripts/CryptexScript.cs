using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryptexScript : MonoBehaviour
{
    public GameObject environment;
    public VideoPlay videoPlay;
    public AreaInhibiter areaInhibiter;
    public GameObject cryptex1;
    public GameObject cryptex2;

    public bool complete1;
    public bool complete2;

    public List<GameObject> symbolListRow1;
    public List<GameObject> symbolListRow2;
    public List<GameObject> symbolListRow3;
    public List<GameObject> symbolListRow4;
    public List<GameObject> symbolListRow5;
    public List<int> symbolRowIndex;

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

    public void start2()
    {
        if (!complete2)
        {
            cryptex2.SetActive(true);
            environment.SetActive(false);
        }
    }

    public void win2()
    {
        cryptex2.SetActive(false);
        complete2 = true;
        videoPlay.knowsCode[3] = true;
        environment.SetActive(true);
    }



    public void scrollUp(int row)
    {
        if (symbolRowIndex[row] < 4)
        {
            symbolRowIndex[row]++;
        }
        updateCryptex();
    }

    public void scrollDown(int row)
    {
        if (symbolRowIndex[row] != 0)
        {
            symbolRowIndex[row]--;
        }
        updateCryptex();
    }

    public void updateCryptex()
    {
        foreach(GameObject g in symbolListRow1)
        {
            g.SetActive(false);
        }
        symbolListRow1[symbolRowIndex[0]].SetActive(true);

        foreach (GameObject g in symbolListRow2)
        {
            g.SetActive(false);
        }
        symbolListRow2[symbolRowIndex[1]].SetActive(true);

        foreach (GameObject g in symbolListRow3)
        {
            g.SetActive(false);
        }
        symbolListRow3[symbolRowIndex[2]].SetActive(true);

        foreach (GameObject g in symbolListRow4)
        {
            g.SetActive(false);
        }
        symbolListRow4[symbolRowIndex[3]].SetActive(true);

        foreach (GameObject g in symbolListRow5)
        {
            g.SetActive(false);
        }
        symbolListRow5[symbolRowIndex[4]].SetActive(true);
    }
}
