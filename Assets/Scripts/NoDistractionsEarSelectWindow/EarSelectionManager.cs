using UnityEngine;
using System.Collections;

public class EarSelectionManager : MonoBehaviour {

	public int earMode; //0=>Left 1=>Right 2=>Both

	public GameObject Left_CheckBox;
	public GameObject Right_CheckBox;
	public GameObject Both_CheckBox;


	// Use this for initialization
	void Start () {
	
		Left_CheckBox.GetComponent<UICheckbox>().isChecked = false;
		Right_CheckBox.GetComponent<UICheckbox>().isChecked = false;
		Both_CheckBox.GetComponent<UICheckbox>().isChecked = true;


		earMode = 2;
	}

	public void updateEarSelect(bool new_status, int Type)
	{

		if(Type == 0)// Left Ear
		{
			if(new_status == true)
			{
				Left_CheckBox.GetComponent<UICheckbox>().isChecked = true;
				Right_CheckBox.GetComponent<UICheckbox>().isChecked = false;
				Both_CheckBox.GetComponent<UICheckbox>().isChecked = false;
				earMode = 0;
			}
			else if (new_status == false  && Right_CheckBox.GetComponent<UICheckbox>().isChecked == false && Both_CheckBox.GetComponent<UICheckbox>().isChecked == false)
			{
				Left_CheckBox.GetComponent<UICheckbox>().isChecked = true;
				Right_CheckBox.GetComponent<UICheckbox>().isChecked = false;
				Both_CheckBox.GetComponent<UICheckbox>().isChecked = false;
				earMode = 0;

			}


		}
		else if(Type == 1)// Right
		{
			if(new_status == true)
			{
				Left_CheckBox.GetComponent<UICheckbox>().isChecked = false;
				Right_CheckBox.GetComponent<UICheckbox>().isChecked = true;
				Both_CheckBox.GetComponent<UICheckbox>().isChecked = false;
				earMode = 1;
			}
			else if (new_status == false  && Left_CheckBox.GetComponent<UICheckbox>().isChecked == false && Both_CheckBox.GetComponent<UICheckbox>().isChecked == false)
			{
				Left_CheckBox.GetComponent<UICheckbox>().isChecked = false;
				Right_CheckBox.GetComponent<UICheckbox>().isChecked = true;
				Both_CheckBox.GetComponent<UICheckbox>().isChecked = false;
				earMode = 1;
				
			}
			
			
		}
		else if(Type == 2)// Left Ear
		{
			if(new_status == true)
			{
				Left_CheckBox.GetComponent<UICheckbox>().isChecked = false;
				Right_CheckBox.GetComponent<UICheckbox>().isChecked = false;
				Both_CheckBox.GetComponent<UICheckbox>().isChecked = true;
				earMode = 2;
			}
			else if (new_status == false  && Right_CheckBox.GetComponent<UICheckbox>().isChecked == false && Left_CheckBox.GetComponent<UICheckbox>().isChecked == false)
			{
				Left_CheckBox.GetComponent<UICheckbox>().isChecked = false;
				Right_CheckBox.GetComponent<UICheckbox>().isChecked = false;
				Both_CheckBox.GetComponent<UICheckbox>().isChecked = true;
				earMode = 2;
				
			}
			
			
		}

	}



}
