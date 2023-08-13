using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CryptexScript : MonoBehaviour
{
    public GameObject environment;
    public GameObject wholeGame;
    public VideoPlay videoPlay;
    public AreaInhibiter areaInhibiter;
    public GameObject cryptex1;
    public GameObject cryptex2;
    public int activeGame;

    public bool complete1;
    public bool complete2;

    public List<GameObject> symbolListRow1;
    public List<GameObject> symbolListRow2;
    public List<GameObject> symbolListRow3;
    public List<GameObject> symbolListRow4;
    public List<GameObject> symbolListRow5;
    public List<int> symbolRowIndex;

    public List<Image> codeList1;
    public List<Image> codeList2;

    public List<GameObject> buttons1;
    public List<GameObject> buttons2; 

    private string answer;

    public void start1()
    {
        if (!complete1)
        { 
            cryptex1.SetActive(true);
            environment.SetActive(false);
            wholeGame.SetActive(true);
        }
    }

    public void win1()
    {
        cryptex1.SetActive(false);
        complete1 = true;
        areaInhibiter.areaIndex++;
        videoPlay.knowsCode[1] = true;
        environment.SetActive(true);
        wholeGame.SetActive(false);
        Debug.Log("win1");
    }

    public void start2()
    {
        if (!complete2)
        {
            cryptex2.SetActive(true);
            environment.SetActive(false);
            wholeGame.SetActive(true);
        }
    }

    public void win2()
    {
        cryptex2.SetActive(false);
        complete2 = true;
        videoPlay.knowsCode[3] = true;
        environment.SetActive(true);
        wholeGame.SetActive(false);
    }



    public void scrollUp(int row)
    {
        if (symbolRowIndex[row] < 4)
        {
            symbolRowIndex[row]++;
        }
        updateCryptex();
        checkIfCorrect(row);
    }

    public void scrollDown(int row)
    {
        if (symbolRowIndex[row] != 0)
        {
            symbolRowIndex[row]--;
        }
        updateCryptex();
        checkIfCorrect(row);
    }

    public void checkIfCorrect(int row)
    {
        GameObject g;
        Image i;
        switch(row)
        {
            case 0:
                g = symbolListRow1[symbolRowIndex[row]].gameObject;
                i = g.GetComponent<Image>();
                answer = i.sprite.name;
                break;
            case 1:
                g = symbolListRow2[symbolRowIndex[row]].gameObject;
                i = g.GetComponent<Image>();
                answer = i.sprite.name;
                break;
            case 2:
                g = symbolListRow3[symbolRowIndex[row]].gameObject;
                i = g.GetComponent<Image>();
                answer = i.sprite.name;
                break;
            case 3:
                g = symbolListRow4[symbolRowIndex[row]].gameObject;
                i = g.GetComponent<Image>();
                answer = i.sprite.name;
                break;
            case 4:
                g = symbolListRow5[symbolRowIndex[row]].gameObject;
                i = g.GetComponent<Image>();
                answer = i.sprite.name;
                break;
        }

        if(activeGame == 0 && answer == codeList1[row].sprite.name) 
        {
            buttons1[row].SetActive(false);
        }
        else if (activeGame == 1 && answer == codeList2[row].sprite.name)
        {
            buttons2[row].SetActive(false);
        }
        if (activeGame == 0)
        {
            foreach (GameObject b in buttons1)
            {
                if (b.activeSelf)
                {
                    return;
                }
            }
            win1();
            activeGame++;
            foreach (GameObject b in buttons1)
            {
                b.SetActive(true);
            }
        }
        else if (activeGame == 1)
        {
            foreach (GameObject b in buttons2)
            {
                if (b.activeSelf)
                {
                    return;
                }
            }
            win2();
        }
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
