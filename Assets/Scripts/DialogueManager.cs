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
	public bool disableInput = false;

    public Text dialogueText;
    public Animator animator;
    public ActManager actManager;
    public RecordingManager recordingManager;

    public LoadScene loader;

	// Use this for initialization
	void Awake ()
    {
        sentences = new Queue<string>();
        recordingManager = GameObject.Find("ActManager").GetComponent<RecordingManager>();	
	}

	void Update()
    {
		if (Input.GetMouseButtonDown (0)) 
        {
			if (!disableInput) {
				DisplayNextSentence ();
			}
		}	
	}

    public void StartDialogue(LineManager lineManager)
    {
        animator.SetBool("isOpen", true);
        lineNumber = 0;

        sentences.Clear();

        if (currentAct == 5)
        {
            if (GameInformation.TotalStrange > 600)
            {
                actManager.titleCardLM.sentences[7] = "What you were able to capture is extremely disturbing… On reviewing it all, it’s probably the most convincing argument you can make. You only hope it’s enough.";
            } else if (GameInformation.TotalStrange <= 600 && GameInformation.TotalStrange > 400)
            {
                actManager.titleCardLM.sentences[7] = "On reviewing everything you captured, you realize that some of those situations were pretty hairy. There wasn’t possibly anything you could have done to get any more… was there? It’s a fairly compelling case. You hope others will think so too.";
            } else 
            {
                actManager.titleCardLM.sentences[7] = "These past few days have been harrowing, to say the least. On review, what you’ve captured doesn’t really inspire much confidence… You’re going to just have to hope that someone takes a chance on you.";  
            }
        }

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
			//131, 142, 255
			dialogueText.color = new Color(.513f, .556f, 1f, 1f);
            dialogueText.fontStyle = FontStyle.Normal;
        } else if (actManager.GetSpeaker(lineNumber, actManager.gameLM) == "Narrator" && actManager.displayedTitleCard)
        {
            dialogueText.color = Color.white;
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
            dialogueText.color = new Color(0.4f, 0.05f, 0.05f, 1f);
            dialogueText.fontStyle = FontStyle.Normal;
        } else if (actManager.GetSpeaker(lineNumber, actManager.gameLM) == "Dagon" && actManager.displayedTitleCard)
        {
            dialogueText.color = new Color(0.4f, 0.4f, 0.4f, 1f);
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
            actManager.totalStrange += actManager.strangeValue;
			actManager.totalSuspicion += actManager.suspicionValue;
        }
        
        CheckIfLastLine();
        
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

    public void CheckIfLastLine()
    {
        if (currentAct == 1)
        {
            if (actManager.gameDM.lineNumber == 46)
            {
                loader.LoadSceneOnLastLine();
            }
        }

        if (currentAct == 2)
        {
            if (actManager.gameDM.lineNumber == 64)
            {
                loader.LoadSceneOnLastLine();
            }
        }

        if (currentAct == 3)
        {
            if (actManager.gameDM.lineNumber == 69)
            {
                loader.LoadSceneOnLastLine();
            }
        }

        if (currentAct == 4)
        {
            if (actManager.gameDM.lineNumber == 137)
            {
                loader.LoadSceneOnLastLine();
            }
        }

        if (currentAct == 6)
        {
            if (actManager.titleCardDM.lineNumber == 22)
            {
                loader.LoadSceneOnLastLine();
            }
        }

        if (currentAct == 7)
        {
            if (actManager.titleCardDM.lineNumber == 10)
            {
                loader.LoadSceneOnLastLine();
            }
        }
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
				actManager.Invoke ("ShowHelp", 2f);
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

        //Act 4 recording event
        if (currentAct == 4)
        {
            if (actManager.gameDM.lineNumber == 87)
            {
                actManager.animatorRecordingUI.SetBool("isOpen", true);
                actManager.EnableRecordingUI();
            }

            if (actManager.gameDM.lineNumber == 133)
            {
                actManager.animatorRecordingUI.SetBool("isOpen", false);
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

        if (currentAct == 4)
        {
            if (actManager.titleCardDM.lineNumber == 3)
            {
                actManager.UpdateBackground(2);
                actManager.UpdatePortraitAndName(3);
            }

            if (actManager.titleCardDM.lineNumber == 7)
            {
                actManager.UpdateBackground(4);
            }

            if (actManager.gameDM.lineNumber == 110)
            {
                actManager.UpdatePortraitAndName(5);
            }

            if (actManager.gameDM.lineNumber == 117)
            {
                actManager.UpdatePortraitAndName(2);
            }

            if (actManager.gameDM.lineNumber == 120)
            {
                actManager.UpdatePortraitAndName(3);
            }

            if (actManager.gameDM.lineNumber == 127)
            {
                actManager.UpdatePortraitAndName(5);
            }
        }

        if (currentAct == 5)
        {
             if (actManager.gameDM.lineNumber == 3)
            {
                actManager.UpdatePortraitAndName(6);
                actManager.animatorNPCPortrait.SetBool("isOpen", true);
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
                actManager.titleCardDM.enabled = false;
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
                actManager.gameDM.enabled = false;
                actManager.titleCardDM.enabled = false;
                actManager.DisableTitleCard();
                actManager.animatorNPCPortrait.SetBool("isOpen", true);
                actManager.gameDM.enabled = true;
            }

            if (actManager.titleCardDM.lineNumber == 12)
            {
                actManager.displayedTitleCard = true;
                paused = true;
                DisplayNextSentence();
                paused = false;
                actManager.titleCardDM.lineNumber++;
                actManager.EnableGameCanvas();
                actManager.titleCardDM.enabled = false;
                actManager.DisableTitleCard();
                actManager.gameDM.enabled = true;
            }

            if (actManager.titleCardDM.lineNumber == 19)
            {
                actManager.displayedTitleCard = true;
                paused = true;
                DisplayNextSentence();
                paused = false;
                actManager.titleCardDM.lineNumber++;
                actManager.EnableGameCanvas();
                actManager.titleCardDM.enabled = false;
                actManager.DisableTitleCard();
                actManager.gameDM.enabled = true;
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
                actManager.gameDM.enabled = false;
                actManager.DisableGameCanvas();
                actManager.titleCardDM.enabled = true;
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
                actManager.gameDM.enabled = false;
                actManager.DisableGameCanvas();
                actManager.titleCardDM.enabled = true;
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
                actManager.gameDM.enabled = false;
                actManager.titleCardDM.enabled = false;
                actManager.DisableTitleCard();
                actManager.animatorNPCPortrait.SetBool("isOpen", true);
                actManager.gameDM.enabled = true;
            }

            if (actManager.gameDM.lineNumber == 10)
            {
                actManager.displayedTitleCard = false;
                paused = true;
                DisplayNextSentence();
                paused = false;
                actManager.gameDM.lineNumber++;
                actManager.EnableTitleCard();
                actManager.gameDM.enabled = false;
                actManager.UpdateTitleCardHeader(2);
                actManager.titleCardDescription.color = Color.white;
                actManager.titleCardDescription.fontStyle = FontStyle.Normal;
                actManager.animatorNPCPortrait.SetBool("isOpen", false);
                actManager.DisableGameCanvas();
                actManager.titleCardDM.enabled = true;
            }

            if (actManager.titleCardDM.lineNumber == 13)
            {
                actManager.displayedTitleCard = true;
                paused = true;
                DisplayNextSentence();
                paused = false;
                actManager.titleCardDM.lineNumber++;
                actManager.EnableGameCanvas();
                actManager.titleCardDM.enabled = false;
                actManager.DisableTitleCard();
                actManager.animatorNPCPortrait.SetBool("isOpen", true);
                actManager.gameDM.enabled = true;
            }

            if (actManager.gameDM.lineNumber == 46)
            {
                actManager.displayedTitleCard = false;
                paused = true;
                DisplayNextSentence();
                paused = false;
                actManager.gameDM.lineNumber++;
                actManager.EnableTitleCard();
                actManager.gameDM.enabled = false;
                actManager.UpdateTitleCardHeader(3);
                actManager.titleCardDescription.color = Color.white;
                actManager.titleCardDescription.fontStyle = FontStyle.Normal;
                actManager.animatorNPCPortrait.SetBool("isOpen", false);
                actManager.DisableGameCanvas();
                actManager.titleCardDM.enabled = true;
            }

            if (actManager.titleCardDM.lineNumber == 21)
            {
                actManager.displayedTitleCard = true;
                actManager.EnableGameCanvas();
                actManager.titleCardDM.enabled = false;
                actManager.DisableTitleCard();
                actManager.animatorNPCPortrait.SetBool("isOpen", true);
                actManager.gameDM.enabled = true;
            }
        }

        if (currentAct == 4)
        {
            if (actManager.titleCardDM.lineNumber == 3)
            {
                actManager.displayedTitleCard = true;
                paused = true;
                DisplayNextSentence();
                paused = false;
                actManager.titleCardDM.lineNumber++;
                actManager.EnableGameCanvas();
                actManager.titleCardDM.enabled = false;
                actManager.gameDM.StartDialogue(actManager.gameLM);
                actManager.gameDM.enabled = false;
                actManager.DisableTitleCard();
                actManager.animatorNPCPortrait.SetBool("isOpen", true);
                actManager.gameDM.enabled = true;
            }

            if (actManager.gameDM.lineNumber == 60)
            {
                actManager.displayedTitleCard = false;
                paused = true;
                DisplayNextSentence();
                paused = false;
                actManager.gameDM.lineNumber++;
                actManager.EnableTitleCard();
                actManager.titleCardDM.enabled = true;
                actManager.UpdateTitleCardHeader(4);
                actManager.titleCardDescription.color = Color.white;
                actManager.titleCardDescription.fontStyle = FontStyle.Normal;
                actManager.animatorNPCPortrait.SetBool("isOpen", false);
                actManager.DisableGameCanvas();
                actManager.gameDM.enabled = false;
            }

            if (actManager.titleCardDM.lineNumber == 7)
            {
                actManager.displayedTitleCard = true;
                paused = true;
                DisplayNextSentence();
                paused = false;
                actManager.titleCardDM.lineNumber++;
                actManager.EnableGameCanvas();
                actManager.titleCardDM.enabled = false;
                actManager.DisableTitleCard();
                actManager.animatorNPCPortrait.SetBool("isOpen", true);
                actManager.gameDM.enabled = true;
            }
        }

        if (currentAct == 5)
        {
            if (actManager.titleCardDM.lineNumber == 8)
            {
                actManager.displayedTitleCard = true;
                paused = true;
                DisplayNextSentence();
                paused = false;
                actManager.titleCardDM.lineNumber++;
                actManager.EnableGameCanvas();
                actManager.titleCardDM.enabled = false;
                actManager.gameDM.StartDialogue(actManager.gameLM);
                actManager.gameDM.enabled = false;
                actManager.DisableTitleCard();
                actManager.gameDM.enabled = true;
            }

            if (actManager.gameDM.lineNumber == 11)
            {
                actManager.EnableLastChoiceButtons();
            }
        }
    }
}
