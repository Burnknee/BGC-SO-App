using UnityEngine;
using System.Collections;

public class CalibrationDBDownArrow : MonoBehaviour {

	public GameObject CalibrationDBLabelObject;
	
	void OnClick()
	{
		//Update the textLabel
		string InputString = CalibrationDBLabelObject.GetComponent<UILabel>().text;
		int num;
		bool possible =int.TryParse(InputString, out num);
		
		if(num > 0)
		{
			num--;
		}
		CalibrationDBLabelObject.GetComponent<UILabel>().text = num.ToString();
	}
}
