using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Color = UnityEngine.Color;

public class MastermindMinigame : MonoBehaviour
{
    public int slotNr;
    public VideoPlay vdP;
    public AudioSource errorSound;

    public bool minigameIsActive = false;
    [SerializeField] private GameObject minigameObject;
    public List<Sprite>Buttons = new List<Sprite>();
    public List<Texture2D>Cursors = new List<Texture2D>();
    public List<MasterRowScript> Rows;

    [SerializeField] private int selectedColour = 0;

    [SerializeField] private GameObject clickedButton;
    [SerializeField] private ColourIndex clickedColour;

    public int playRound = 0;
    public Button nextButton;

    public List<string> colourNames;
    public List<string> colourCode;
   // public MasterCreatureScript masterCreature;

   // public DialogueScript dialogue;
   // public SceneManagement sceneManagement;

    private void Start()
    {
        Cursor.SetCursor(Cursors[0], Vector2.zero, CursorMode.Auto);
    }

    public void startMastermindMinigame(int videoNr)
    {
        slotNr = videoNr;
        minigameIsActive = true;
       // masterCreature.hasTheirNeeds = false;
        playRound = 0;
        nextButton.interactable = true;
       // masterCreature.RoundSelector();
       colourCode.Clear();
        switch (videoNr)
        {
            case 1:
                colourCode.Add("BtnGreen");
                colourCode.Add("BtnYellow");
                colourCode.Add("BtnRed");
                colourCode.Add("BtnBlue");
                break;
            case 2:
                colourCode.Add("BtnPurple");
                colourCode.Add("BtnOrange");
                colourCode.Add("BtnYellow");
                colourCode.Add("BtnGreen");
                break;
            case 3:
                colourCode.Add("BtnRed");
                colourCode.Add("BtnOrange");
                colourCode.Add("BtnYellow");
                colourCode.Add("BtnPurple");
                break;
            case 4:
                colourCode.Add("BtnBlue");
                colourCode.Add("BtnPurple");
                colourCode.Add("BtnOrange");
                colourCode.Add("BtnGreen");
                break;
            case 5:
                colourCode.Add("BtnYellow");
                colourCode.Add("BtnRed");
                colourCode.Add("BtnGreen");
                colourCode.Add("BtnPurple");
                break;
            case 6:
                colourCode.Add("BtnPurple");
                colourCode.Add("BtnOrange");
                colourCode.Add("BtnRed");
                colourCode.Add("BtnBlue");
                break;
            case 7:
                colourCode.Add("BtnGreen");
                colourCode.Add("BtnYellow");
                colourCode.Add("BtnBlue");
                colourCode.Add("BtnRed");
                break;
            case 8:
                colourCode.Add("BtnPurple");
                colourCode.Add("BtnOrange");
                colourCode.Add("BtnBlue");
                colourCode.Add("BtnYellow");
                break;
            case 9:
                colourCode.Add("BtnGreen");
                colourCode.Add("BtnRed");
                colourCode.Add("BtnBlue");
                colourCode.Add("BtnYellow");
                break;
        }
        foreach (string c in colourCode)
        {
            //Debug.Log(c);
        }
        foreach (MasterRowScript m in Rows)
        {
            m.resetColours();
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.SetCursor(Cursors[selectedColour], Vector2.zero, CursorMode.Auto);
        minigameObject.SetActive(true);
    }
    public void stopMastermindMinigame()
    {
        minigameIsActive = false;
        Cursor.SetCursor(Cursors[0], Vector2.zero, CursorMode.Auto);
        minigameObject.SetActive(false);
    }

    public void ClickedButton()
    {
        Image btnColour = clickedButton.GetComponent<Image>();
        btnColour.sprite = Buttons[selectedColour];
    }

    public void setClickedButton(GameObject btn)
    {
        clickedButton = btn;
    }

    public void setClickedColour(ColourIndex index)
    {
        clickedColour = index;
        selectedColour = clickedColour.colourIndex;
        Cursor.SetCursor(Cursors[selectedColour], Vector2.zero, CursorMode.Auto);
    }

    public void checkAnswer()
    {
        MasterRowScript m = Rows[playRound];
        List<Image> givenColours = m.giveColours();
        for (int i = 0; i < givenColours.Count; i++)
        {
            string check = givenColours[i].sprite.name;
            if (check != colourCode[i])
            {
                //incorrect
                Debug.Log("wrong");
                errorSound.Play();
                return;
            }
        }
        //correct
        Debug.Log("correct");
        stopMastermindMinigame();
        vdP.unlockVideo(slotNr);


        //MasterRowScript m = Rows[playRound];
        //    List<Image> givenColours = m.giveColours();
        //    List<string> colourname = new List<string>();
        //    foreach (Image img in givenColours)
        //    {
        //        colourname.Add(img.sprite.name);
        //    }

        //    List<string> noDupes = colourname.Distinct().ToList();
        //    if (noDupes.Count < 4)
        //    {
        //        Debug.Log("row not filled in correctly, duped");
        //        return;
        //    }
        //    else
        //    {
        //        giveBetterScore();
        //    }
            //if (minigameIsActive)
            //{
            //    for (int i = 0; i < givenColours.Count; i++)
            //    {
            //        if (givenColours[i].sprite.name == "BtnEmpty")
            //        {
            //            Debug.Log("row not filled in correctly");
            //            return;
            //        }
            //        if (givenColours[i].sprite.name != colourCode[i])
            //        {
            //            Debug.Log("incorrect");
            //            if (playRound != 9)
            //            {
            //                playRound++;
            //            }
            //            else
            //            {
            //                Debug.Log("you lose!");
            //                //sceneManagement.Quit();
            //            }
            //            if(playRound > 8)
            //            {
            //                nextButton.interactable = false;
            //            }
            //            return;
            //        }

            //    }
            //}
        
        
            //if (playRound != 9)
            //{
            //    playRound++;
            //}
            //if (playRound > 8)
            //{
            //    nextButton.interactable = false;
            //}
        
    }

    //public void giveScore()
    //{
    //    int red = 0;
    //    int black = 0;
    //    int white = 0;
    //    MasterRowScript m = Rows[playRound];
    //    List<Image> givenColours = m.giveColours();
    //    for (int i = 0; i < givenColours.Count; i++)
    //    {
    //        string check = givenColours[i].sprite.name;
    //        if (check == colourCode[i])
    //        {
    //            red++;
    //        }
    //        else if(check == colourCode[0] || check == colourCode[1] || check == colourCode[2] || check == colourCode[3] )
    //        {
    //            black++;
    //        }
    //        else
    //        {
    //            white++;
    //        }
    //    }
    //    if (red == 4)
    //    {
    //        //masterCreature.hasTheirNeeds = true;
    //        Debug.Log("You won");
    //        if (playRound != 9)
    //        {
    //            playRound++;
    //        }
    //        if(playRound > 8)
    //        {
    //            nextButton.interactable = false;
    //        }
    //    }

    //    Debug.Log(red + " " + black + " " + white);

    //    for (int i = 0; i < m.checkColours.Count; i++)
    //    {
    //        if(red > 0)
    //        {
    //            m.checkColours[i].color = Color.red;
    //            red --;
    //        }
    //        else if(black > 0) 
    //        {
    //            Color32 nColor = new Color32(80, 80, 80, 255);
    //            m.checkColours[i].color = nColor;
    //            black --;
    //        }
    //        else if (white > 0)
    //        {
    //            m.checkColours[i].color = Color.white;
    //            white --;
    //        }
    //    }
    //}
}
