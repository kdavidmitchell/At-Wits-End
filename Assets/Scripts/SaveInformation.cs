using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveInformation 
{

	public static void SaveAllInformation()
	{
		PlayerPrefs.SetFloat("TOTAL_STRANGE", GameInformation.TotalStrange);
	}
}
