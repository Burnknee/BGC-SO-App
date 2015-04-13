using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class SubmitBtn : MonoBehaviour {

	public string color;
	public string number; 
	public GameObject titleLabel;
	private GameObject GameEngine;

	public GameObject NextSoundBtn;

	public GameObject Correct_Wrong_obj;

	public GameObject Rev_1;
	public GameObject Rev_2;
	public string LogFileColumn = "";
	public int adpt2_counter = 1;
	public int adpt_left_sum = 0;
	public int adpt_right_sum = 0;
	public float adpt_thresh_left = 0;
	public float adpt_thresh_right = 0;
	// Use this for initialization
	void Start () {
		GameEngine = GameObject.Find ("GameEngine");
	}
	
	
	void OnClick()
	{

		if(!GameEngine.GetComponent<TestManager>().WaitingOnStart)
		{

			if(GameEngine.GetComponent<TestManager>().logFileStepNum == 0)
			{
				GameEngine.GetComponent<TestManager>().logFileStepNum = 1;
			}
			//Update the LogFileColumn
			//Columns:
			// TESTNUM     SESSIONTYPE     TESTTYPE     TRIALNUM     TARGETLEFTDB     TARGETRIGHTDB     ANSCOLOR     ANSNUMBER     RESPCOLOR     RESPNUM     CORRECT
			LogFileColumn += GameEngine.GetComponent<TestManager>().testNum + " "+GameEngine.GetComponent<TestManager>().SessionType + " "+ 
				GameEngine.GetComponent<TestManager>().TestType + " " + GameEngine.GetComponent<TestManager>().logFileStepNum+ " "+ 
					GameEngine.GetComponent<TestManager>().logFileTalkerLeftDB + " " + GameEngine.GetComponent<TestManager>().logFileTalkerRightDB + " " + 
					GameEngine.GetComponent<TestManager>().currentColor + " " + GameEngine.GetComponent<TestManager>().currentNumber + " " +
					color + " " + number + " ";
			if((GameEngine.GetComponent<TestManager>().currentColor == color) && (GameEngine.GetComponent<TestManager>().currentNumber == number))
			{
				LogFileColumn +=  "1" + "\n";
			}
			else
			{
				LogFileColumn +=  "0" + "\n";

			}

			//Debug.Log(LogFileColumn);



			//Adaptive
			if(GameEngine.GetComponent<TestManager>().TestType == 1)
			{
				
				//First reversal has to go from right to wrong
				//previous has to be 1 and new has to be 0
				// Once this is true, then we can change increment the first reversal count
				//other wise just keep increasing the volume!
				
				
				//Correct/Wrong
				if((color == GameEngine.GetComponent<TestManager>().currentColor)
				   && (number == GameEngine.GetComponent<TestManager>().currentNumber))
				{
					Correct_Wrong_obj.GetComponentInChildren<UILabel>().text = "Correct";
					Correct_Wrong_obj.GetComponentInChildren<UILabel>().color = Color.green;

					//Debug.Log ("Correct!");
					GameEngine.GetComponent<TestManager>().Correct_Count ++;
					
					//Update reversal
					GameEngine.GetComponent<TestManager>().prev_ans = GameEngine.GetComponent<TestManager>().new_ans;
					GameEngine.GetComponent<TestManager>().new_ans = 1;
					
					if(!GameEngine.GetComponent<TestManager>().is_first_adpt)
					{
						//Update reversals
						if(GameEngine.GetComponent<TestManager>().prev_ans != GameEngine.GetComponent<TestManager>().new_ans)
						{
							if(GameEngine.GetComponent<TestManager>().Adapt_Reversal_1 == 0)
							{
								GameEngine.GetComponent<TestManager>().Adapt_Reversal_2--;
							}
							else
							{
								GameEngine.GetComponent<TestManager>().Adapt_Reversal_1--;
							}
						}
					}
					
					
					//Decrease sound by step size
					if(GameEngine.GetComponent<TestManager>().Adapt_Reversal_1 != 0)
					{
						//Reduce by stepsize_1
						GameEngine.GetComponent<TestManager>().talker_DB -= GameEngine.GetComponent<TestManager>().Adapt_StepSize_1;
						if(GameEngine.GetComponent<TestManager>().talker_DB < 0)
						{
							GameEngine.GetComponent<TestManager>().talker_DB = 0;
						}
						
					}
					else
					{
						//For Average Management
						adpt2_counter++;
						if(GameEngine.GetComponent<TestManager>().SessionType == 0)
						{
							adpt_left_sum  += (GameEngine.GetComponent<TestManager>().talker_DB);
							adpt_right_sum  += (GameEngine.GetComponent<TestManager>().talker_DB);
						}
						else
						{
							//Debug.Log ("Adding to Sum: " +(GameEngine.GetComponent<TestManager>().talker_DB + GameEngine.GetComponent<TestManager>().Colocal_LeftOffset));
							//Debug.Log ("In Log File: " +GameEngine.GetComponent<TestManager>().logFileTalkerLeftDB);
							adpt_left_sum  += (GameEngine.GetComponent<TestManager>().talker_DB + GameEngine.GetComponent<TestManager>().Colocal_LeftOffset);
							adpt_right_sum  += (GameEngine.GetComponent<TestManager>().talker_DB + GameEngine.GetComponent<TestManager>().Colocal_RightOffset);
							
							
						}

						//Decrease by stepsize_2
						GameEngine.GetComponent<TestManager>().talker_DB -= GameEngine.GetComponent<TestManager>().Adapt_StepSize_2;
						if(GameEngine.GetComponent<TestManager>().talker_DB < 0)
						{
							GameEngine.GetComponent<TestManager>().talker_DB = 0;
						}

					}
					
				}
				else
				{
					//Debug.Log ("Wrong!");
					Correct_Wrong_obj.GetComponentInChildren<UILabel>().text = "Wrong";
					Correct_Wrong_obj.GetComponentInChildren<UILabel>().color = Color.red;
					//Update reversal
					GameEngine.GetComponent<TestManager>().prev_ans = GameEngine.GetComponent<TestManager>().new_ans;
					GameEngine.GetComponent<TestManager>().new_ans = 0;
					
					if(GameEngine.GetComponent<TestManager>().is_first_adpt)
					{
						//From right to wrong!
						if((GameEngine.GetComponent<TestManager>().prev_ans == 1))
						{
							GameEngine.GetComponent<TestManager>().is_first_adpt = false;
							//Now I can call the first reversal
						}
					}
					
					if(!GameEngine.GetComponent<TestManager>().is_first_adpt)
					{
						//Update reversals
						if(GameEngine.GetComponent<TestManager>().prev_ans != GameEngine.GetComponent<TestManager>().new_ans)
						{
							if(GameEngine.GetComponent<TestManager>().Adapt_Reversal_1 == 0)
							{
								GameEngine.GetComponent<TestManager>().Adapt_Reversal_2--;
							}
							else
							{
								GameEngine.GetComponent<TestManager>().Adapt_Reversal_1--;
							}
						}
					}
					
					
					//Increase sound by stepsize
					if(GameEngine.GetComponent<TestManager>().Adapt_Reversal_1 != 0)
					{
						//Increase by stepsize_1
						GameEngine.GetComponent<TestManager>().talker_DB += GameEngine.GetComponent<TestManager>().Adapt_StepSize_1;
						if(GameEngine.GetComponent<TestManager>().talker_DB > 100)
						{
							GameEngine.GetComponent<TestManager>().talker_DB = 100;
						}
						
					}
					else
					{

						//For Average Management
						adpt2_counter++;
						if(GameEngine.GetComponent<TestManager>().SessionType == 0)
						{
							adpt_left_sum  += (GameEngine.GetComponent<TestManager>().talker_DB);
							adpt_right_sum  += (GameEngine.GetComponent<TestManager>().talker_DB);
						}
						else
						{
							//Debug.Log ("Adding to Sum: " +(GameEngine.GetComponent<TestManager>().talker_DB + GameEngine.GetComponent<TestManager>().Colocal_LeftOffset));
							//Debug.Log ("In Log File: " +GameEngine.GetComponent<TestManager>().logFileTalkerLeftDB);
							adpt_left_sum  += (GameEngine.GetComponent<TestManager>().talker_DB + GameEngine.GetComponent<TestManager>().Colocal_LeftOffset);
							adpt_right_sum  += (GameEngine.GetComponent<TestManager>().talker_DB + GameEngine.GetComponent<TestManager>().Colocal_RightOffset);
							
							
						}
						//Increase by stepsize_2
						GameEngine.GetComponent<TestManager>().talker_DB += GameEngine.GetComponent<TestManager>().Adapt_StepSize_2;
						if(GameEngine.GetComponent<TestManager>().talker_DB > 100)
						{
							GameEngine.GetComponent<TestManager>().talker_DB = 100;
						}
						
					}
					
				}
				
				
				
				if(GameEngine.GetComponent<TestManager>().Adapt_Reversal_2 == 0)
				{
					//Done!
					//Debug.Log ("Done!");
					GameEngine.GetComponent<TestManager>().isDone = true;
					titleLabel.GetComponent<UILabel>().text = "Results";

					//Animate to Go Away!!
					GameEngine.GetComponent<TestManager>().TestGoAwayAnim_Adpt();

					//Update Summary File String:
					string Summary_Line = "/************************************************************************/ \n";
					
					Summary_Line += "Test Number: " + GameEngine.GetComponent<TestManager>().testNum + "  ";
					if(GameEngine.GetComponent<TestManager>().SessionType == 0)
					{
						Summary_Line += "No Distractions ";
					}
					else if(GameEngine.GetComponent<TestManager>().SessionType == 1)
					{
						Summary_Line += "Co-localized ";
					}
					else if(GameEngine.GetComponent<TestManager>().SessionType == 2)
					{
						Summary_Line += "Spatial Offset ";
					}
					
					Summary_Line += "Adaptive\n";
					//Add Parameters
					Summary_Line += "Step Size A1: " + GameEngine.GetComponent<TestManager>().Adapt_StepSize_1 + "dB\n";
					Summary_Line += "Step Size A2: " + GameEngine.GetComponent<TestManager>().Adapt_StepSize_2 + "dB\n";
					Summary_Line += "Reversal R1: " + Rev_1.GetComponent<UILabel>().text + "\n";
					Summary_Line += "Reversal R2: " + Rev_2.GetComponent<UILabel>().text + "\n";
					Summary_Line += "Ear Output: ";


					//Debug.Log ("LEFT_SUM: " + adpt_left_sum + " Right_SUM: "+ adpt_right_sum + " adpt2C: " +adpt2_counter);
					adpt_thresh_left = (float)adpt_left_sum / (adpt2_counter-1);
					adpt_thresh_right = (float)adpt_right_sum / (adpt2_counter-1);



					if(GameEngine.GetComponent<TestManager>().SessionType == 0)
					{
						if(GameEngine.GetComponent<TestManager>().EarOutput == 0)
						{
							Summary_Line += "Left Only \n";
							adpt_thresh_right = 0;



						}
						else if(GameEngine.GetComponent<TestManager>().EarOutput == 1)
						{
							Summary_Line += "Right Only \n";
							adpt_thresh_left = 0;
						}
						else
						{
							Summary_Line += "Both \n";
						}
					}
					else
					{
						Summary_Line += "Both \n";
					}
					



					Summary_Line += "Adaptive Left Threshold: " + adpt_thresh_left.ToString() + "\nAdaptive Right Threshold: " + adpt_thresh_right.ToString();
					//ADD Threshold
					Summary_Line += "\n\n";

					adpt_left_sum = 0;
					adpt_right_sum = 0;


					//End String
					
					//Debug.Log (Summary_Line);

					//UnCommentThis for later
					/*StreamWriter fileWriter = null;
					fileWriter = File.AppendText(GameEngine.GetComponent<TestManager>().currentSummaryFilePath);
					fileWriter.WriteLine(Summary_Line);
					fileWriter.Close();

					fileWriter = File.AppendText(GameEngine.GetComponent<TestManager>().currentLogFilePath);
					fileWriter.WriteLine(LogFileColumn);
					fileWriter.Close();*/



					GameEngine.GetComponent<TestManager>().testNum++;


					
				}
				
				
				GameEngine.GetComponent<TestManager>().WaitingOnStart = true;
				
				
				GameEngine.GetComponent<TestManager>().UpdateFeedBackLabel_Adpt(++GameEngine.GetComponent<TestManager>().adpt_trial);
			}
			
			
			//Progressive!
			if(GameEngine.GetComponent<TestManager>().TestType == 0)
			{
				//Check if Correct/Wrong
				if((color == GameEngine.GetComponent<TestManager>().currentColor)
				   && (number == GameEngine.GetComponent<TestManager>().currentNumber))
				{
					
					//Debug.Log ("Correct!");
					Correct_Wrong_obj.GetComponentInChildren<UILabel>().text = "Correct";
					Correct_Wrong_obj.GetComponentInChildren<UILabel>().color = Color.green;
					GameEngine.GetComponent<TestManager>().Correct_Count ++;
					
				}
				else
				{
					//Debug.Log ("Wrong!");
					Correct_Wrong_obj.GetComponentInChildren<UILabel>().text = "Wrong";
					Correct_Wrong_obj.GetComponentInChildren<UILabel>().color = Color.red;
				}
				
				//Update Talker Volume for Progressive NoDistractions!
				GameEngine.GetComponent<TestManager>().talker_DB -= GameEngine.GetComponent<TestManager>().Pro_StepSize;
				if(GameEngine.GetComponent<TestManager>().talker_DB <= 0)
				{
					//Debug.Log ("Talker DB is less than or equal to zero!");
					GameEngine.GetComponent<TestManager>().talker_DB = 0;
				}
				
				//Progressive Steps
				
				//ADD!!!!!!!! The final Threshold !
				GameEngine.GetComponent<TestManager>().Pro_Steps_temp = GameEngine.GetComponent<TestManager>().Pro_Steps_temp - 1;
				if(GameEngine.GetComponent<TestManager>().Pro_Steps_temp == 0)
				{
					//Reset the TalkerDB
					GameEngine.GetComponent<TestManager>().talker_DB = GameEngine.GetComponent<TestManager>().Gen_DBOffset+GameEngine.GetComponent<TestManager>().Gen_TargetOffset;
					
					GameEngine.GetComponent<TestManager>().Pro_Steps_temp = GameEngine.GetComponent<TestManager>().Pro_Steps;
					//Debug.Log ("Finished a Track");
					
					//Save the number of correct in that given track in this array.
					GameEngine.GetComponent<TestManager>().TrackCorrect[GameEngine.GetComponent<TestManager>().arrayIndex] = GameEngine.GetComponent<TestManager>().Correct_Count;
					
					//Decrement track and increment array index
					GameEngine.GetComponent<TestManager>().Pro_Tracks = GameEngine.GetComponent<TestManager>().Pro_Tracks - 1;
					GameEngine.GetComponent<TestManager>().arrayIndex = GameEngine.GetComponent<TestManager>().arrayIndex + 1;

					//If done with tracks Then you are DONE!
					if(GameEngine.GetComponent<TestManager>().Pro_Tracks == 0)
					{
						//You are Done.
						//Debug.Log ("Done!");
						GameEngine.GetComponent<TestManager>().isDone = true;
						titleLabel.GetComponent<UILabel>().text = "Results";


						
						//Animate to Go Away!!
						GameEngine.GetComponent<TestManager>().TestGoAwayAnim();
	
						
					}
			

					//Update Summary File String:

					int pro_Threshold_right = (GameEngine.GetComponent<TestManager>().Gen_DBOffset + GameEngine.GetComponent<TestManager>().Gen_TargetOffset);
					int pro_Threshold_left = (GameEngine.GetComponent<TestManager>().Gen_DBOffset + GameEngine.GetComponent<TestManager>().Gen_TargetOffset);


					string Summary_Line = "/************************************************************************/ \n";

					Summary_Line += "Test Number: " + GameEngine.GetComponent<TestManager>().testNum + "  ";
					if(GameEngine.GetComponent<TestManager>().SessionType == 0)
					{
						Summary_Line += "No Distractions ";
					}
					else if(GameEngine.GetComponent<TestManager>().SessionType == 1)
					{
						Summary_Line += "Co-localized ";
						pro_Threshold_left += GameEngine.GetComponent<TestManager>().Colocal_LeftOffset;
						pro_Threshold_right += GameEngine.GetComponent<TestManager>().Colocal_RightOffset;

					}
					else if(GameEngine.GetComponent<TestManager>().SessionType == 2)
					{
						Summary_Line += "Spatial Offset ";
						pro_Threshold_left += GameEngine.GetComponent<TestManager>().Colocal_LeftOffset;
						pro_Threshold_right += GameEngine.GetComponent<TestManager>().Colocal_RightOffset;
					}

					Summary_Line += "Progressive\n";
					//Add Parameters
					Summary_Line += "Number of Steps: " + GameEngine.GetComponent<TestManager>().Pro_Steps + " dB\n";
					Summary_Line += "Step Size: " + GameEngine.GetComponent<TestManager>().Pro_StepSize + " dB\n";
					Summary_Line += "Ear Output: ";

					pro_Threshold_right -= (GameEngine.GetComponent<TestManager>().Correct_Count * GameEngine.GetComponent<TestManager>().Pro_StepSize);
					pro_Threshold_left -= (GameEngine.GetComponent<TestManager>().Correct_Count * GameEngine.GetComponent<TestManager>().Pro_StepSize);
					if(GameEngine.GetComponent<TestManager>().SessionType == 0)
					{
						if(GameEngine.GetComponent<TestManager>().EarOutput == 0)
						{
							Summary_Line += "Left Only \n";
							pro_Threshold_right = 0;
						}
						else if(GameEngine.GetComponent<TestManager>().EarOutput == 1)
						{
							Summary_Line += "Right Only \n";
							pro_Threshold_left = 0;
						}
						else
						{
							Summary_Line += "Both \n";
						}
					}
					else
					{
						Summary_Line += "Both \n";
					}



					Summary_Line += "Right Progressive Threshold: " + pro_Threshold_right.ToString() + " dB\nLeft Progressive Threshold: " + pro_Threshold_left+" dB";
					//ADD Threshold
					Summary_Line += "\n\n";


					//End String

					//Debug.Log (Summary_Line);

					//UnComment this Later
					/*StreamWriter fileWriter = null;
					fileWriter = File.AppendText(GameEngine.GetComponent<TestManager>().currentSummaryFilePath);
					fileWriter.WriteLine(Summary_Line);
					fileWriter.Close();

					fileWriter = File.AppendText(GameEngine.GetComponent<TestManager>().currentLogFilePath);
					fileWriter.WriteLine(LogFileColumn);
					fileWriter.Close();*/

					GameEngine.GetComponent<TestManager>().Correct_Count = 0;

					LogFileColumn = "";
					GameEngine.GetComponent<TestManager>().logFileStepNum = 0;

					GameEngine.GetComponent<TestManager>().testNum++;



				}
				
				GameEngine.GetComponent<TestManager>().UpdateFeedBackLabel(GameEngine.GetComponent<TestManager>().arrayIndex+1,
				                                                           GameEngine.GetComponent<TestManager>().Pro_Steps - GameEngine.GetComponent<TestManager>().Pro_Steps_temp+1);
				
				GameEngine.GetComponent<TestManager>().WaitingOnStart = true;
				
			}

			NextSoundBtn.transform.localPosition = new Vector3(0,350,0);
			gameObject.transform.localPosition = new Vector3(0,10000,0);

			//Change Color Back!
			GameObject temp = GameEngine.GetComponent<TestManager>().active_choice;
			temp.transform.localScale = new Vector3(2,2,1);
			//active_choice.GetComponent<UIButtonScale>().enabled = true;
			string old_color = temp.GetComponent<Choice>().color;
			//Debug.Log(old_color);
			if(old_color == "00")
			{
				temp.GetComponent<UIButtonColor>().defaultColor = Color.blue;
				temp.GetComponentInChildren<UISprite>().color = Color.blue;
			}
			else if(old_color == "01")
			{
				temp.GetComponent<UIButtonColor>().defaultColor = Color.red;
				temp.GetComponentInChildren<UISprite>().color = Color.red;
			}
			else if(old_color == "02")
			{
				temp.GetComponent<UIButtonColor>().defaultColor = Color.white;
				temp.GetComponentInChildren<UISprite>().color = Color.white;
			}
			else
			{
				temp.GetComponent<UIButtonColor>().defaultColor = Color.green;
				temp.GetComponentInChildren<UISprite>().color = Color.green;
			}
			temp.GetComponent<UIButtonScale>().enabled = true;

			//Play anim
			Correct_Wrong_obj.animation.Play();


		}
		
		
		
	}

}
