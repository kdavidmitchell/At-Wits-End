using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadInformation 
{

	public static void LoadAllInformation()
	{
		GameInformation.TotalStrange = PlayerPrefs.GetFloat("TOTAL_STRANGE");
	}
}
