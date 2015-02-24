using UnityEngine;
using System.Collections;

public class EmailOpBtn : MonoBehaviour {

	public GameObject SettingsWindow;

	void OnClick()
	{
		SettingsWindow.GetComponent<AdminSettingsManager>().Group_Clicked(1);
	
	}
}
