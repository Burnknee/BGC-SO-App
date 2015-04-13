using UnityEngine;
using System.Collections;

public class Calibration_Conversion_Input : MonoBehaviour {

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


			float num;
			bool possible = float.TryParse(InputString, out num);
			if(!possible)
			{
				num = 0.0f;
				TheLabel.GetComponent<UILabel>().text = num.ToString();

			}
			if(num > 1.0f)
			{
				num = 1.0f;
				TheLabel.GetComponent<UILabel>().text = num.ToString();

			}

		}
	}
}
