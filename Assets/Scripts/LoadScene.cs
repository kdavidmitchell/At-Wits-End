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
		Invoke("ChooseSceneToLoad", 5f);
	}

	void ChooseSceneToLoad()
	{
		if (actManager.gameDM.currentAct == 1)
		{
			SceneManager.LoadScene(2);
		} else if (actManager.gameDM.currentAct == 2)
		{
			SceneManager.LoadScene(3);
		} else if (actManager.gameDM.currentAct == 3)
		{
			SceneManager.LoadScene(4);
		} else if (actManager.gameDM.currentAct == 4)
		{
			SceneManager.LoadScene(5);
		}
	}
}
