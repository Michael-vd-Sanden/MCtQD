using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class VideoPlay : MonoBehaviour
{
    public MastermindMinigame mmm;
    public Texture2D emtpyCursor;
    public GameObject environment;
    public TMP_InputField inputPassword;
    public AreaInhibiter areaInhibiter;

    public AudioSource error;

    public Sprite playIcon;
    public LogsManager logManager;

    private Button btnPressed;
    private Image btnImage;
    private Sprite btnSprite;

    public List<Button> buttons;
    public List<GameObject> codes;
    public List<bool> knowsCode;
    public List<bool> hasSeenVideo;

    public GameObject unlockVideoScreen;
    public GameObject computerUnlockScreen;
    public GameObject computer;
    public GameObject arrows;

    private bool has1stTriggered;
    private bool haslastTriggered;

    void Start()
    {
        Cursor.SetCursor(emtpyCursor, Vector2.zero, CursorMode.Auto);
        has1stTriggered = false;
    }

    void Update()
    {
        if (computer.activeSelf)
        {
            for (int b = 0; b < buttons.Count; b++)
            {
                if (hasSeenVideo[b])
                { buttons[b].image.color = Color.green; }
                if (knowsCode[b])
                { buttons[b].image.color = Color.green; }
            }
            if (hasSeenVideo[0] && !has1stTriggered) 
            { 
                areaInhibiter.areaIndex++; 
                has1stTriggered = true; 
            }
            if (hasSeenVideo[2] && !haslastTriggered)
            {
                areaInhibiter.areaIndex++;
                haslastTriggered = true;
            }
        }
    }

    public void isAllowedToPlay(int btn)
    {
        btnPressed = buttons[btn];
        btnImage = btnPressed.image.GetComponent<Image>();
        btnSprite = btnImage.sprite;

        if(btnSprite.name == "PlayIcon")
        {
            //Debug.Log("play");
            int newNr = btn + 1;
            logManager.vPlayers[newNr].enabled = true;           
            hasSeenVideo[btn] = true;
        }
        else if (btnSprite.name == "LockIcon")
        {
            unlockVideoScreen.SetActive(true);
            mmm.startMastermindMinigame(btn);
            if (knowsCode[btn]) 
            {
                codes[btn].SetActive(true);
            }
        }
    }

    public void unlockVideo(int videoNr)
    {
        btnPressed = buttons[videoNr];
        btnImage.sprite = btnPressed.image.sprite = playIcon;
        knowsCode[videoNr] = false;
        codes[videoNr].SetActive(false);
        buttons[videoNr].image.color = Color.white;
    }

    public void closeUnlockScreen()
    {
        unlockVideoScreen.SetActive(false);
        foreach(GameObject c in codes) { c.SetActive(false); }
        Cursor.SetCursor(emtpyCursor, Vector2.zero, CursorMode.Auto);
    }

    public void OpenComputerLockScreen()
    {
        computerUnlockScreen.SetActive(true);
        arrows.SetActive(false) ;
        unlockVideoScreen.SetActive(false);
        environment.SetActive(false);
    }

    public void CloseComputerLockScreen() 
    { 
        computerUnlockScreen.SetActive(false);
        arrows.SetActive(true);
        environment.SetActive(true);
    }

    public void CheckComputerPassword()
    {
        if(inputPassword.GetComponent<TMP_InputField>().text == "Hd05Dy12")
        {
            computer.SetActive(true) ;
            computerUnlockScreen.SetActive(false);
        }
        else
        {
            error.Play();
        }
    }

    public void CloseComputer()
    {
        computer.SetActive(false);
        arrows.SetActive(true);
        environment.SetActive(true);
    }

    public void unlockCertainVideo(int videoNr)
    {
        knowsCode[videoNr] = true;
    }
}
