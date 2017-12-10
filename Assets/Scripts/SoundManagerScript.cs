using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour {

	AudioSource clickOutSource;
	AudioSource clickInSource;
	AudioSource waves;
	AudioSource bgm;

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

	public void PlayMusic(string music){
		if (bgm == null) {
			bgm = this.gameObject.AddComponent<AudioSource> ();
		}
		switch (music){
		case "waves":
			bgm.clip = Resources.Load <AudioClip> ("Sounds/bgm/400632__inspectorj__ambience-seaside-waves-close-a");
			bgm.loop = true;
			bgm.volume = .25f;
			bgm.Play ();
			break;

		case "synth":
			bgm.clip = Resources.Load <AudioClip> ("Sounds/bgm/108952__fons__sphere110-70");
			bgm.loop = true;
			bgm.volume = .35f;
			bgm.Play ();
			break;
		}
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

		case "startWaves":
			waves = this.gameObject.AddComponent<AudioSource> ();
			waves.clip = Resources.Load <AudioClip> ("Sounds/bgm/400632__inspectorj__ambience-seaside-waves-close-a");
			waves.loop = true;
			waves.volume = .25f;
			waves.Play ();
			//StartCoroutine(WaitAndDestroy(2f, clickInSource));
			break;
		}
	}
}
