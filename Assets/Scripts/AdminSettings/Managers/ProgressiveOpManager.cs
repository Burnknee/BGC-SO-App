using UnityEngine;
using System.Collections;

public class ProgressiveOpManager : MonoBehaviour {

	public int numOfSteps;
	public int stepSize;
	public int numOfTracks;

	// Use this for initialization
	void Start () {
	
		numOfSteps = 10;
		stepSize = 1;
		numOfTracks =1;
	}

	public void UpdateNums(int num, int type)
	{
		if(type == 0)
		{
			numOfSteps = num;
		}
		else if(type ==1)
		{
			stepSize = num;
		}
		else if(type ==2)
		{
			numOfTracks = num;
		}
	}
}
