using UnityEngine;
using System.Collections;

public class ID_Submitted : MonoBehaviour {


	private GameObject GameEngine;
	public GameObject TheLabel;
	public GameObject initStartBtn;

	// Use this for initialization
	void Start () {
	
		GameEngine = GameObject.Find ("GameEngine");
		initStartBtn.SetActive(false);

	}

	
	void OnSelect(bool isSelected)
	{
		if(!isSelected)
		{
			// For now Spaces are not valid
			string inputString = TheLabel.GetComponent<UILabel>().text;
			bool noValidChars = false;
			int mStrLen = TheLabel.GetComponent<UILabel>().text.Length;
			for(int i = 0; i < mStrLen;i++)
			{
				if(inputString[i] == ' ')
				{
					noValidChars = true;
				}
			}

			if(inputString == "Enter ID" || inputString == "" )
			{
				initStartBtn.SetActive(false);

			}
			else if(noValidChars)
			{
				initStartBtn.SetActive(false);
				TheLabel.GetComponent<UILabel>().text = "Enter ID";

			}
			else
			{
				initStartBtn.SetActive(true);
			}

			// Label has to at least have one character in it!
		}
	
	}

}
