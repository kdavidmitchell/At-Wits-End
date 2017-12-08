using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickHelp : MonoBehaviour 
{

	public Image helpMenu;
	public Text helpHeader;
	public Text helpText;
	public Image returnButtonImage;
	public Text returnButtonText;

	// Use this for initialization
	void Start () 
	{
		helpMenu.enabled = false;
		helpHeader.enabled = false;
		helpText.enabled = false;
		returnButtonImage.enabled = false;
		returnButtonText.enabled = false;	
	}
	
	public void EnableHelpMenu()
	{
		helpMenu.enabled = true;
		helpHeader.enabled = true;
		helpText.enabled = true;
		returnButtonImage.enabled = true;
		returnButtonText.enabled = true;
	}

	public void DisableHelpMenu()
	{
		helpMenu.enabled = false;
		helpHeader.enabled = false;
		helpText.enabled = false;
		returnButtonImage.enabled = false;
		returnButtonText.enabled = false;
	}
}
