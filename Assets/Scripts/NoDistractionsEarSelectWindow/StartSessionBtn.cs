/***

This button is the one pressed before the actual test is outputted

 **/
using UnityEngine;
using System.Collections;


public class StartSessionBtn : MonoBehaviour {

	private GameObject GameEngine;

	public GameObject SessionID_GO;
	public int SessionType;	//For now its always NoDistractions
	public GameObject EarOutputWindow;
	public GameObject CoLocal_Input_Right;
	public GameObject CoLocal_Input_Left;
	public GameObject GeneralWindow;
	public GameObject ProWindow;
	public GameObject AdaptWindow;
	public GameObject StartTestBtn;

	public GameObject BackButton;

	//Labels 
	public GameObject Gen_DB_Offset_Label;
	public GameObject Gen_Target_Offset_Label;
	public GameObject Pro_Step_Size_Label;
	public GameObject Pro_Steps_Label;
	public GameObject Pro_Tracks_Label;

	//Start Behavior on Test 
	public GameObject StartButtonOnTest;

	//For Reseting Log File!
	public GameObject submitBtn;

	
	// Use this for initialization
	void Start () {
		
		GameEngine = GameObject.Find ("GameEngine");
	}

	void OnClick()
	{
		GameEngine.GetComponent<TestManager>().logFileStepNum = 0;

		//reset log file!
		submitBtn.GetComponent<SubmitBtn>().LogFileColumn = "";

		//Update ConversionArray!
		GameEngine.GetComponent<TestManager>().UpdateConversionArray();

		//Reset possible numbers
		StartButtonOnTest.GetComponent<StartBehavior>().sizeOfPossibleNumbers = 8;
		for(int i = 0; i < 8; i++)
		{
			StartButtonOnTest.GetComponent<StartBehavior>().possibleNumbers[i] = true;
		}

		//Reset possible talkers
		StartButtonOnTest.GetComponent<StartBehavior>().sizeOfPossibleTalkers = 4;
		for(int i = 0; i < 4; i++)
		{
			StartButtonOnTest.GetComponent<StartBehavior>().possibleTalkers[i] = true;
		}

		//Getting The Session Type!
		if(GameEngine.GetComponent<MenuManager>().menu_lvl == 2)
		{
			SessionType = 0;
		}
		else if(GameEngine.GetComponent<MenuManager>().menu_lvl == 3)
		{
			SessionType = 1;
		}
		else if(GameEngine.GetComponent<MenuManager>().menu_lvl == 4)
		{
			SessionType = 2;
		}
		GameEngine.GetComponent<MenuManager>().updateBackButtonAnims (6);
		GameEngine.GetComponent<TestManager>().isDone = false;

		//Send Infomation to TestManager
		/*
		 * Other: Session of Test: 0:NoDistractions   1:CoLocalized  2:SpatialOffset 
		 * 
		 * 
		 * 
		 * General: TestType 0:Progressive 1:Adaptive
		 * 			DB Offset
		 * 			Target OFfset
		 * 
		 * Progressive:
		 * 
		 * 			StepSize
		 * 			Number of Steps/Trials
		 * 			Number of Tracks
		 * 
		 * Adaptive:
		 * 
		 * 			StepSize_1
		 * 			StepSize_2
		 * 			Reversal_1
		 * 			Reversal_2
		 * 
		 * 
		 * */

		//To get rid of the input problem on general options im going to
		// read the labels when i press the start button
		int db_temp;
		int tar_temp;
		int stepsize_temp;
		int steps_temp;
		int tracks_temp;

		//adpt temp variables!
		int stepsize_1_temp;
		int stepsize_2_temp;
		int rev_1_temp;
		int rev_2_temp;

		bool possible = int.TryParse(Gen_DB_Offset_Label.GetComponent<UILabel>().text, out db_temp);
		if(!possible)
		{
			Debug.Log("Error parsing DB Offset");
			db_temp = 0;
		}

		possible = int.TryParse(Gen_Target_Offset_Label.GetComponent<UILabel>().text, out tar_temp);
		if(!possible)
		{
			Debug.Log("Error parsing Target Offset");
			tar_temp = 0;
		}

		possible = int.TryParse(Pro_Step_Size_Label.GetComponent<UILabel>().text, out stepsize_temp);
		if(!possible)
		{
			Debug.Log("Error parsing Pro Step Size");
			stepsize_temp = 0;
		}

		possible = int.TryParse(Pro_Steps_Label.GetComponent<UILabel>().text, out steps_temp);
		if(!possible)
		{
			Debug.Log("Error parsing Pro Steps");
			steps_temp = 0;
		}

		possible = int.TryParse(Pro_Tracks_Label.GetComponent<UILabel>().text, out tracks_temp);
		if(!possible)
		{
			Debug.Log("Error parsing Pro Tracks");
			tracks_temp = 0;
		}


		GameEngine.GetComponent<TestManager>().talker_DB = db_temp + tar_temp;

		//Adaptive variables!
		GameEngine.GetComponent<TestManager>().prev_ans = 0;
		GameEngine.GetComponent<TestManager>().new_ans = 0;
		GameEngine.GetComponent<TestManager>().is_first_adpt = true;
		GameEngine.GetComponent<TestManager>().adpt_trial = 1;





		GameEngine.GetComponent<TestManager>().Update_data(SessionID_GO.GetComponent<UILabel>().text,
		                                                   SessionType, 
		                                                   EarOutputWindow.GetComponent<EarSelectionManager>().earMode, 
		                                                   CoLocal_Input_Right.GetComponent<UILabel>().text, 
		                                                   CoLocal_Input_Left.GetComponent<UILabel>().text, 
		                                                   GeneralWindow.GetComponent<GeneralOpManager>().testType, 
		                                                   db_temp, 
		                                                   tar_temp, 
		                                                   tracks_temp, 
		                                                   steps_temp, 
		                                                   stepsize_temp, 
		                                                   AdaptWindow.GetComponent<AdaptiveOpManager>().StepSize_1, 
		                                                   AdaptWindow.GetComponent<AdaptiveOpManager>().StepSize_2, 
		                                                   AdaptWindow.GetComponent<AdaptiveOpManager>().Reversal_1, 
		                                                   AdaptWindow.GetComponent<AdaptiveOpManager>().Reversal_2);
	}

}
