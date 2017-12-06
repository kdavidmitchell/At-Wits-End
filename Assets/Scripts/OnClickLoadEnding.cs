using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClickLoadEnding : MonoBehaviour 
{

	public void LoadBurnEnding()
	{
		SceneManager.LoadScene(7);
	}

	public void LoadKeepEnding()
	{
		SceneManager.LoadScene(8);
	}
}
