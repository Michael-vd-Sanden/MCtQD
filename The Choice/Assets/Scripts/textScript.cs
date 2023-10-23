using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class textScript : MonoBehaviour
{
    public TMP_Text textToDisplay;

    private string buttonName;

    public void clickBtn(Button b)
    {
        buttonName = b.name;
        switch (buttonName) 
        {
            case "Statue":
                StartCoroutine(displayText("Hmm, funny looking."));
                break;
            case "Cube":
                StartCoroutine(displayText("Just some kids toys."));
                break;
            case "Lamp":
                StartCoroutine(displayText("Nothing here."));
                break;
            case "Bag":
                StartCoroutine(displayText("Heh, gay."));
                break;
            case "Door":
                StartCoroutine(displayText("It's locked."));
                break;
            case "door":
                StartCoroutine(displayText("It's boarded from the other side?"));
                break;
            case "tube":
                StartCoroutine(displayText("Hey, there's another colour code up there."));
                break;
            case "Flag":
                StartCoroutine(displayText("Oh look, another colour code."));
                break;
            case "Sink":
                StartCoroutine(displayText("What a mess."));
                break;
            case "Afzuig":
                StartCoroutine(displayText("This should really be cleaned."));
                break;
            case "Stove":
                StartCoroutine(displayText("There's still some food residue on it."));
                break;
            case "Bin":
                StartCoroutine(displayText("I'm not touching that."));
                break;
        }
        b.gameObject.SetActive(false);
    }

    public IEnumerator displayText(string text)
    {
        Debug.Log(text);
        textToDisplay.text = text;
        yield return new WaitForSecondsRealtime(3f);
        textToDisplay.text = "";
    }
}
