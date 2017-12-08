using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClickStartGame : MonoBehaviour 
{

	public void LoadFirstAct()
	{
		SceneManager.LoadScene(1);
	}
}
