using UnityEngine;
using System.Collections;

public class Choice : MonoBehaviour {

	public string color;
	public string number; 


	private GameObject GameEngine;
	private GameObject TestSubmitBtn;
	// Use this for initialization
	void Start () {
		GameEngine = GameObject.Find ("GameEngine");
		TestSubmitBtn = GameObject.Find("TestSubmitButton");
	}


	void OnClick()
	{

		if(!GameEngine.GetComponent<TestManager>().WaitingOnStart)
		{

			if(color == "00")
			{
				GameEngine.GetComponent<TestManager>().active_color = "Blue";
			}
			else if(color == "01")
			{
				GameEngine.GetComponent<TestManager>().active_color = "Red";
			}
			else if(color == "02")
			{
				GameEngine.GetComponent<TestManager>().active_color = "White";
			}
			else if(color == "03")
			{
				GameEngine.GetComponent<TestManager>().active_color = "Green";
			}

			if(number == "00")
			{
				GameEngine.GetComponent<TestManager>().active_number = "1";
			}
			else if(number == "01")
			{
				GameEngine.GetComponent<TestManager>().active_number = "2";
			}
			else if(number == "02")
			{
				GameEngine.GetComponent<TestManager>().active_number = "3";
			}
			else if(number == "03")
			{
				GameEngine.GetComponent<TestManager>().active_number = "4";
			}
			else if(number == "04")
			{
				GameEngine.GetComponent<TestManager>().active_number = "5";
			}
			else if(number == "05")
			{
				GameEngine.GetComponent<TestManager>().active_number = "6";
			}
			else if(number == "06")
			{
				GameEngine.GetComponent<TestManager>().active_number = "7";
			}
			else if(number == "07")
			{
				GameEngine.GetComponent<TestManager>().active_number = "8";
			}


			//Send answer to submit button
			TestSubmitBtn.GetComponent<SubmitBtn>().color = color;
			TestSubmitBtn.GetComponent<SubmitBtn>().number = number;
			
			TestSubmitBtn.transform.localPosition = new Vector3(0,-400,0);
			
			GameEngine.GetComponent<TestManager>().UpdateActiveChoice(gameObject);
		}



	}

}
