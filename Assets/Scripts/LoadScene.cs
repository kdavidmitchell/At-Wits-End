using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
	private ActManager actManager;
	
	void Start()
	{
		actManager = GameObject.Find("ActManager").GetComponent<ActManager>();
	}

	public void LoadSceneOnLastLine()
	{
		actManager.recordingManager.isRecording = false;

		Invoke("ChooseSceneToLoad", 5f);
	}

	void ChooseSceneToLoad()
	{
		if (actManager.gameDM.currentAct == 1)
		{
			GameInformation.TotalStrange = actManager.totalStrange;
			SaveInformation.SaveAllInformation();
			SceneManager.LoadScene(2);
		} else if (actManager.gameDM.currentAct == 2)
		{
			GameInformation.TotalStrange += actManager.totalStrange;
			SaveInformation.SaveAllInformation();
			SceneManager.LoadScene(3);
		} else if (actManager.gameDM.currentAct == 3)
		{
			GameInformation.TotalStrange += actManager.totalStrange;
			SaveInformation.SaveAllInformation();
			SceneManager.LoadScene(4);
		} else if (actManager.gameDM.currentAct == 4)
		{
			GameInformation.TotalStrange += actManager.totalStrange;
			SaveInformation.SaveAllInformation();
			SceneManager.LoadScene(5);
		} else if (actManager.gameDM.currentAct == 6)
		{
			SaveInformation.SaveAllInformation();
			SceneManager.LoadScene(9);
		} else if (actManager.gameDM.currentAct == 7)
		{
			SaveInformation.SaveAllInformation();
			SceneManager.LoadScene(9);
		}
	}
}
