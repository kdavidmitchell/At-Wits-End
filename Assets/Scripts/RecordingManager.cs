using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordingManager : MonoBehaviour 
{
	public GameObject recordingUI;
	public ActManager actManager;
	public Image filmMeterFill;
	public Button recordButton;
	public Button stopButton;
	public Image dangerMeterFill;
	public Image weirdMeter;

	public bool isRecording = false;

	// Use this for initialization
	void Start () 
	{
		filmMeterFill = filmMeterFill.GetComponent<Image>();
		recordButton = recordButton.GetComponent<Button>();
		stopButton = stopButton.GetComponent<Button>();
		dangerMeterFill = dangerMeterFill.GetComponent<Image>();
		weirdMeter = weirdMeter.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isRecording)
		{
			if (filmMeterFill.fillAmount <= 0)
			{
				isRecording = false;
			}
			filmMeterFill.fillAmount -= 0.001f;
		} else 
		{
			stopButton.interactable = false;
			recordButton.interactable = true;
		}
	}

	public void DisableRecordAndEnableStop()
	{
		recordButton.interactable = false;
		stopButton.interactable = true;
	}

	public void UpdateMeters()
	{
		dangerMeterFill.fillAmount += (actManager.suspicionValue / 200f);
		CheckIfLoseGame();
		weirdMeter.fillAmount += (actManager.strangeValue / 200f);
	}

	public void CheckIfLoseGame()
	{
		if (dangerMeterFill.fillAmount >= 1)
		{
			actManager.LoseGame();
		}

		return;
	}
}
