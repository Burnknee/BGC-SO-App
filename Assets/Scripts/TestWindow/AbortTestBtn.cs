using UnityEngine;
using System.Collections;

public class AbortTestBtn : MonoBehaviour {

	private GameObject GameEngine;
	public GameObject [] Btns;

	// Use this for initialization
	void Start () {
		GameEngine = GameObject.Find ("GameEngine");
	}

	void renableBtns()
	{
		//Disable Btns
		for(int i = 0; i < Btns.Length; i++)
		{
			Btns[i].GetComponent<BoxCollider>().enabled = true;
		}
	}
	// Update is called once per frame
	void OnClick () {

		//Disable Btns
		for(int i = 0; i < Btns.Length; i++)
		{
			Btns[i].GetComponent<BoxCollider>().enabled = false;
		}

	}
}
