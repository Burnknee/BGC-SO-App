using UnityEngine;
using System.Collections;


public class DB_Offset_Gen_Input : MonoBehaviour {

	public GameObject GeneralOpWindow;
	public GameObject TheLabel;

	void OnSelect(bool isSelected)
	{
		if(!isSelected)
		{
			string InputString = TheLabel.GetComponent<UILabel>().text;
			int num;
			bool possible = int.TryParse(InputString, out num);
			if(!possible)
			{
				num = 0;
				TheLabel.GetComponent<UILabel>().text = num.ToString();
			}
		}
	}

	void OnSubmit(string InputString)
	{

	}
}
