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
            EndDialogue();
            return;
        }

        CheckCurrentLineToEnableRecordingUI();
        CheckCurrentLineToShowPortrait();

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
    }
}
