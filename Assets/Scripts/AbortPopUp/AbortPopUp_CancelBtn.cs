using UnityEngine;
using System.Collections;

public class AbortPopUp_CancelBtn : MonoBehaviour {

	public GameObject abortTestBtn;

	// Use this for initialization
	void Start () {
	
	}

	void OnClick()
	{
		int numBtns = abortTestBtn.GetComponent<AbortTestBtn>().Btns.Length;
		
		for(int i = 0; i < numBtns ; i++)
		{
			abortTestBtn.GetComponent<AbortTestBtn>().Btns[i].GetComponent<BoxCollider>().enabled = true;
		}
	}

	// Update is called once per frame
	void Update () {
	

	}
}
/*
 * 
 * 
 * 
 * 
 * 
 * 
 * Notes:
 * 
 * 
 * 
 * 
 * 
 * Problems:
 * Does not end their sessions...
 * ----Do not try to many times...
 * ----Three tries solutions.
 * ----Progress bar...
 * ----5 times (Zordan)
 * Does not get all three in one stage...
 * 
 * Senior Version:
 * Tone down navigation.
 * Tone down speed and obstacles (too many obstacles too soon).
 * No fuel in levels?(make it optional)
 * Less panels
 * Smaller increments in fly by.
 * 
 * What is hold out? In the game and tone it down for seniors...
 * 100%hold out meaning?
 * 6 succesful passes to get to 100% hold out...
 * 
 * Irvine??
 * 
 * hold out relationship with offset.
 * 
 * look at ipads for summary and details...
 * 
 * 
 * 10 on recall 
 * 10 on tapback
 * 
 * what is tapback...
 * 
 * grab summary files...and excell them! Columns... Comma seperated...
 * 
 * What does hold out start? Should be seeing holdout already? after 5 days... should be maximized... 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * Next meeting to create graphs...
 * 
 * My Job:  
 * 
 * Seniors reduce sides!
 * AT most 5 sides on 8 sided tunnel.
 * collection of fuel not mandatory
 * Control for the spinner...locking to a side?? Snap onto the sides ...
 * Motivate movement....
 * speed incement decreases on a match.. Reduce speed and incrementes...
 * Less/No obstacles
 * Navigation class: number of sides and obstacles
 * new scale from one to a number.
 * 7 navigation levels. stay in the zero realm for a while.
 * Is hold out necessary for seniors?
 * 100% hold out?
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 */