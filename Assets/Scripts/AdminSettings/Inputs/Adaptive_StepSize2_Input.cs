using UnityEngine;
using System.Collections;

public class Adaptive_StepSize2_Input : MonoBehaviour {

	public GameObject AdaptiveOpWindow;
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
			bool possible =int.TryParse(InputString, out num);
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
			AdaptiveOpWindow.GetComponent<AdaptiveOpManager>().UpdateNums(num,1);
		}
	}
	void OnSubmit(string InputString)
	{

	}

}
