using UnityEngine;
using System.Collections;

public class ProgressiveCheckBox : MonoBehaviour {

	public GameObject GeneralOpWindow;


	void OnActivate( bool status)
	{
		GeneralOpWindow.GetComponent<GeneralOpManager>().UpdateTestType(status,0);
	}
}
