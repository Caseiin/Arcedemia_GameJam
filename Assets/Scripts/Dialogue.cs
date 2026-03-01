using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections;
public class Dialogue : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textspeed;

    // optional panel or parent object that contains the text box
    // if the script is attached directly to the panel you can use
    // gameObject instead of dialoguePanel.
    public GameObject dialoguePanel;

    private int index;
    private bool started;           // true once the player has clicked to open dialogue

    void Start()
    {
        // make sure the dialogue is hidden at the beginning
        if (dialoguePanel != null)
            dialoguePanel.SetActive(false);

        textComponent.text = string.Empty;
        started = false;
    }

    // Update is called once per frame
    void Update()
    {
        // first click: show dialogue box and start typing
        if (ClickedThisFrame() && !started)
        {
            started = true;

            if (dialoguePanel != null)
                dialoguePanel.SetActive(true);

            StartDialogue();
            return;
        }

        // once started, use left-click (or touch) to advance/finish lines
        if (started && ClickedThisFrame())
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    // unified click/tap detection using the new Input System
    private bool ClickedThisFrame()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
            return true;

        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
            return true;

        if (Keyboard.current != null && Keyboard.current.enterKey.wasPressedThisFrame)
            return true;

        return false;
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textspeed);
        }
    }

    void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            // finished the conversation, hide the UI
            if (dialoguePanel != null)
                dialoguePanel.SetActive(false);
            else
                gameObject.SetActive(false);

            // started remains true so Update ignores future clicks
        }
    }
}

