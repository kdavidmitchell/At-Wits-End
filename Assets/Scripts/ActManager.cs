﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActManager : MonoBehaviour 
{
	//Things needed for each act:
		//1. Title card with day, time, description, etc.
		//2. A linemanager reference that controls the flow of dialogue
		//3. UI for dialogue box, portraits, and background
	
	public bool displayedTitleCard = false;
	
	public Canvas titleCard;
	public LineManager titleCardLM;
	public DialogueManager titleCardDM;

	public Canvas gameCanvas;
	public LineManager gameLM;
	public DialogueManager gameDM;

	public float strangeValue = 0;
	public float suspicionValue = 0;

	// Use this for initialization
	void Start () 
	{
		gameCanvas.enabled = false;
		titleCardDM.StartDialogue(titleCardLM);
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

	public void UpdateStrangeAndSuspicionValues(int lineNumber, LineManager lineManager)
	{
		strangeValue += lineManager.strangeValues[lineNumber];
		suspicionValue += lineManager.suspicionValues[lineNumber];

		Debug.Log(strangeValue);
		Debug.Log(suspicionValue);
	}

	public string GetSpeaker(int lineNumber, LineManager lineManager)
	{
		return lineManager.speakerNames[lineNumber];
	}
}