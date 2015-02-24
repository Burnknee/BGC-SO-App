using UnityEngine;
using System.Collections;

public class GeneralOpManager : MonoBehaviour {

	// 0 => Progressive : 1 => Adaptive 
	public int testType;
	public GameObject Pro_CheckBox;
	public GameObject Ada_CheckBox;
	public GameObject DB_Offset_Label;
	public GameObject Target_Offset_Label;

	// Use this for initialization
	void Start () {
		//Initial Values
		int DB_Offset = 10;
		int Target_Offset = 10;
		testType = 0;
		Pro_CheckBox.GetComponent<UICheckbox>().isChecked = true;
		Ada_CheckBox.GetComponent<UICheckbox>().isChecked = false;

		DB_Offset_Label.GetComponent<UILabel>().text = DB_Offset.ToString();
		Target_Offset_Label.GetComponent<UILabel>().text = Target_Offset.ToString();
	
	}

	public void UpdateTestType( bool new_status, int Type)
	{
		if(Type == 0)
		{

			if(new_status && Ada_CheckBox.GetComponent<UICheckbox>().isChecked)
			{
				Ada_CheckBox.GetComponent<UICheckbox>().isChecked = false;
				testType = 0;

			}
			else if(!new_status && !Ada_CheckBox.GetComponent<UICheckbox>().isChecked)
			{
				Pro_CheckBox.GetComponent<UICheckbox>().isChecked = true;
				testType = 0;

			}
		}
		else if (Type == 1)
		{

			if(new_status && Pro_CheckBox.GetComponent<UICheckbox>().isChecked)
			{
				Pro_CheckBox.GetComponent<UICheckbox>().isChecked = false;
				testType = 1;

			}
			else if(!new_status && !Pro_CheckBox.GetComponent<UICheckbox>().isChecked)
			{
				Ada_CheckBox.GetComponent<UICheckbox>().isChecked = true;
				testType = 1;

			}
		}
	}
}
