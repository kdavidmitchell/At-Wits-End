using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGlowScript : MonoBehaviour {

	Button myButton;
	RecordingManager recMan;
	float timer = 0f;
	float timerMax = 1.5f;
	ColorBlock cb;
	bool increasingValue;
	public bool weAreInteractable = false;
	public Animator uiAnimator;
	SoundManagerScript sms;

	// Use this for initialization
	void Start () {
		myButton = GetComponentInParent<Button>();	
		recMan = FindObjectOfType<RecordingManager> ();
		sms = FindObjectOfType<SoundManagerScript> ();
		cb = myButton.colors;
	}
	
	// Update is called once per frame
	void Update () {
		//color changing logic
		if(recMan.isRecording){
			timer += Time.deltaTime;
			if (timer >= timerMax) {
				CheckAndChangeColor ();
				timer = 0f;			
			}			
		}
	}

	void CheckAndChangeColor(){
		if (myButton.colors.normalColor.r == .0f) {
			cb = myButton.colors;
			cb.normalColor = new Color (.25f, 0f, 0f, 1f);
			myButton.colors = cb;
			increasingValue = true;
		} else if (myButton.colors.normalColor.r == .25f && increasingValue) {
			cb = myButton.colors;
			cb.normalColor = new Color (.5f, 0f, 0f, 1f);
			myButton.colors = cb;
		} else if (myButton.colors.normalColor.r == .25f && !increasingValue) {
			cb = myButton.colors;
			cb.normalColor = new Color (.0f, 0f, 0f, 1f);
			myButton.colors = cb;
		} else {
			cb = myButton.colors;
			cb.normalColor = new Color (.25f, 0f, 0f, 1f);
			myButton.colors = cb;
			increasingValue = false;
		}
	}

	public void ChangeInteractableStatus(){
		if (recMan.isRecording) {
			myButton.interactable = true;
			sms.PlaySound ("stopClicked");
		} else {
			myButton.interactable = false;
			cb = myButton.colors;
			cb.normalColor = new Color (.0f, 0f, 0f, 1f);
			myButton.colors = cb;
			uiAnimator.SetTrigger ("stopClicked");
			sms.PlaySound ("startClicked");
		}
	}
}
