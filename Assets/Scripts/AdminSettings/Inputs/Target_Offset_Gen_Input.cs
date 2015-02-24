using UnityEngine;
using System.Collections;

public class Target_Offset_Gen_Input : MonoBehaviour {

	public GameObject GeneralOpWindow;
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
				num = 0;
				TheLabel.GetComponent<UILabel>().text = num.ToString();
			}
		}
	}
	void OnSubmit(string InputString)
	{

	}
}
