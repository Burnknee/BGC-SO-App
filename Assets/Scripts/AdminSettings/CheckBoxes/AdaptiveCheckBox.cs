using UnityEngine;
using System.Collections;

public class AdaptiveCheckBox : MonoBehaviour {

	public GameObject GeneralOpWindow;

	
	void OnActivate( bool status)
	{
		GeneralOpWindow.GetComponent<GeneralOpManager>().UpdateTestType(status,1); 
	}
}
