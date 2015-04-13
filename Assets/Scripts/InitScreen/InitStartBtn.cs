using UnityEngine;
using System.Collections;
using System.IO;
using System;


public class InitStartBtn : MonoBehaviour {

	private GameObject GameEngine;
	public GameObject titleLabel;
	public GameObject SessionNameLabel;
	public GameObject endSessionBtn;

	void Start () {
		GameEngine = GameObject.Find ("GameEngine");
	}

	void OnClick()
	{
		endSessionBtn.SetActive(true);
		//TimeStamp: day_month_year_hour:min:seconds
		string tStamp = DateTime.Now.Day+"_"+DateTime.Now.Month+"_"+DateTime.Now.Year+"_"+DateTime.Now.Hour+":"+DateTime.Now.Minute.ToString()+":"+DateTime.Now.Second.ToString();

		GameEngine.GetComponent<MenuManager>().menu_lvl = 1;
		titleLabel.GetComponent<UILabel>().text = "Session Types";

		//Create the folder and files for that session!

		//Update TestMangers Session ID member
		string tempID =SessionNameLabel.GetComponent<UILabel>().text;
		GameEngine.GetComponent<TestManager>().SessionID = tempID;

		//Create the folder for this sessionID if it does not exist!


		//UnComment this to create files.
		/*DirectoryInfo dirConvFiles = new DirectoryInfo(Application.persistentDataPath + "/Session_" +tempID);
		if(!dirConvFiles.Exists)
		{ 
			dirConvFiles.Create(); 
		}

		//Create the Log and Summary File for this session with time stamp.
		StreamWriter fileWriter = null;

		string sessionLogFile = Application.persistentDataPath + "/Session_"  + tempID + "/" + tempID + "__"+tStamp+"__" + "Log.txt";
		string sessionSummaryFile = Application.persistentDataPath + "/Session_"  + tempID + "/" + tempID + "__"+tStamp+"__" + "Summary.txt";

		GameEngine.GetComponent<TestManager>().currentLogFilePath = sessionLogFile;
		GameEngine.GetComponent<TestManager>().currentSummaryFilePath = sessionSummaryFile;

		//Create Files!
		//Columns:
		// TESTNUM     SESSIONTYPE     TESTTYPE     TRIALNUM     TARGETLEFTDB     TARGETRIGHTDB     ANSCOLOR     ANSNUMBER     RESPCOLOR     RESPNUM     CORRECT
		fileWriter = File.CreateText(sessionLogFile);
		fileWriter.WriteLine("TESTNUM  SESSIONTYPE  TESTTYPE  TRIALNUM  TARGETLEFTDB  TARGETRIGHTDB  ANSCOLOR  ANSNUMBER  RESPCOLOR  RESPNUM  CORRECT");
		fileWriter.Close();

		fileWriter = File.CreateText(sessionSummaryFile);
		//fileWriter.WriteLine("Hello, this is a Summary File!");
		fileWriter.Close();*/

		GameEngine.GetComponent<TestManager>().testNum = 1;



	}
	

}
