using UnityEngine;
using System.Collections;

public class CalibrationDBUpArrow : MonoBehaviour {

	public GameObject CalibrationDBLabelObject;
	
	void OnClick()
	{
		//Update the textLabel
		string InputString = CalibrationDBLabelObject.GetComponent<UILabel>().text;
		int num;
		bool possible =int.TryParse(InputString, out num);

		if(num < 100)
		{
			num++;
		}
		CalibrationDBLabelObject.GetComponent<UILabel>().text = num.ToString();
	}
}
