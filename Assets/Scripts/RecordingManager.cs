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
	public RectTransform needle;

	public bool isRecording = false;

	// Use this for initialization
	void Start () 
	{
		filmMeterFill = filmMeterFill.GetComponent<Image>();
		recordButton = recordButton.GetComponent<Button>();
		stopButton = stopButton.GetComponent<Button>();
		dangerMeterFill = dangerMeterFill.GetComponent<Image>();
		weirdMeter = weirdMeter.GetComponent<Image>();
		needle = needle.GetComponent<RectTransform>();
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
			filmMeterFill.fillAmount -= 0.0005f;
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
//		needle.rotation *= Quaternion.Euler (0, 0, -actManager.suspicionValue);
//		Mathf.Clamp (needle.rotation.z, 0, -280);
		float newZ = Mathf.Lerp(0, -280, actManager.totalSuspicion / 200f);
		needle.rotation = Quaternion.Euler(0, 0, newZ);
		Debug.Log ("Suspicion value: " + actManager.suspicionValue);
		Debug.Log ("total value: " + actManager.totalSuspicion);
		CheckIfLoseGame();
		weirdMeter.fillAmount += (actManager.strangeValue / 200f);
	}

	public void CheckIfLoseGame()
	{
		if (actManager.totalSuspicion >= 200)
		{
			actManager.LoseGame();
		}

		return;
	}
}
