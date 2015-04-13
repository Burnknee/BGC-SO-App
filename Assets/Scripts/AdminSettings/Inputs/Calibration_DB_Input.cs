using UnityEngine;
using System.Collections;

public class Calibration_DB_Input : MonoBehaviour {

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
			}
			if(num == 0)
			{
				num = 1;
				//TheLabel.GetComponent<UILabel>().text = num.ToString();
			}
			if(num > 100)
			{
				num = 100;
			}
			TheLabel.GetComponent<UILabel>().text = num.ToString();

		}
	}
}
