using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour {

	AudioSource clickOutSource;
	AudioSource clickInSource;

	void Start () {
		
	}

	void Update () {
	}


	IEnumerator WaitAndDestroy(float time, AudioSource source)
	{
		// suspend execution for 5 seconds
		yield return new WaitForSeconds(time);
		Destroy (source);
	}

	public void PlaySound(string soundClip){		
		switch (soundClip) {
		case "stopClicked":
			clickOutSource = this.gameObject.AddComponent<AudioSource> ();
			clickOutSource.clip = Resources.Load <AudioClip> ("Sounds/clickOUT");
			clickOutSource.Play ();
			StartCoroutine(WaitAndDestroy(2f, clickOutSource));
			break;

		case "startClicked":
			clickInSource = this.gameObject.AddComponent<AudioSource> ();
			clickInSource.clip = Resources.Load <AudioClip> ("Sounds/clickIN");
			clickInSource.Play ();
			StartCoroutine(WaitAndDestroy(2f, clickInSource));
			break;
		}
	}
}
