using UnityEngine;
using System.Collections;

public class StartBehavior : MonoBehaviour {
	

	private int talkerIndex;
	private string ClipPath;
	private AudioClip[] AudioClipTalkers;
	private GameObject GameEngine;

	private int[] talkers;
	private int[] talkersNames;
	private int[] talkersColors;
	private int[] talkersNumbers;

	//To choose a a random number that was not previously chosen
	public int sizeOfPossibleNumbers = 8;
	public bool[] possibleNumbers;

	//To choose a a random number that was not previously chosen
	public int sizeOfPossibleTalkers = 4;
	public bool[] possibleTalkers;

	private int temp_talker_num;
	private int talker_num;
	private int name_num;
	private int color_num;
	private int number_num;
	private int temp_number_num;

	public float talker1vol;

	//Colocalized/Spatial Offset items
	private AudioSource[] co_AudioClipsSources;
	private AudioClip co_Target_Clip;
	private AudioClip co_d1_Clip;
	private AudioClip co_d2_Clip;
	private int co_Target_number_num;
	private int co_dist1_number_num;
	private int co_dist2_number_num;

	//Submit btn
	public GameObject SubmitBtn;

	int tempDB; 
	// Use this for initialization
	void Start () {
	
		co_AudioClipsSources = new AudioSource[6]; // First two are target, then distractor 1 and then distractor 2
		for(int i = 0; i < 6; i++)
		{
			co_AudioClipsSources[i] = gameObject.AddComponent ("AudioSource") as AudioSource;

		}
		GameEngine = GameObject.Find ("GameEngine");
		AudioClipTalkers = new AudioClip[3]; //One Charlie, and two randoms
		talkerIndex = 0;
		talkers = new int[3]; //They have to be different talkers?
		talkersNames = new int[3]; //They have to be different names? (Only One Charlie) - This version the Randoms can be the same.
		talkersColors = new int[3]; //They have to be different Colors?
		talkersNumbers = new int[3]; //They have to be different Numbers?

		possibleNumbers = new bool[sizeOfPossibleNumbers];
		for(int i = 0; i < sizeOfPossibleNumbers; i++)
		{
			possibleNumbers[i] = true;
		}

		possibleTalkers = new bool[sizeOfPossibleTalkers];
		for(int i = 0; i < sizeOfPossibleTalkers; i++)
		{
			possibleTalkers[i] = true;
		}
	}

