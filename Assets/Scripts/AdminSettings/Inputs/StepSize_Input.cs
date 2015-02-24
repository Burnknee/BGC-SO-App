using UnityEngine;
using System.Collections;

public class StepSize_Input : MonoBehaviour {

	public GameObject ProgressiveOpWindow;
	public GameObject TheLabel;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnSelect(bool isSelected)
	{
		if(!isSelected)
		{
			string InputString = TheLabel.GetComponent<UILabel>().text;
			int num;
			bool possible = int.TryParse(InputString, out num);
			if(!possible)
			{
				num = 1;
				TheLabel.GetComponent<UILabel>().text = num.ToString();
			}
			if(num == 0)
			{
				num = 1;
				TheLabel.GetComponent<UILabel>().text = num.ToString();
			}
			ProgressiveOpWindow.GetComponent<ProgressiveOpManager>().UpdateNums(num,1);
		}
	}
	void OnSubmit(string InputString)
	{

	}
}
