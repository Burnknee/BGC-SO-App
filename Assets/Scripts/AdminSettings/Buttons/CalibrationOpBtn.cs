﻿using UnityEngine;
using System.Collections;

public class CalibrationOpBtn : MonoBehaviour {

	public GameObject SettingsWindow;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnClick()
	{
		SettingsWindow.GetComponent<AdminSettingsManager>().Group_Clicked(4);
		
	}
}