	void OnClick()
	{
		if(!GameEngine.GetComponent<TestManager>().isDone)
		{
			//If we are ready
			if(GameEngine.GetComponent<TestManager>().WaitingOnStart)
			{
				//Progressive Spatial
				if(GameEngine.GetComponent<TestManager>().SessionType == 2 )//&& GameEngine.GetComponent<TestManager>().TestType == 0
				{
					//Debug.Log("Spatial");

					//Choosing the AudioClips
					
					//Target
					temp_talker_num = Random.Range (0, sizeOfPossibleTalkers);
					name_num = 0;
					color_num = Random.Range (0,4);
					temp_number_num = Random.Range(0,sizeOfPossibleNumbers);
					//Choose number_num from possible list
					for(int i = 0; i < possibleNumbers.Length; i++)
					{
						if(temp_number_num == 0)
						{
							co_Target_number_num = i;
						}
						if(possibleNumbers[i] == true)
						{
							temp_number_num--;
						}
					}
					
					possibleNumbers[co_Target_number_num] = false;
					sizeOfPossibleNumbers --;
					//Done Update

					//Talkers update
					for(int i = 0; i < possibleTalkers.Length; i++)
					{
						if(temp_talker_num == 0)
						{
							talker_num = i;
						}
						if(possibleTalkers[i] == true)
						{
							temp_talker_num--;
						}
					}
					
					possibleTalkers[talker_num] = false;
					sizeOfPossibleTalkers --;
					//end talkers update
					
					co_Target_Clip = (AudioClip)Resources.Load ("CRMwavesprocessed/Talker"
					                                            +talker_num.ToString()
					                                            +"/colocated"
					                                            + "/co_0" + name_num.ToString ()
					                                            + "0" + color_num.ToString ()
					                                            + "0" + co_Target_number_num.ToString ());
					
					
					/*Debug.Log ("Target File = "+"CRMwavesprocessed/Talker"
					           +talker_num.ToString()
					           +"/colocated"
					           + "/co_0" + name_num.ToString ()
					           + "0" + color_num.ToString ()
					           + "0" + co_Target_number_num.ToString ());*/
					
					//Update current Color and Number
					GameEngine.GetComponent<TestManager>().targetTalker = talker_num;
					GameEngine.GetComponent<TestManager>().targetName = name_num;
					GameEngine.GetComponent<TestManager>().currentColor = "0"+color_num.ToString();
					GameEngine.GetComponent<TestManager>().currentNumber = "0"+co_Target_number_num.ToString();
					
					// End Target Clip
					
					//Distractor 1 (n45)
					temp_talker_num = Random.Range (0, sizeOfPossibleTalkers);
					name_num = Random.Range (1,8);
					color_num = Random.Range (0,4);
					temp_number_num = Random.Range(0,sizeOfPossibleNumbers);
					//Choose number_num from possible list
					for(int i = 0; i < possibleNumbers.Length; i++)
					{
						if(temp_number_num == 0)
						{
							co_dist1_number_num = i;
						}
						if(possibleNumbers[i] == true)
						{
							temp_number_num--;
						}
					}
					possibleNumbers[co_dist1_number_num] = false;
					sizeOfPossibleNumbers --;
					//Done Update

					//Talkers update
					for(int i = 0; i < possibleTalkers.Length; i++)
					{
						if(temp_talker_num == 0)
						{
							talker_num = i;
						}
						if(possibleTalkers[i] == true)
						{
							temp_talker_num--;
						}
					}
					
					possibleTalkers[talker_num] = false;
					sizeOfPossibleTalkers --;
					//end talkers update
					
					co_d1_Clip = (AudioClip)Resources.Load ("CRMwavesprocessed/Talker"
					                                        +talker_num.ToString()
					                                        +"/negative45"
					                                        + "/n45_0" + name_num.ToString ()
					                                        + "0" + color_num.ToString ()
					                                        + "0" + co_dist1_number_num.ToString ());
					
					
					/*Debug.Log ("Dist 1 N45 = "+"CRMwavesprocessed/Talker"
					           +talker_num.ToString()
					           +"/negative45"
					           + "/n45_0" + name_num.ToString ()
					           + "0" + color_num.ToString ()
					           + "0" + co_dist1_number_num.ToString ());*/
					GameEngine.GetComponent<TestManager>().distractorOneTalker = talker_num;
					GameEngine.GetComponent<TestManager>().distractorOneName = name_num;
					GameEngine.GetComponent<TestManager>().distractorOneColor = color_num;
					GameEngine.GetComponent<TestManager>().distractorOneNumber = co_dist1_number_num;
					
					// End Distractor 1 Clip
					
					//Distractor 2 (p45)
					temp_talker_num = Random.Range (0, sizeOfPossibleTalkers);
					name_num = Random.Range (1,8);
					color_num = Random.Range (0,4);
					temp_number_num = Random.Range(0,sizeOfPossibleNumbers);
					//Choose number_num from possible list
					for(int i = 0; i < possibleNumbers.Length; i++)
					{
						if(temp_number_num == 0)
						{
							co_dist2_number_num = i;
						}
						if(possibleNumbers[i] == true)
						{
							temp_number_num--;
						}
					}
					//Done Update

					//Talkers update
					for(int i = 0; i < possibleTalkers.Length; i++)
					{
						if(temp_talker_num == 0)
						{
							talker_num = i;
						}
						if(possibleTalkers[i] == true)
						{
							temp_talker_num--;
						}
					}
					
					possibleTalkers[talker_num] = false;
					sizeOfPossibleTalkers --;
					//end talkers update
					
					co_d2_Clip = (AudioClip)Resources.Load ("CRMwavesprocessed/Talker"
					                                        +talker_num.ToString()
					                                        +"/positive45"
					                                        + "/p45_0" + name_num.ToString ()
					                                        + "0" + color_num.ToString ()
					                                        + "0" + co_dist2_number_num.ToString ());
					
					
					/*Debug.Log ("Dist 2 P45 File = "+"CRMwavesprocessed/Talker"
					           +talker_num.ToString()
					           +"/positive45"
					           + "/p45_0" + name_num.ToString ()
					           + "0" + color_num.ToString ()
					           + "0" + co_dist2_number_num.ToString ());*/

					GameEngine.GetComponent<TestManager>().distractorTwoTalker = talker_num;
					GameEngine.GetComponent<TestManager>().distractorTwoName = name_num;
					GameEngine.GetComponent<TestManager>().distractorTwoColor = color_num;
					GameEngine.GetComponent<TestManager>().distractorTwoNumber = co_dist2_number_num;
					
					// End Distractor 2 Clip
					
					//Update possible numbers for next run!
					for(int i = 0; i < possibleNumbers.Length; i++)
					{
						possibleNumbers[i] = true;
					}
					possibleNumbers[co_Target_number_num] = false;
					possibleNumbers[co_dist1_number_num] = false;
					possibleNumbers[co_dist2_number_num] = false;
					sizeOfPossibleNumbers = 5;
					
					//End possible update

					//Update possible talkers for next run!
					for(int i = 0; i < possibleTalkers.Length; i++)
					{
						possibleTalkers[i] = true;
					}

					sizeOfPossibleTalkers = 4;
					
					//End possible update
					
					//Update Audio Sources, pan and volume level!
					
					
					
					//TargetSound
					co_AudioClipsSources[0].pan = -1;
					co_AudioClipsSources[1].pan = 1;
					
					//Distractor 1 Sound
					co_AudioClipsSources[2].pan = -1;
					co_AudioClipsSources[3].pan = 1;
					
					//Distractor 2 Sound
					co_AudioClipsSources[4].pan = -1;
					co_AudioClipsSources[5].pan = 1;

					//Update all DB_Conversion occasions to this block!!

					//Left Target
					//Check range of DB value
					/*****************************************************************************************************************/
					tempDB = GameEngine.GetComponent<TestManager>().talker_DB + GameEngine.GetComponent<TestManager>().Colocal_LeftOffset;

					if(tempDB < 0)
					{
						tempDB = 0;
					}
					if(tempDB > 100)
					{
						tempDB = 100;
					}
					GameEngine.GetComponent<TestManager>().logFileTalkerLeftDB = tempDB;
					float co_temp_vol = GameEngine.GetComponent<TestManager>().dBConversionArray[tempDB]*tempDB;
					co_AudioClipsSources[0].PlayOneShot(co_Target_Clip,co_temp_vol);

					/*****************************************************************************************************************/

					//Right Target
					//Check range of DB value
					/*****************************************************************************************************************/
					tempDB = GameEngine.GetComponent<TestManager>().talker_DB + GameEngine.GetComponent<TestManager>().Colocal_RightOffset;
					if(tempDB < 0)
					{
						tempDB = 0;
					}
					if(tempDB > 100)
					{
						tempDB = 100;
					}

					GameEngine.GetComponent<TestManager>().logFileTalkerRightDB = tempDB;
					co_temp_vol = GameEngine.GetComponent<TestManager>().dBConversionArray[tempDB]*tempDB;
					co_AudioClipsSources[1].PlayOneShot(co_Target_Clip,co_temp_vol);
					
					/*****************************************************************************************************************/

					//Left Distractor 1
					//Check range of DB value
					/*****************************************************************************************************************/
					tempDB = GameEngine.GetComponent<TestManager>().Gen_DBOffset + GameEngine.GetComponent<TestManager>().Colocal_LeftOffset;
					if(tempDB < 0)
					{
						tempDB = 0;
					}
					if(tempDB > 100)
					{
						tempDB = 100;
					}
					
					co_temp_vol = GameEngine.GetComponent<TestManager>().dBConversionArray[tempDB]*tempDB;
					co_AudioClipsSources[2].PlayOneShot(co_d1_Clip,co_temp_vol);
					
					/*****************************************************************************************************************/

					//Right Distractor 1
					//Check range of DB value
					/*****************************************************************************************************************/
					tempDB = GameEngine.GetComponent<TestManager>().Gen_DBOffset + GameEngine.GetComponent<TestManager>().Colocal_RightOffset;
					if(tempDB < 0)
					{
						tempDB = 0;
					}
					if(tempDB > 100)
					{
						tempDB = 100;
					}
					
					co_temp_vol = GameEngine.GetComponent<TestManager>().dBConversionArray[tempDB]*tempDB;
					co_AudioClipsSources[3].PlayOneShot(co_d1_Clip,co_temp_vol);

					/*****************************************************************************************************************/


					//Left Distractor 2
					//Check range of DB value
					/*****************************************************************************************************************/
					tempDB =GameEngine.GetComponent<TestManager>().Gen_DBOffset + GameEngine.GetComponent<TestManager>().Colocal_LeftOffset;
					if(tempDB < 0)
					{
						tempDB = 0;
					}
					if(tempDB > 100)
					{
						tempDB = 100;
					}
					
					co_temp_vol = GameEngine.GetComponent<TestManager>().dBConversionArray[tempDB]*tempDB;
					co_AudioClipsSources[4].PlayOneShot(co_d2_Clip,co_temp_vol);
					
					/*****************************************************************************************************************/

					//Right Distractor 2
					//Check range of DB value
					/*****************************************************************************************************************/
					tempDB =GameEngine.GetComponent<TestManager>().Gen_DBOffset + GameEngine.GetComponent<TestManager>().Colocal_RightOffset;
					if(tempDB < 0)
					{
						tempDB = 0;
					}
					if(tempDB > 100)
					{
						tempDB = 100;
					}
					
					co_temp_vol = GameEngine.GetComponent<TestManager>().dBConversionArray[tempDB]*tempDB;
					co_AudioClipsSources[5].PlayOneShot(co_d2_Clip,co_temp_vol);
					/*****************************************************************************************************************/

					GameEngine.GetComponent<TestManager>().WaitingOnStart = false;
				}

				//Progressive Colocalized
				if(GameEngine.GetComponent<TestManager>().SessionType == 1 ) //&& GameEngine.GetComponent<TestManager>().TestType == 0
				{
					//Debug.Log("Colocalized");

					//Choosing the AudioClips

					//Target
					temp_talker_num = Random.Range (0, sizeOfPossibleTalkers);
					name_num = 0;
					color_num = Random.Range (0,4);
					temp_number_num = Random.Range(0,sizeOfPossibleNumbers);
					//Choose number_num from possible list
					for(int i = 0; i < possibleNumbers.Length; i++)
					{
						if(temp_number_num == 0)
						{
							co_Target_number_num = i;
						}
						if(possibleNumbers[i] == true)
						{
							temp_number_num--;
						}
					}

					possibleNumbers[co_Target_number_num] = false;
					sizeOfPossibleNumbers --;
					//Done Update

					//Talkers update
					for(int i = 0; i < possibleTalkers.Length; i++)
					{
						if(temp_talker_num == 0)
						{
							talker_num = i;
						}
						if(possibleTalkers[i] == true)
						{
							temp_talker_num--;
						}
					}
					
					possibleTalkers[talker_num] = false;
					sizeOfPossibleTalkers --;
					//end talkers update

					co_Target_Clip = (AudioClip)Resources.Load ("CRMwavesprocessed/Talker"
					                                            +talker_num.ToString()
					                                            +"/colocated"
					                                            + "/co_0" + name_num.ToString ()
					                                            + "0" + color_num.ToString ()
					                                            + "0" + co_Target_number_num.ToString ());

							
					/*Debug.Log ("Target File = "+"CRMwavesprocessed/Talker"
					           +talker_num.ToString()
					           +"/colocated"
					           + "/co_0" + name_num.ToString ()
					           + "0" + color_num.ToString ()
					           + "0" + co_Target_number_num.ToString ());*/

					//Update current Color and Number
					GameEngine.GetComponent<TestManager>().targetTalker = talker_num;
					GameEngine.GetComponent<TestManager>().targetName = name_num;
					GameEngine.GetComponent<TestManager>().currentColor = "0"+color_num.ToString();
					GameEngine.GetComponent<TestManager>().currentNumber = "0"+co_Target_number_num.ToString();

					// End Target Clip

					//Distractor 1
					temp_talker_num = Random.Range (0, sizeOfPossibleTalkers);
					name_num = Random.Range (1,8);
					color_num = Random.Range (0,4);
					temp_number_num = Random.Range(0,sizeOfPossibleNumbers);
					//Choose number_num from possible list
					for(int i = 0; i < possibleNumbers.Length; i++)
					{
						if(temp_number_num == 0)
						{
							co_dist1_number_num = i;
						}
						if(possibleNumbers[i] == true)
						{
							temp_number_num--;
						}
					}
					possibleNumbers[co_dist1_number_num] = false;
					sizeOfPossibleNumbers --;
					//Done Update

					//Talkers update
					for(int i = 0; i < possibleTalkers.Length; i++)
					{
						if(temp_talker_num == 0)
						{
							talker_num = i;
						}
						if(possibleTalkers[i] == true)
						{
							temp_talker_num--;
						}
					}
					
					possibleTalkers[talker_num] = false;
					sizeOfPossibleTalkers --;
					//end talkers update
					
					co_d1_Clip = (AudioClip)Resources.Load ("CRMwavesprocessed/Talker"
					                                            +talker_num.ToString()
					                                            +"/colocated"
					                                            + "/co_0" + name_num.ToString ()
					                                            + "0" + color_num.ToString ()
					                                            + "0" + co_dist1_number_num.ToString ());
					
					
					/*Debug.Log ("Dist 1 File = "+"CRMwavesprocessed/Talker"
					           +talker_num.ToString()
					           +"/colocated"
					           + "/co_0" + name_num.ToString ()
					           + "0" + color_num.ToString ()
					           + "0" + co_dist1_number_num.ToString ());*/

					GameEngine.GetComponent<TestManager>().distractorOneTalker = talker_num;
					GameEngine.GetComponent<TestManager>().distractorOneName = name_num;
					GameEngine.GetComponent<TestManager>().distractorOneColor = color_num;
					GameEngine.GetComponent<TestManager>().distractorOneNumber = co_dist1_number_num;
					// End Distractor 1 Clip

					//Distractor 2
					temp_talker_num = Random.Range (0, sizeOfPossibleTalkers);
					name_num = Random.Range (1,8);
					color_num = Random.Range (0,4);
					temp_number_num = Random.Range(0,sizeOfPossibleNumbers);
					//Choose number_num from possible list
					for(int i = 0; i < possibleNumbers.Length; i++)
					{
						if(temp_number_num == 0)
						{
							co_dist2_number_num = i;
						}
						if(possibleNumbers[i] == true)
						{
							temp_number_num--;
						}
					}
					//Done Update

					//Talkers update
					for(int i = 0; i < possibleTalkers.Length; i++)
					{
						if(temp_talker_num == 0)
						{
							talker_num = i;
						}
						if(possibleTalkers[i] == true)
						{
							temp_talker_num--;
						}
					}
					
					possibleTalkers[talker_num] = false;
					sizeOfPossibleTalkers --;
					//end talkers update
					
					co_d2_Clip = (AudioClip)Resources.Load ("CRMwavesprocessed/Talker"
					                                        +talker_num.ToString()
					                                        +"/colocated"
					                                        + "/co_0" + name_num.ToString ()
					                                        + "0" + color_num.ToString ()
					                                        + "0" + co_dist2_number_num.ToString ());
					
					
					/*Debug.Log ("Dist 2 File = "+"CRMwavesprocessed/Talker"
					           +talker_num.ToString()
					           +"/colocated"
					           + "/co_0" + name_num.ToString ()
					           + "0" + color_num.ToString ()
					           + "0" + co_dist2_number_num.ToString ());*/

					GameEngine.GetComponent<TestManager>().distractorTwoTalker = talker_num;
					GameEngine.GetComponent<TestManager>().distractorTwoName = name_num;
					GameEngine.GetComponent<TestManager>().distractorTwoColor = color_num;
					GameEngine.GetComponent<TestManager>().distractorTwoNumber = co_dist2_number_num;
					
					// End Distractor 2 Clip

					//Update possible numbers for next run!
					for(int i = 0; i < possibleNumbers.Length; i++)
					{
						possibleNumbers[i] = true;
					}
					possibleNumbers[co_Target_number_num] = false;
					possibleNumbers[co_dist1_number_num] = false;
					possibleNumbers[co_dist2_number_num] = false;
					sizeOfPossibleNumbers = 5;

					//End possible update

					//Update possible talkers for next run!
					for(int i = 0; i < possibleTalkers.Length; i++)
					{
						possibleTalkers[i] = true;
					}
					sizeOfPossibleTalkers = 4;
					
					//End possible update

					//Update Audio Sources, pan and volume level!



					//TargetSound
					co_AudioClipsSources[0].pan = -1;
					co_AudioClipsSources[1].pan = 1;

					//Distractor 1 Sound
					co_AudioClipsSources[2].pan = -1;
					co_AudioClipsSources[3].pan = 1;

					//Distractor 2 Sound
					co_AudioClipsSources[4].pan = -1;
					co_AudioClipsSources[5].pan = 1;
										
					//Left Target
					//Check range of DB value
					/*****************************************************************************************************************/
					tempDB = GameEngine.GetComponent<TestManager>().talker_DB + GameEngine.GetComponent<TestManager>().Colocal_LeftOffset;
					if(tempDB < 0)
					{
						tempDB = 0;
					}
					if(tempDB > 100)
					{
						tempDB = 100;
					}
					GameEngine.GetComponent<TestManager>().logFileTalkerLeftDB = tempDB;
					float co_temp_vol = GameEngine.GetComponent<TestManager>().dBConversionArray[tempDB]*tempDB;
					co_AudioClipsSources[0].PlayOneShot(co_Target_Clip,co_temp_vol);
					
					/*****************************************************************************************************************/
					
					//Right Target
					//Check range of DB value
					/*****************************************************************************************************************/
					tempDB = GameEngine.GetComponent<TestManager>().talker_DB + GameEngine.GetComponent<TestManager>().Colocal_RightOffset;
					if(tempDB < 0)
					{
						tempDB = 0;
					}
					if(tempDB > 100)
					{
						tempDB = 100;
					}
					GameEngine.GetComponent<TestManager>().logFileTalkerRightDB = tempDB;
					co_temp_vol = GameEngine.GetComponent<TestManager>().dBConversionArray[tempDB]*tempDB;
					co_AudioClipsSources[1].PlayOneShot(co_Target_Clip,co_temp_vol);
					
					/*****************************************************************************************************************/
					
					//Left Distractor 1
					//Check range of DB value
					/*****************************************************************************************************************/
					tempDB = GameEngine.GetComponent<TestManager>().Gen_DBOffset + GameEngine.GetComponent<TestManager>().Colocal_LeftOffset;
					if(tempDB < 0)
					{
						tempDB = 0;
					}
					if(tempDB > 100)
					{
						tempDB = 100;
					}
					
					co_temp_vol = GameEngine.GetComponent<TestManager>().dBConversionArray[tempDB]*tempDB;
					co_AudioClipsSources[2].PlayOneShot(co_d1_Clip,co_temp_vol);
					
					/*****************************************************************************************************************/
					
					//Right Distractor 1
					//Check range of DB value
					/*****************************************************************************************************************/
					tempDB = GameEngine.GetComponent<TestManager>().Gen_DBOffset + GameEngine.GetComponent<TestManager>().Colocal_RightOffset;
					if(tempDB < 0)
					{
						tempDB = 0;
					}
					if(tempDB > 100)
					{
						tempDB = 100;
					}
					
					co_temp_vol = GameEngine.GetComponent<TestManager>().dBConversionArray[tempDB]*tempDB;
					co_AudioClipsSources[3].PlayOneShot(co_d1_Clip,co_temp_vol);
					
					/*****************************************************************************************************************/
					
					
					//Left Distractor 2
					//Check range of DB value
					/*****************************************************************************************************************/
					tempDB =GameEngine.GetComponent<TestManager>().Gen_DBOffset + GameEngine.GetComponent<TestManager>().Colocal_LeftOffset;
					if(tempDB < 0)
					{
						tempDB = 0;
					}
					if(tempDB > 100)
					{
						tempDB = 100;
					}
					
					co_temp_vol = GameEngine.GetComponent<TestManager>().dBConversionArray[tempDB]*tempDB;
					co_AudioClipsSources[4].PlayOneShot(co_d2_Clip,co_temp_vol);
					
					/*****************************************************************************************************************/
					
					//Right Distractor 2
					//Check range of DB value
					/*****************************************************************************************************************/
					tempDB =GameEngine.GetComponent<TestManager>().Gen_DBOffset + GameEngine.GetComponent<TestManager>().Colocal_RightOffset;
					if(tempDB < 0)
					{
						tempDB = 0;
					}
					if(tempDB > 100)
					{
						tempDB = 100;
					}
					
					co_temp_vol = GameEngine.GetComponent<TestManager>().dBConversionArray[tempDB]*tempDB;
					co_AudioClipsSources[5].PlayOneShot(co_d2_Clip,co_temp_vol);
					/*****************************************************************************************************************/

					/*// Left Target
					float co_temp_vol = GameEngine.GetComponent<TestManager>().DB_Conversion
						*(GameEngine.GetComponent<TestManager>().talker_DB + GameEngine.GetComponent<TestManager>().Colocal_LeftOffset);

					co_AudioClipsSources[0].PlayOneShot(co_Target_Clip,co_temp_vol);

					// Right Target
					co_temp_vol = GameEngine.GetComponent<TestManager>().DB_Conversion
						*(GameEngine.GetComponent<TestManager>().talker_DB + GameEngine.GetComponent<TestManager>().Colocal_RightOffset);
					co_AudioClipsSources[1].PlayOneShot(co_Target_Clip,co_temp_vol);

					//Left Distractor 1
					co_temp_vol = GameEngine.GetComponent<TestManager>().DB_Conversion
						*(GameEngine.GetComponent<TestManager>().Gen_DBOffset + GameEngine.GetComponent<TestManager>().Colocal_LeftOffset);
					co_AudioClipsSources[2].PlayOneShot(co_d1_Clip,co_temp_vol);

					//Right Distractor 1
					co_temp_vol = GameEngine.GetComponent<TestManager>().DB_Conversion
						*(GameEngine.GetComponent<TestManager>().Gen_DBOffset + GameEngine.GetComponent<TestManager>().Colocal_RightOffset);
					co_AudioClipsSources[3].PlayOneShot(co_d1_Clip,co_temp_vol);

					//Left Distractor 2
					co_temp_vol = GameEngine.GetComponent<TestManager>().DB_Conversion
						*(GameEngine.GetComponent<TestManager>().Gen_DBOffset + GameEngine.GetComponent<TestManager>().Colocal_LeftOffset);
					co_AudioClipsSources[4].PlayOneShot(co_d2_Clip,co_temp_vol);
					
					//Right Distractor 2
					co_temp_vol = GameEngine.GetComponent<TestManager>().DB_Conversion
						*(GameEngine.GetComponent<TestManager>().Gen_DBOffset + GameEngine.GetComponent<TestManager>().Colocal_RightOffset);
					co_AudioClipsSources[5].PlayOneShot(co_d2_Clip,co_temp_vol);
					*/

					GameEngine.GetComponent<TestManager>().WaitingOnStart = false;



				}
				/*
				//Adaptive Colocalized
				if(GameEngine.GetComponent<TestManager>().SessionType == 1 && GameEngine.GetComponent<TestManager>().TestType == 1)
				{
					Debug.Log("Colocalized Adaptive");
				}*/

				//Adaptive No Distractions
				if(GameEngine.GetComponent<TestManager>().SessionType == 0 && GameEngine.GetComponent<TestManager>().TestType == 1)
				{
					//Debug.Log("NoDistractions Adaptive");

					//Path.
					ClipPath = "CRMwaves/Talker";
					
					//Chooseing clip
					talker_num = Random.Range (0, 4);
					name_num = 0;
					color_num = Random.Range (0,4);
					temp_number_num = Random.Range(0,sizeOfPossibleNumbers);
					
					
					//Choose number_num from possible list
					for(int i = 0; i < possibleNumbers.Length; i++)
					{
						if(temp_number_num == 0)
						{
							number_num = i;
						}
						if(possibleNumbers[i] == true)
						{
							temp_number_num--;
						}
					}
					//Debug.Log ("Number Chosen: "+number_num);
					
					//Update number_num for next time:
					for(int i = 0; i < possibleNumbers.Length;i++)
					{
						possibleNumbers[i] = true;
					}
					possibleNumbers[number_num] = false;
					sizeOfPossibleNumbers = 7;
					//Done Update
					
					//Creating Path
					ClipPath += talker_num.ToString () 
						+ "/0" + name_num.ToString ()
							+ "0" + color_num.ToString ()
							+ "0" + number_num.ToString ();
					
					//Debug.Log ("Init Charlie Talker: "+ClipPath);
					AudioClipTalkers[0] = (AudioClip)Resources.Load (ClipPath);
					//Done with Path
					
					//Update current Color and Number
					GameEngine.GetComponent<TestManager>().targetTalker = talker_num;
					GameEngine.GetComponent<TestManager>().targetName = name_num;
					GameEngine.GetComponent<TestManager>().currentColor = "0"+color_num.ToString();
					GameEngine.GetComponent<TestManager>().currentNumber = "0"+number_num.ToString();

				
					tempDB = GameEngine.GetComponent<TestManager>().talker_DB;
					if(tempDB < 0)
					{
						tempDB = 0;
					}
					if(tempDB > 100)
					{
						tempDB = 100;
					}
					;
					talker1vol = GameEngine.GetComponent<TestManager>().dBConversionArray[tempDB]*tempDB;
					//talker1vol = GameEngine.GetComponent<TestManager>().DB_Conversion*GameEngine.GetComponent<TestManager>().talker_DB;
					//Debug.Log ("Volume!: "+talker1vol);
					
					//Choose Ear Channel
					if(GameEngine.GetComponent<TestManager>().EarOutput == 0)
					{
						audio.pan = -1;
						GameEngine.GetComponent<TestManager>().logFileTalkerRightDB = 0;
						GameEngine.GetComponent<TestManager>().logFileTalkerLeftDB = tempDB;
					}
					else if(GameEngine.GetComponent<TestManager>().EarOutput == 2)
					{
						audio.pan = 0;
						GameEngine.GetComponent<TestManager>().logFileTalkerRightDB = tempDB;
						GameEngine.GetComponent<TestManager>().logFileTalkerLeftDB = tempDB;
					}
					else
					{
						audio.pan = 1;
						GameEngine.GetComponent<TestManager>().logFileTalkerRightDB = tempDB;
						GameEngine.GetComponent<TestManager>().logFileTalkerLeftDB = 0;
					}
					audio.PlayOneShot(AudioClipTalkers[0],talker1vol);
					GameEngine.GetComponent<TestManager>().WaitingOnStart = false;

				}

				//Progressive No Distractions
				if(GameEngine.GetComponent<TestManager>().SessionType == 0 && GameEngine.GetComponent<TestManager>().TestType == 0)
				{
					//Debug.Log("NoDistractions Progressive");

					//Path.
					ClipPath = "CRMwaves/Talker";

					//Chooseing clip
					talker_num = Random.Range (0, 4);
					name_num = 0;
					color_num = Random.Range (0,4);
					temp_number_num = Random.Range(0,sizeOfPossibleNumbers);


					//Choose number_num from possible list
					for(int i = 0; i < possibleNumbers.Length; i++)
					{
						if(temp_number_num == 0)
						{
							number_num = i;
						}
						if(possibleNumbers[i] == true)
						{
							temp_number_num--;
						}
					}
					//Debug.Log ("Number Chosen: "+number_num);

					//Update number_num for next time:
					for(int i = 0; i < possibleNumbers.Length;i++)
					{
						possibleNumbers[i] = true;
					}
					possibleNumbers[number_num] = false;
					sizeOfPossibleNumbers = 7;
					//Done Update
		
					//Creating Path
					ClipPath += talker_num.ToString () 
						+ "/0" + name_num.ToString ()
							+ "0" + color_num.ToString ()
							+ "0" + number_num.ToString ();

					//Debug.Log ("Init Charlie Talker: "+ClipPath);
					AudioClipTalkers[0] = (AudioClip)Resources.Load (ClipPath);
					//Done with Path
					
					//Update current Color and Number
					GameEngine.GetComponent<TestManager>().targetTalker = talker_num;
					GameEngine.GetComponent<TestManager>().targetName = name_num;
					GameEngine.GetComponent<TestManager>().currentColor = "0"+color_num.ToString();
					GameEngine.GetComponent<TestManager>().currentNumber = "0"+number_num.ToString();

					//Playsound
					tempDB = GameEngine.GetComponent<TestManager>().talker_DB;
					if(tempDB < 0)
					{
						tempDB = 0;
					}
					if(tempDB > 100)
					{
						tempDB = 100;
					}
					talker1vol = GameEngine.GetComponent<TestManager>().dBConversionArray[tempDB]*tempDB;
					//talker1vol = GameEngine.GetComponent<TestManager>().DB_Conversion*GameEngine.GetComponent<TestManager>().talker_DB;
					//Debug.Log ("Volume!: "+talker1vol);

					//Choose Ear Channel
					if(GameEngine.GetComponent<TestManager>().EarOutput == 0)
					{
						audio.pan = -1;
						GameEngine.GetComponent<TestManager>().logFileTalkerRightDB = 0;
						GameEngine.GetComponent<TestManager>().logFileTalkerLeftDB = tempDB;
					}
					else if(GameEngine.GetComponent<TestManager>().EarOutput == 2)
					{
						audio.pan = 0;
						GameEngine.GetComponent<TestManager>().logFileTalkerRightDB = tempDB;
						GameEngine.GetComponent<TestManager>().logFileTalkerLeftDB = tempDB;
					}
					else
					{
						audio.pan = 1;
						GameEngine.GetComponent<TestManager>().logFileTalkerRightDB = tempDB;
						GameEngine.GetComponent<TestManager>().logFileTalkerLeftDB = 0;
					}
					audio.PlayOneShot(AudioClipTalkers[0],talker1vol);
					GameEngine.GetComponent<TestManager>().WaitingOnStart = false;

				} // End Progressive No Distractions
				gameObject.transform.localPosition = new Vector3(0,10000,0);




			}
		}
	}
}


