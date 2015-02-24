using UnityEngine;
using System.Collections;

public class DebugPopUpManager : MonoBehaviour {

	private GameObject GameEngine;

	public GameObject sessionTypeLabel;

	public GameObject correctAnswerLabel;
	public GameObject correctAnswerVolLabel;

	public GameObject distractorOneLabel;
	public GameObject distractorOneVolLabel;

	public GameObject distractorTwoLabel;
	public GameObject distractorTwoVolLabel;

	public GameObject currentChoiceLabel;
	// Use this for initialization
	int tempInt = 0;
	string tempString = "";
	float tempFloat = 0.0f;
	void Start () {
		GameEngine = GameObject.Find("GameEngine");
	}

	public void UpdateDebugWindow()
	{

		//Update the Test Name:
		if(GameEngine.GetComponent<TestManager>().TestType == null)
		{
			tempInt = 0;
		}
		else
		{
			//Exception!
			//Debug.Log (GameEngine.GetComponent<TestManager>().TestType);
			tempInt = GameEngine.GetComponent<TestManager>().TestType;
		}
		if(tempInt == 0)
		{
			sessionTypeLabel.GetComponent<UILabel>().text = "Progressive";
		}
		else if(tempInt == 1)
		{
			sessionTypeLabel.GetComponent<UILabel>().text = "Adaptive";
		}

		/*********************************************************************************************************/
		/************************************************   Target   *********************************************/
		/*********************************************************************************************************/

		//Update Correct Talker and Name
		correctAnswerLabel.GetComponent<UILabel>().text = "Target Talker: ";
		tempInt = GameEngine.GetComponent<TestManager>().targetTalker;


		correctAnswerLabel.GetComponent<UILabel>().text += tempInt + " :: ";
		tempInt = GameEngine.GetComponent<TestManager>().targetName;

		if(tempInt == 0)
		{
			correctAnswerLabel.GetComponent<UILabel>().text += "Charlie ";
		}
		else if(tempInt == 1)
		{
			correctAnswerLabel.GetComponent<UILabel>().text += "Ringo ";
		}
		else if(tempInt == 2)
		{
			correctAnswerLabel.GetComponent<UILabel>().text += "Laker ";
		}
		else if(tempInt == 3)
		{
			correctAnswerLabel.GetComponent<UILabel>().text += "Hopper ";
		}
		else if(tempInt == 4)
		{
			correctAnswerLabel.GetComponent<UILabel>().text += "Arrow ";
		}
		else if(tempInt == 5)
		{
			correctAnswerLabel.GetComponent<UILabel>().text += "Tiger ";
		}
		else if(tempInt == 6)
		{
			correctAnswerLabel.GetComponent<UILabel>().text += "Eagle ";
		}
		else if(tempInt == 7)
		{
			correctAnswerLabel.GetComponent<UILabel>().text += "Baron ";
		}
		else 
		{
			correctAnswerLabel.GetComponent<UILabel>().text += "None ";
		}


		//Update Correct Answer Color
		tempString = GameEngine.GetComponent<TestManager>().currentColor;

		if(tempString == "00")
		{
			correctAnswerLabel.GetComponent<UILabel>().text += "Blue ";
		}
		else if(tempString == "01")
		{
			correctAnswerLabel.GetComponent<UILabel>().text += "Red ";
		}
		else if(tempString == "02")
		{
			correctAnswerLabel.GetComponent<UILabel>().text += "White ";
		}
		else if(tempString == "03")
		{
			correctAnswerLabel.GetComponent<UILabel>().text += "Green ";
		}
		else
		{
			//Has not pressed go yet!
		}

		//Update Correct Answer Number
		tempString = GameEngine.GetComponent<TestManager>().currentNumber;

		if(tempString == "00")
		{
			correctAnswerLabel.GetComponent<UILabel>().text += "1";
		}
		else if(tempString == "01")
		{
			correctAnswerLabel.GetComponent<UILabel>().text += "2";
		}
		else if(tempString == "02")
		{
			correctAnswerLabel.GetComponent<UILabel>().text += "3";
		}
		else if(tempString == "03")
		{
			correctAnswerLabel.GetComponent<UILabel>().text += "4";
		}
		else if(tempString == "04")
		{
			correctAnswerLabel.GetComponent<UILabel>().text += "5";
		}
		else if(tempString == "05")
		{
			correctAnswerLabel.GetComponent<UILabel>().text += "6";
		}
		else if(tempString == "06")
		{
			correctAnswerLabel.GetComponent<UILabel>().text += "7";
		}
		else if(tempString == "07")
		{
			correctAnswerLabel.GetComponent<UILabel>().text += "8";
		}
		else 
		{
			//Go Not Pressed Yet
		}

		/*
		//Update Correct Answer Volume
		//Have to check if any of these are null!
		if(GameEngine.GetComponent<TestManager>().talker_DB != null)
		{
			tempInt = GameEngine.GetComponent<TestManager>().talker_DB;
		}
		else
		{
			tempInt = 0;
		}
		if(GameEngine.GetComponent<TestManager>().DB_Conversion != null)
		{
			tempFloat = GameEngine.GetComponent<TestManager>().DB_Conversion;
		}
		else
		{
			tempFloat = 0.0f;
		}

		correctAnswerVolLabel.GetComponent<UILabel>().text = "Vol: "+tempInt+" (DB) and "+tempInt*tempFloat+" (Unity)";
		*/




		/*********************************************************************************************************/
		/******************************************   Distractor 1   *********************************************/
		/*********************************************************************************************************/

		//Update Distractor 1 Info:
		//Only do this if the sessionType is not 1!
		if( GameEngine.GetComponent<TestManager>().SessionType != 0)
		{
			tempInt = GameEngine.GetComponent<TestManager>().distractorOneTalker;
			
			
			distractorOneLabel.GetComponent<UILabel>().text = "D1 Talker: " + tempInt;
			
			distractorOneLabel.GetComponent<UILabel>().text += " :: ";
			tempInt = GameEngine.GetComponent<TestManager>().distractorOneName;
			
			if(tempInt == 0)
			{
				distractorOneLabel.GetComponent<UILabel>().text += "Charlie ";
			}
			else if(tempInt == 1)
			{
				distractorOneLabel.GetComponent<UILabel>().text += "Ringo ";
			}
			else if(tempInt == 2)
			{
				distractorOneLabel.GetComponent<UILabel>().text += "Laker ";
			}
			else if(tempInt == 3)
			{
				distractorOneLabel.GetComponent<UILabel>().text += "Hopper ";
			}
			else if(tempInt == 4)
			{
				distractorOneLabel.GetComponent<UILabel>().text += "Arrow ";
			}
			else if(tempInt == 5)
			{
				distractorOneLabel.GetComponent<UILabel>().text += "Tiger ";
			}
			else if(tempInt == 6)
			{
				distractorOneLabel.GetComponent<UILabel>().text += "Eagle ";
			}
			else if(tempInt == 7)
			{
				distractorOneLabel.GetComponent<UILabel>().text += "Baron ";
			}
			else 
			{
				distractorOneLabel.GetComponent<UILabel>().text += "None ";
			}
			
			//Color
			tempInt = GameEngine.GetComponent<TestManager>().distractorOneColor;
			
			if(tempInt == 0)
			{
				distractorOneLabel.GetComponent<UILabel>().text += "Blue "; 
			}
			else if(tempInt == 1)
			{
				distractorOneLabel.GetComponent<UILabel>().text += "Red "; 
			}
			else if(tempInt == 2)
			{
				distractorOneLabel.GetComponent<UILabel>().text += "White "; 
			}
			else if(tempInt == 3)
			{
				distractorOneLabel.GetComponent<UILabel>().text += "Green "; 
			}
			else 
			{
				distractorOneLabel.GetComponent<UILabel>().text += "None ";
			}
			
			//Number
			
			tempInt = GameEngine.GetComponent<TestManager>().distractorOneNumber + 1;
			
			distractorOneLabel.GetComponent<UILabel>().text += tempInt;
		}

		else
		{
			distractorOneLabel.GetComponent<UILabel>().text = "None ";
		}


		//Add Volume Info:

		/*********************************************************************************************************/
		/******************************************   Distractor 2   *********************************************/
		/*********************************************************************************************************/
		
		//Update Distractor 2 Info:
		//Only do this if the sessionType is not 0!
		if( GameEngine.GetComponent<TestManager>().SessionType != 0)
		{
			tempInt = GameEngine.GetComponent<TestManager>().distractorTwoTalker;
			
			
			distractorTwoLabel.GetComponent<UILabel>().text = "D2 Talker: " + tempInt;
			
			distractorTwoLabel.GetComponent<UILabel>().text += " :: ";
			tempInt = GameEngine.GetComponent<TestManager>().distractorTwoName;
			
			if(tempInt == 0)
			{
				distractorTwoLabel.GetComponent<UILabel>().text += "Charlie ";
			}
			else if(tempInt == 1)
			{
				distractorTwoLabel.GetComponent<UILabel>().text += "Ringo ";
			}
			else if(tempInt == 2)
			{
				distractorTwoLabel.GetComponent<UILabel>().text += "Laker ";
			}
			else if(tempInt == 3)
			{
				distractorTwoLabel.GetComponent<UILabel>().text += "Hopper ";
			}
			else if(tempInt == 4)
			{
				distractorTwoLabel.GetComponent<UILabel>().text += "Arrow ";
			}
			else if(tempInt == 5)
			{
				distractorTwoLabel.GetComponent<UILabel>().text += "Tiger ";
			}
			else if(tempInt == 6)
			{
				distractorTwoLabel.GetComponent<UILabel>().text += "Eagle ";
			}
			else if(tempInt == 7)
			{
				distractorTwoLabel.GetComponent<UILabel>().text += "Baron ";
			}
			else 
			{
				distractorTwoLabel.GetComponent<UILabel>().text += "None ";
			}
			
			//Color
			tempInt = GameEngine.GetComponent<TestManager>().distractorTwoColor;
			
			if(tempInt == 0)
			{
				distractorTwoLabel.GetComponent<UILabel>().text += "Blue "; 
			}
			else if(tempInt == 1)
			{
				distractorTwoLabel.GetComponent<UILabel>().text += "Red "; 
			}
			else if(tempInt == 2)
			{
				distractorTwoLabel.GetComponent<UILabel>().text += "White "; 
			}
			else if(tempInt == 3)
			{
				distractorTwoLabel.GetComponent<UILabel>().text += "Green "; 
			}
			else 
			{
				distractorTwoLabel.GetComponent<UILabel>().text += "None ";
			}
			
			//Number
			
			tempInt = GameEngine.GetComponent<TestManager>().distractorTwoNumber + 1;
			
			distractorTwoLabel.GetComponent<UILabel>().text += tempInt;
		}
		
		else
		{
			distractorTwoLabel.GetComponent<UILabel>().text = "None ";
		}




		//Add Volume Info:


		/*********************************************************************************************************/
		/******************************************   Current Choice   *******************************************/
		/*********************************************************************************************************/

		currentChoiceLabel.GetComponent<UILabel>().text = "Current Choice: ";
		currentChoiceLabel.GetComponent<UILabel>().text += GameEngine.GetComponent<TestManager>().active_color + " "+GameEngine.GetComponent<TestManager>().active_number;

	}


}
