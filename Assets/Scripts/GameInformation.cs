using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInformation : MonoBehaviour 
{

	void Awake () 
	{
		DontDestroyOnLoad(gameObject);
	}

	public static float TotalStrange {get;set;}
}
