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

	// Use this for initialization
	void Start () 
	{
		recordingUI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void EnableRecordingUI()
	{
		recordingUI.SetActive(true);
	}
}
