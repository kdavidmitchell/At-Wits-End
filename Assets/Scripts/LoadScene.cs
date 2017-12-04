using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene
{
	
	public static void LoadSceneOnLastLine(int sceneIndex)
	{
		SceneManager.LoadScene(sceneIndex);
	}
}
