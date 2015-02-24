using UnityEngine;
using System.Collections;

public class TestManager : MonoBehaviour {

	public bool WaitingOnStart = true;
	public string currentColor = "";
	public string currentNumber = "";
	public int targetTalker = -1;
	public int targetName = -1;

	
	public string SessionID;
	public int SessionType; //0:NoDist 1: Colocal 2: Spatial
	public int EarOutput;   //0:Left 1:Right 2: Both

	public int Colocal_RightOffset;
	public int Colocal_LeftOffset;

	public int TestType;	//0:Progressive 1: Adaptive
	public int Gen_DBOffset;
	public int Gen_TargetOffset;
	
	public int Pro_Tracks;
	public int Pro_Steps;
	public int Pro_StepSize;

	public int Adapt_StepSize_1;
	public int Adapt_StepSize_2;
	public int Adapt_Reversal_1;
	public int Adapt_Reversal_2;
	

	public int Pro_Steps_temp;
	public int Pro_Tracks_temp;
	public int[] TrackCorrect;
	public int Correct_Count = 0;
	public int arrayIndex = 0;

	public bool isDone = false;

	public GameObject TestWindow;
	public GameObject ResultsScreen;
	public GameObject ResultsLabel;

	public GameObject FeedBackLabel;

	private GameObject GameEngine;
	public GameObject BackButton;
	public GameObject BackButtonOffset;

	//Volumes
	public float DB_Conversion = .01f;
	public int talker_DB;

	//Adaptive temp variables
	public int prev_ans = 0;
	public int new_ans = 0;
	public bool is_first_adpt = true;
	public int adpt_trial = 1;

	//Distractor 1 Info:
	//Talker, Name, Color, Number
	public int distractorOneTalker;
	public int distractorOneName;
	public int distractorOneColor;
	public int distractorOneNumber;

	//Distractor 2 Info:
	//Talker, Name, Color, Number
	public int distractorTwoTalker;
	public int distractorTwoName;
	public int distractorTwoColor;
	public int distractorTwoNumber;

	//Choices
	public string active_color = "none";
	public string active_number = "none";

	public GameObject active_choice;

	public float[] dBConversionArray;

	public string currentLogFilePath;
	public string currentSummaryFilePath;

	public int testNum = 0;

	public int logFileStepNum;

	public int logFileTalkerLeftDB;
	public int logFileTalkerRightDB;

	public void UpdateConversionArray()
	{
		 //Read Contents of a Conversion File
		string line;
		System.IO.StreamReader file = 
			new System.IO.StreamReader(Application.persistentDataPath + "/" + "ConversionFiles" + "/" + "default.txt");
		dBConversionArray[0] = 0.0f;
		while((line = file.ReadLine()) != null)
		{
			string temp;
			int locOfSpace = line.IndexOf(' ');
			temp = line.Substring(locOfSpace);
			float decimal_temp = float.Parse(temp); // 7 digits of precision
			temp = line.Substring(0,locOfSpace);
			int index = int.Parse(temp);
			//Debug.Log(index.ToString() + " " + decimal_temp.ToString());
			dBConversionArray[index] = decimal_temp;
		}

		/* Array Check
		for(int i =0; i < dBConversionArray.Length;i++)
		{
			Debug.Log (i.ToString() + " "+ dBConversionArray[i].ToString());
		}*/

	}

	public void returnChoiceOriginal()
	{
		if(active_choice != null)
		{

		}
	}

	public void UpdateActiveChoice(GameObject new_active_Choice)
	{
		if(active_choice != null)
		{
			active_choice.transform.localScale = new Vector3(2,2,1);
			//active_choice.GetComponent<UIButtonScale>().enabled = true;
			string old_color = active_choice.GetComponent<Choice>().color;
			//Debug.Log(old_color);
			if(old_color == "00")
			{
				active_choice.GetComponent<UIButtonColor>().defaultColor = Color.blue;
				active_choice.GetComponentInChildren<UISprite>().color = Color.blue;
			}
			else if(old_color == "01")
			{
				active_choice.GetComponent<UIButtonColor>().defaultColor = Color.red;
				active_choice.GetComponentInChildren<UISprite>().color = Color.red;
			}
			else if(old_color == "02")
			{
				active_choice.GetComponent<UIButtonColor>().defaultColor = Color.white;
				active_choice.GetComponentInChildren<UISprite>().color = Color.white;
			}
			else
			{
				active_choice.GetComponent<UIButtonColor>().defaultColor = Color.green;
				active_choice.GetComponentInChildren<UISprite>().color = Color.green;
			}
			active_choice.GetComponent<UIButtonScale>().enabled = true;



			active_choice = new_active_Choice;
			active_choice.GetComponent<UIButtonScale>().enabled = false;
			active_choice.transform.localScale = new Vector3(2.5f,2.5f,1);
			active_choice.GetComponent<UIButtonColor>().defaultColor = Color.yellow;
			active_choice.GetComponentInChildren<UISprite>().color = Color.yellow;
		}
		else
		{
			active_choice = new_active_Choice;
			active_choice.GetComponent<UIButtonScale>().enabled = false;
			active_choice.transform.localScale = new Vector3(2.5f,2.5f,1);
			active_choice.GetComponent<UIButtonColor>().defaultColor = Color.yellow;
			active_choice.GetComponentInChildren<UISprite>().color = Color.yellow;

		}
	}


