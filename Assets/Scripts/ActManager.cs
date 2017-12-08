using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ActManager : MonoBehaviour 
{
	//Things needed for each act:
		//1. Title card with day, time, description, etc.
		//2. A linemanager reference that controls the flow of dialogue
		//3. UI for dialogue box, portraits, and background
	
	public RecordingManager recordingManager;
	public PortraitBackgroundManager pbm;
	public TitleCardHeaderManager hm;

	public bool displayedTitleCard = false;
	
	public Canvas titleCard;
	public LineManager titleCardLM;
	public DialogueManager titleCardDM;
	public Text titleCardHeader;
	public Text titleCardDescription;

	public Canvas gameCanvas;
	public LineManager gameLM;
	public DialogueManager gameDM;

	public float strangeValue = 0;
	public float suspicionValue = 0;
	public float totalStrange = 0;
	public float totalSuspicion = 0;
	
	public Animator animatorRecordingUI;
	public Animator animatorNPCPortrait;
	public Image NPCPortrait;
	public Text portraitName;
	public Image background;

	private Image burnButton;
	private Image keepButton;
	private Text burnText;
	private Text keepText;

	// Use this for initialization
	void Start () 
	{	
		recordingManager = GetComponent<RecordingManager>();
		gameCanvas.enabled = false;
		titleCardDM.StartDialogue(titleCardLM);

		if (gameDM.currentAct == 5)
		{
			burnButton = GameObject.Find("BurnButton").GetComponent<Image>();
			keepButton = GameObject.Find("KeepButton").GetComponent<Image>();
			burnText = GameObject.Find("BurnText").GetComponent<Text>();
			keepText = GameObject.Find("KeepText").GetComponent<Text>();
			burnButton.enabled = false;
			keepButton.enabled = false;
			burnText.enabled = false;
			keepText.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void DisableTitleCard()
	{
		titleCard.enabled = false;
	}

	public void EnableTitleCard()
	{
		titleCard.enabled = true;
	}

	public void EnableGameCanvas()
	{
		gameCanvas.enabled = true;
	}

	public void DisableGameCanvas()
	{
		gameCanvas.enabled = false;
	}

	public void UpdateStrangeAndSuspicionValues(int lineNumber, LineManager lineManager)
	{
		strangeValue = lineManager.strangeValues[lineNumber];
		suspicionValue = lineManager.suspicionValues[lineNumber];
	}

	public string GetSpeaker(int lineNumber, LineManager lineManager)
	{
		return lineManager.speakerNames[lineNumber];
	}

	public void EnableRecordingUI()
	{
		recordingManager.recordingUI.SetActive(true);
	}

	public void UpdatePortraitAndName(int characterNumber)
	{
		//0 = Sam
		//1 = Alice
		//2 = Ma
		//3 = Joseph
		//4 = Anne
		//5 = Douglas
		NPCPortrait.sprite = pbm.portraits[characterNumber];
		portraitName.text = pbm.names[characterNumber];
		portraitName.color = pbm.nameColors[characterNumber];

		return;
	}

	public void UpdateBackground(int backgroundNumber)
	{
		//0 = Docks
		//1 = House
		//2 = Theater
		//3 = Church
		//4 = Museum

		background.sprite = pbm.backgrounds[backgroundNumber];

		return;
	}

	public void UpdateTitleCardHeader(int headerNumber)
	{
		//0 = WIT’S END MOVIEHOUSE - 10AM
		//1 = THE OLD MARITIME MUSEUM - 11PM
		titleCardHeader.text = hm.headers[headerNumber];
	}

	public void LoseGame()
	{
		SceneManager.LoadScene(6);
	}

	public void EnableLastChoiceButtons()
	{
		burnButton.enabled = true;
		keepButton.enabled = true;
		burnText.enabled = true;
		keepText.enabled = true;
	}

}
