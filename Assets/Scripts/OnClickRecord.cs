using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickRecord : MonoBehaviour 
{

	private RecordingManager recordingManager;

	void Start()
	{
		recordingManager = GameObject.Find("ActManager").GetComponent<RecordingManager>();
	}

	public void SwitchToRecordingMode()
	{
		recordingManager.isRecording = true;
	}
}
