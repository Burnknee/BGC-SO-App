using UnityEngine;
using System.Collections;

public class AdminSettingsBtn : MonoBehaviour {

	private GameObject GameEngine;
	private GameObject AdminSettingsWindow;
	//public GameObject AdminSettings;
	public GameObject titleLabel;

	
	// Use this for initialization
	void Start () {
		
		GameEngine = GameObject.Find ("GameEngine");
		AdminSettingsWindow = GameObject.Find ("AdminSettingsWindow");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnClick()
	{
		titleLabel.GetComponent<UILabel>().text = "Settings";
		GameEngine.GetComponent<MenuManager>().updateBackButtonAnims (5);
		AdminSettingsWindow.GetComponent<AdminSettingsManager>().Group_Clicked(0);
	}

}
