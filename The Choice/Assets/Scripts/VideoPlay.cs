using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class VideoPlay : MonoBehaviour
{
    public MastermindMinigame mmm;
    public Texture2D emtpyCursor;

    public Sprite playIcon;

    private Button btnPressed;
    private Image btnImage;
    private Sprite btnSprite;

    public List<Button> buttons;
    public List<GameObject> codes;
    public List<bool> knowsCode;

    public GameObject unlockVideoScreen;
    public GameObject computer;
    public GameObject arrows;

    void Start()
    {
        Cursor.SetCursor(emtpyCursor, Vector2.zero, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void isAllowedToPlay(int btn)
    {
        btnPressed = buttons[btn];
        btnImage = btnPressed.image.GetComponent<Image>();
        btnSprite = btnImage.sprite;

        if(btnSprite.name == "PlayIcon")
        {
            Debug.Log("play");
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
        
    }

    public void closeUnlockScreen()
    {
        unlockVideoScreen.SetActive(false);
        foreach(GameObject c in codes) { c.SetActive(false); }
        Cursor.SetCursor(emtpyCursor, Vector2.zero, CursorMode.Auto);
    }

    public void OpenComputer()
    {
        computer.SetActive(true);
        arrows.SetActive(false) ;
        unlockVideoScreen.SetActive(false);
    }

    public void CloseComputer() 
    { 
        computer.SetActive(false);
        arrows.SetActive(true);
    }
}
