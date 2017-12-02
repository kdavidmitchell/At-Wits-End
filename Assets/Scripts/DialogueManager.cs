using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public int currentAct;

    private Queue<string> sentences;
    private int lineNumber = 0;

    public Text dialogueText;
    public Animator animator;
    public ActManager actManager;
    public RecordingManager recordingManager;

	// Use this for initialization
	void Start ()
    {
        sentences = new Queue<string>();
        recordingManager = GameObject.Find("ActManager").GetComponent<RecordingManager>();	
	}

    public void StartDialogue(LineManager lineManager)
    {
        animator.SetBool("isOpen", true);

        sentences.Clear();
        lineNumber = 0;

        foreach (string sentence in lineManager.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            //EndDialogue();
            return;
        }

        CheckCurrentLineToEnableRecordingUI();
        CheckCurrentLineToShowPortrait();
        CheckCurrentLineToSwitchTitleCard();

        string sentence = sentences.Dequeue();

        if (actManager.GetSpeaker(lineNumber, actManager.gameLM) == "Alice" && actManager.displayedTitleCard)
        {
            dialogueText.color = Color.red;
            dialogueText.fontStyle = FontStyle.Normal;
        } else if (actManager.GetSpeaker(lineNumber, actManager.gameLM) == "Sam" && actManager.displayedTitleCard)
        {
            dialogueText.color = Color.blue;
            dialogueText.fontStyle = FontStyle.Normal;
        } else if (actManager.GetSpeaker(lineNumber, actManager.gameLM) == "Narrator" && actManager.displayedTitleCard)
        {
            dialogueText.color = Color.black;
            dialogueText.fontStyle = FontStyle.Italic;
        } else if (actManager.GetSpeaker(lineNumber, actManager.gameLM) == "Ma" && actManager.displayedTitleCard)
        {
            dialogueText.color = Color.magenta;
            dialogueText.fontStyle = FontStyle.Normal;
        } else if (actManager.GetSpeaker(lineNumber, actManager.gameLM) == "Joseph" && actManager.displayedTitleCard)
        {
            dialogueText.color = new Color(0.1f, 0.6f, 0.1f, 1f);
            dialogueText.fontStyle = FontStyle.Normal;
        }

        dialogueText.text = sentence;
        
        actManager.UpdateStrangeAndSuspicionValues(lineNumber, actManager.gameLM);
        
        if (recordingManager.isRecording)
        {
            recordingManager.UpdateMeters();
        }
        
        lineNumber++;
    }

    void EndDialogue()
    {
        Debug.Log("End of dialogue.");
        if (!actManager.displayedTitleCard)
        {
            actManager.displayedTitleCard = true;
            actManager.DisableTitleCard();
            actManager.EnableGameCanvas();
        }
        //animator.SetBool("isOpen", false);
    }

    public void CheckCurrentLineToEnableRecordingUI()
    {
        if (lineNumber == 22 && currentAct == 1)
        {
            actManager.animatorRecordingUI.SetBool("isOpen", true);
            actManager.EnableRecordingUI();
        }
    }

    public void CheckCurrentLineToShowPortrait()
    {
        if (lineNumber == 6 && currentAct == 1 && actManager.displayedTitleCard)
        {
            actManager.animatorNPCPortrait.SetBool("isOpen", true);
        }

        if (lineNumber == 0 && currentAct == 2 && actManager.displayedTitleCard)
        {
            actManager.UpdateBackground(1);
            actManager.UpdatePortraitAndName(2);
            actManager.animatorNPCPortrait.SetBool("isOpen", true);
        }

        if (lineNumber == 19 && currentAct == 2 && actManager.displayedTitleCard)
        {
            actManager.animatorNPCPortrait.SetBool("isOpen", false);
            actManager.UpdateBackground(2);
            actManager.UpdatePortraitAndName(3);
        }

        if (lineNumber == 21 && currentAct == 2 && actManager.displayedTitleCard)
        {
            actManager.animatorNPCPortrait.SetBool("isOpen", true);
        }

        if (lineNumber == 50 && currentAct == 2 && actManager.displayedTitleCard)
        {
            actManager.animatorNPCPortrait.SetBool("isOpen", false);
        }
    }

    public void CheckCurrentLineToSwitchTitleCard()
    {
        if (lineNumber == 10 && currentAct == 1 && !actManager.displayedTitleCard)
        {
            actManager.displayedTitleCard = true;
            actManager.EnableGameCanvas();
            actManager.gameDM.StartDialogue(actManager.gameLM);
            actManager.DisableTitleCard();
        }

        if (lineNumber == 8 && currentAct == 2 && !actManager.displayedTitleCard)
        {
            Debug.Log("Attempting to switch to game mode");

            actManager.displayedTitleCard = true;
            DisplayNextSentence();
            actManager.EnableGameCanvas();
            actManager.gameDM.StartDialogue(actManager.gameLM);
            actManager.DisableTitleCard();
        }

        if (lineNumber == 12 && currentAct == 2 && !actManager.displayedTitleCard)
        {
            Debug.Log("Attempting to switch to game mode");

            actManager.displayedTitleCard = true;
            DisplayNextSentence();
            actManager.EnableGameCanvas();
            actManager.DisableTitleCard();
        }

        if (lineNumber == 19 && currentAct == 2 && !actManager.displayedTitleCard)
        {
            Debug.Log("Attempting to switch to game mode");

            actManager.displayedTitleCard = true;
            actManager.EnableGameCanvas();
            actManager.EnableRecordingUI();
            actManager.DisableTitleCard();
        }

        if (lineNumber == 19 && currentAct == 2 && actManager.displayedTitleCard)
        {
            Debug.Log("Attempting to switch to titlecard");

            actManager.displayedTitleCard = false;
            DisplayNextSentence();
            actManager.EnableTitleCard();
            actManager.UpdateTitleCardHeader(0);
            actManager.titleCardDescription.color = Color.white;
            actManager.DisableGameCanvas();
        }

        if (lineNumber == 50 && currentAct == 2 && actManager.displayedTitleCard)
        {
            Debug.Log("Attempting to switch to titlecard");

            actManager.displayedTitleCard = false;
            DisplayNextSentence();
            actManager.EnableTitleCard();
            actManager.UpdateTitleCardHeader(1);
            actManager.titleCardDescription.color = Color.white;
            actManager.DisableGameCanvas();
        }
    }
}
