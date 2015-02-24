using UnityEngine;
using System.Collections;

public class AbortPopUp_AbortBtn : MonoBehaviour {

	public GameObject abortTestBtn;
	public GameObject titleLabel;

	public GameObject NextSoundBtn;
	public GameObject SubmitButton;

	public GameObject debugBtn;

	private GameObject GameEngine;

		
	// Use this for initialization
	void Start () {
		GameEngine = GameObject.Find ("GameEngine");
	}
	
	void OnClick()
	{

		//Reset Debug Button
		debugBtn.GetComponent<DebugBtn>().resetButton();

		GameEngine.GetComponent<TestManager>().WaitingOnStart = true;

		NextSoundBtn.transform.localPosition = new Vector3(0,350,0);
		SubmitButton.transform.localPosition = new Vector3(0,10000,0);

		//Change Color Back!
		GameObject temp = GameEngine.GetComponent<TestManager>().active_choice;

		if(temp != null)
		{
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
		}	

		
		
		titleLabel.GetComponent<UILabel>().text = "Session Types";

		int numBtns = abortTestBtn.GetComponent<AbortTestBtn>().Btns.Length;
		
		for(int i = 0; i < numBtns ; i++)
		{
			abortTestBtn.GetComponent<AbortTestBtn>().Btns[i].GetComponent<BoxCollider>().enabled = true;
		}
	}

}
