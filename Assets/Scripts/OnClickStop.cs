using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickStop : MonoBehaviour 
{

	private RecordingManager recordingManager;

	void Start()
	{
		recordingManager = GameObject.Find("ActManager").GetComponent<RecordingManager>();
	}

	public void SwitchToStopMode()
	{
		recordingManager.isRecording = false;
	}
}
