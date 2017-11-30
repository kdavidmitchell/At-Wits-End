using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordingManager : MonoBehaviour 
{
	public GameObject recordingUI;
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
		stopButton = recordButton.GetComponent<Button>();
		dangerMeterFill = dangerMeterFill.GetComponent<Image>();
		weirdMeter = weirdMeter.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isRecording)
		{
			DisableRecordAndEnableStop();
		}
	}

	private void DisableRecordAndEnableStop()
	{
		recordButton.enabled = false;
		stopButton.enabled = true;
	}
}
