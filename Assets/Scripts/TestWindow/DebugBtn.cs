using UnityEngine;
using System.Collections;

public class DebugBtn : MonoBehaviour {

	public GameObject DebugBtnBackground;
	public GameObject DebugWindow;

	// Use this for initialization
	void Start () {
	
		if(DebugBtnBackground)
		{
			DebugBtnBackground.SetActive(false);
		}

		if(DebugWindow)
		{
			DebugWindow.SetActive(false);
		}

	}
	public void resetButton()
	{
		DebugBtnBackground.SetActive(false);
		DebugWindow.SetActive(false);
	}

	void OnClick()
	{
		if(DebugBtnBackground.activeSelf)
		{
			DebugBtnBackground.SetActive(false);
			DebugWindow.SetActive(false);
		}
		else
		{
			//DebugWindow.GetComponent<DebugPopUpManager>().UpdateDebugWindow();
			DebugBtnBackground.SetActive(true);
			DebugWindow.SetActive(true);
		}
	}

	void Update()
	{
		if(DebugWindow.activeSelf)
		{
			DebugWindow.GetComponent<DebugPopUpManager>().UpdateDebugWindow();
		}
	}
}
