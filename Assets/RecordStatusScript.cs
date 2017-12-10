using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordStatusScript : MonoBehaviour {

	RecordingManager recMan;

	// Use this for initialization
	void Start () {
		recMan = FindObjectOfType<RecordingManager> ();
//		Debug.Log (recMan);
	}
	
	public void SetCanRecord()
	{
		if (recMan != null) {
			recMan.canRecord = true;
		}
	}

	public void SetCannotRecord()
	{
		if (recMan != null) {
			recMan.canRecord = false;
		}
	}
}