	public void UpdateFeedBackLabel(int Track_Num, int Step_Num)
	{
		FeedBackLabel.GetComponent<UILabel>().text = "Track: "+Track_Num+" Trial: "+Step_Num;
		logFileStepNum = Step_Num;
	}

	public void UpdateFeedBackLabel_Adpt(int Step_Num)
	{
		FeedBackLabel.GetComponent<UILabel>().text = "Trial: "+Step_Num;
		logFileStepNum = Step_Num;

	}

	public void TestGoAwayAnim()
	{
		BackButton.SetActive(true);
		GameEngine.GetComponent<MenuManager>().updateBackButtonAnims (7);
		int num;

		for(int i = 0 ; i<Pro_Tracks_temp; i++ )
		{
			if(i == 0)
			{

				ResultsLabel.GetComponent<UILabel>().text = "Track 1: " + TrackCorrect[i] +"/" + Pro_Steps+"\n";
			}
			else
			{
				num = i+1;
				ResultsLabel.GetComponent<UILabel>().text += "Track "+num+": " + TrackCorrect[i] +"/" + Pro_Steps+"\n";
			}
		}



		TestWindow.GetComponent<Animation>().enabled = true;
		TestWindow.animation.Play("TestGoAwayAnim");

		//Play Anim Backwards
		ResultsScreen.animation["ResultsScreenMoveRightToMid"].speed = 1;
		ResultsScreen.animation["ResultsScreenMoveRightToMid"].time = 0;
		ResultsScreen.GetComponent<Animation>().enabled = true;
		ResultsScreen.animation.Play ("ResultsScreenMoveRightToMid");

		//Animate Back Button Back into Screen
		BackButtonOffset.GetComponent<Animation>().enabled = true;
		BackButtonOffset.animation.Play("BackButtonInViewAnim");
	}

	public void TestGoAwayAnim_Adpt()
	{
		BackButton.SetActive(true);
		GameEngine.GetComponent<MenuManager>().updateBackButtonAnims (7);
		int num;
		
	
		ResultsLabel.GetComponent<UILabel>().text = "Track: " + Correct_Count +"/" + adpt_trial+"\n";


		
		
		
		TestWindow.GetComponent<Animation>().enabled = true;
		TestWindow.animation.Play("TestGoAwayAnim");
		
		//Play Anim Backwards
		ResultsScreen.animation["ResultsScreenMoveRightToMid"].speed = 1;
		ResultsScreen.animation["ResultsScreenMoveRightToMid"].time = 0;
		ResultsScreen.GetComponent<Animation>().enabled = true;
		ResultsScreen.animation.Play ("ResultsScreenMoveRightToMid");
		
		//Animate Back Button Back into Screen
		BackButtonOffset.GetComponent<Animation>().enabled = true;
		BackButtonOffset.animation.Play("BackButtonInViewAnim");
	}
	// Use this for initialization
	void Start () {
		dBConversionArray = new float[101];
		GameEngine = GameObject.Find ("GameEngine");
		active_choice = null;
	}



	public void Update_data(string sessID,int sessType, int earOutput, string colocal_Right, string colocal_Left, int testType, 
	                        int genDB, int genTarget, int proTracks, int proSteps, int proStepSize, int adaptStep1, int adaptStep2, int adaptRev1, int adaptRev2)
	{
		ResultsScreen.GetComponent<Animation>().enabled = true;
		if(testType == 1)
		{
			FeedBackLabel.GetComponent<UILabel>().text = "Trial: 1";
		}
		else
		{
			FeedBackLabel.GetComponent<UILabel>().text = "Track: 1 Trial: 1";

		}
		//SessionID = sessID;
		SessionType = sessType; 
		EarOutput = earOutput;  
		

		int.TryParse(colocal_Right, out Colocal_RightOffset);
		int.TryParse(colocal_Left, out Colocal_LeftOffset);
		
		TestType = testType;
		Gen_DBOffset = genDB;
		Gen_TargetOffset = genTarget;
		
		Pro_Tracks = proTracks;
		Pro_Steps = proSteps;
		Pro_StepSize = proStepSize;
	
		Pro_Steps_temp = proSteps;
		Pro_Tracks_temp =proTracks;

		Adapt_StepSize_1 = adaptStep1;
		Adapt_StepSize_2 = adaptStep2;
		Adapt_Reversal_1 = adaptRev1;
		Adapt_Reversal_2 = adaptRev2;

		TrackCorrect = new int[proTracks] ;

		arrayIndex = 0;
		Correct_Count = 0;

	}




}
