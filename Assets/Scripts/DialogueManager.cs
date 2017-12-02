using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public int currentAct;

    private Queue<string> sentences;
    private bool paused = false;
    public int lineNumber = 0;

    public Text dialogueText;
    public Animator animator;
    public ActManager actManager;
    public RecordingManager recordingManager;

	// Use this for initialization
	void Awake ()
    {
        sentences = new Queue<string>();
        recordingManager = GameObject.Find("ActManager").GetComponent<RecordingManager>();	
	}

    public void StartDialogue(LineManager lineManager)
    {
        animator.SetBool("isOpen", true);
        lineNumber = 0;

        sentences.Clear();

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
        } else if (actManager.GetSpeaker(lineNumber, actManager.gameLM) == "Anne" && actManager.displayedTitleCard)
        {
            dialogueText.color = new Color(0.2f, 0.2f, 0.5f, 1f);
            dialogueText.fontStyle = FontStyle.Normal;
        } else if (actManager.GetSpeaker(lineNumber, actManager.gameLM) == "Douglas" && actManager.displayedTitleCard)
        {
            dialogueText.color = new Color(0.2f, 0.05f, 0.05f, 1f);
            dialogueText.fontStyle = FontStyle.Normal;
        }

        dialogueText.text = sentence;

        if (paused)
        {
            return;
        }

        CheckCurrentLineToEnableRecordingUI();
        CheckCurrentLineToShowPortrait();
        CheckCurrentLineToSwitchTitleCard();
        
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
        //Act 1 recording events
        if (currentAct == 1)
        {
            if (actManager.gameDM.lineNumber == 22)
            {
                actManager.animatorRecordingUI.SetBool("isOpen", true);
                actManager.EnableRecordingUI();
            }
        }

        //Act 2 recording events
        if (currentAct == 2)
        {
            if (actManager.titleCardDM.lineNumber == 19)
            {
                actManager.animatorRecordingUI.SetBool("isOpen", true);
                actManager.EnableRecordingUI();
            }
        }

        //Act 3 recording event
        if (currentAct == 3)
        {
            if (actManager.titleCardDM.lineNumber == 21)
            {
                actManager.animatorRecordingUI.SetBool("isOpen", true);
                actManager.EnableRecordingUI();
            }
        }
    }

    public void CheckCurrentLineToShowPortrait()
    {

        //Act 1 portrait events
        if (currentAct == 1)
        {
            if (actManager.gameDM.lineNumber == 6)
            {
                actManager.animatorNPCPortrait.SetBool("isOpen", true);
            }
        }

        //Act 2 portrait events

        if (currentAct == 2)
        {
            if (actManager.gameDM.lineNumber == 0)
            {
                actManager.UpdateBackground(1);
                actManager.UpdatePortraitAndName(2);
            }

            if (actManager.gameDM.lineNumber == 19)
            {
                actManager.animatorNPCPortrait.SetBool("isOpen", false);
                actManager.UpdateBackground(2);
                actManager.UpdatePortraitAndName(3);
            }

            if (actManager.gameDM.lineNumber == 21)
            {
                actManager.animatorNPCPortrait.SetBool("isOpen", true);
            }

            if (actManager.gameDM.lineNumber == 50)
            {
                actManager.animatorNPCPortrait.SetBool("isOpen", false);
                actManager.UpdateBackground(4);
            }
        }

        //Act 3 portrait events
        if (currentAct == 3)
        {
            if (actManager.gameDM.lineNumber == 0)
            {
                actManager.UpdateBackground(1);
                actManager.UpdatePortraitAndName(2);
            }

            if (actManager.titleCardDM.lineNumber == 10)
            {
                actManager.UpdateBackground(3);
                actManager.UpdatePortraitAndName(4);
            }

            if (actManager.gameDM.lineNumber == 46)
            {
                actManager.UpdateBackground(4);
                actManager.UpdatePortraitAndName(5);
            }
        }
    }

    public void CheckCurrentLineToSwitchTitleCard()
    {
        //Act 1 switches

        if (currentAct == 1)
        {
            if (actManager.titleCardDM.lineNumber == 10)
            {
                actManager.displayedTitleCard = true;
                paused = true;
                actManager.EnableGameCanvas();
                actManager.gameDM.StartDialogue(actManager.gameLM);
                paused = false;
                actManager.DisableTitleCard();
            }
        }

        //Act 2 switches

        if (currentAct == 2)
        {
            if (actManager.titleCardDM.lineNumber == 8)
            {
                actManager.displayedTitleCard = true;
                paused = true;
                DisplayNextSentence();
                paused = false;
                actManager.titleCardDM.lineNumber++;
                actManager.EnableGameCanvas();
                actManager.gameDM.StartDialogue(actManager.gameLM);
                actManager.DisableTitleCard();
                actManager.animatorNPCPortrait.SetBool("isOpen", true);
            }

            if (actManager.titleCardDM.lineNumber == 12)
            {
                actManager.displayedTitleCard = true;
                paused = true;
                DisplayNextSentence();
                paused = false;
                actManager.titleCardDM.lineNumber++;
                actManager.EnableGameCanvas();
                actManager.DisableTitleCard();
            }

            if (actManager.titleCardDM.lineNumber == 19)
            {
                actManager.displayedTitleCard = true;
                paused = true;
                DisplayNextSentence();
                paused = false;
                actManager.titleCardDM.lineNumber++;
                actManager.EnableGameCanvas();
                actManager.DisableTitleCard();
            }

            if (actManager.gameDM.lineNumber == 19)
            {
                actManager.displayedTitleCard = false;
                paused = true;
                DisplayNextSentence();
                paused = false;
                actManager.gameDM.lineNumber++;
                actManager.EnableTitleCard();
                actManager.UpdateTitleCardHeader(0);
                actManager.titleCardDescription.color = Color.white;
                actManager.DisableGameCanvas();
            }

            if (actManager.gameDM.lineNumber == 50)
            {
                actManager.displayedTitleCard = false;
                paused = true;
                DisplayNextSentence();
                paused = false;
                actManager.gameDM.lineNumber++;
                actManager.EnableTitleCard();
                actManager.UpdateTitleCardHeader(1);
                actManager.titleCardDescription.color = Color.white;
                actManager.DisableGameCanvas();
            }
        }

        //Act 3 switches
        if (currentAct == 3)
        {
            if (actManager.titleCardDM.lineNumber == 7)
            {
                actManager.displayedTitleCard = true;
                paused = true;
                DisplayNextSentence();
                paused = false;
                actManager.titleCardDM.lineNumber++;
                actManager.EnableGameCanvas();
                actManager.gameDM.StartDialogue(actManager.gameLM);
                actManager.DisableTitleCard();
                actManager.animatorNPCPortrait.SetBool("isOpen", true);
            }

            if (actManager.gameDM.lineNumber == 10)
            {
                actManager.displayedTitleCard = false;
                paused = true;
                DisplayNextSentence();
                paused = false;
                actManager.gameDM.lineNumber++;
                actManager.EnableTitleCard();
                actManager.UpdateTitleCardHeader(2);
                actManager.titleCardDescription.color = Color.white;
                actManager.titleCardDescription.fontStyle = FontStyle.Normal;
                actManager.animatorNPCPortrait.SetBool("isOpen", false);
                actManager.DisableGameCanvas();
            }

            if (actManager.titleCardDM.lineNumber == 13)
            {
                actManager.displayedTitleCard = true;
                paused = true;
                DisplayNextSentence();
                paused = false;
                actManager.titleCardDM.lineNumber++;
                actManager.EnableGameCanvas();
                actManager.DisableTitleCard();
                actManager.animatorNPCPortrait.SetBool("isOpen", true);
            }

            if (actManager.gameDM.lineNumber == 46)
            {
                actManager.displayedTitleCard = false;
                paused = true;
                DisplayNextSentence();
                paused = false;
                actManager.gameDM.lineNumber++;
                actManager.EnableTitleCard();
                actManager.UpdateTitleCardHeader(3);
                actManager.titleCardDescription.color = Color.white;
                actManager.titleCardDescription.fontStyle = FontStyle.Normal;
                actManager.animatorNPCPortrait.SetBool("isOpen", false);
                actManager.DisableGameCanvas();
            }

            if (actManager.titleCardDM.lineNumber == 21)
            {
                actManager.displayedTitleCard = true;
                actManager.EnableGameCanvas();
                actManager.DisableTitleCard();
                actManager.animatorNPCPortrait.SetBool("isOpen", true);
            }
        }
    }
}
