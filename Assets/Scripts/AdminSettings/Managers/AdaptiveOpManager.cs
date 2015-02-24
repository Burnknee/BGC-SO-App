using UnityEngine;
using System.Collections;

public class AdaptiveOpManager : MonoBehaviour {


	public int StepSize_1 ;
	public int StepSize_2 ;
	public int Reversal_1;
	public int Reversal_2;
	// Use this for initialization
	void Start () {
	
		StepSize_1 = 5;
		StepSize_2 = 10;
		Reversal_1 = 2;
		Reversal_2 = 3;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void UpdateNums(int num, int type)
	{
		if(type == 0)
		{
			StepSize_1 = num;
		}
		else if(type ==1)
		{
			StepSize_2 = num;
		}
		else if(type ==2)
		{
			Reversal_1 = num;
		}
		else if(type == 3)
		{
			Reversal_2 = num;
		}
	}
}
