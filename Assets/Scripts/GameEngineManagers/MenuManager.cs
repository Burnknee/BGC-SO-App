using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public GameObject BackButton;
	
	/*
	 *    0 => InputMenu
	 * 	  1 => TypeSelection
	 *    2 => NoDistractions
	 *    3 => Colocalized
	 *    4 => Spatial Offset
	 *    5 => AdminSettings
	 *    6 => Test
	 *    7 => Results
	 */
	public int menu_lvl;
	private bool change = false;



	public void updateBackButtonAnims(int lvl)
	{
		//update the menu_lvl
		menu_lvl = lvl;
		change = true;


	}
	// Use this for initialization
	void Start () {

		menu_lvl = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (menu_lvl);
		if(change)
		{
			//This gets the list of ButtonAnims on Back Button!
			UIButtonPlayAnimation[] BackButtonAnims;
			BackButtonAnims = BackButton.GetComponents<UIButtonPlayAnimation>();

			for(int i = 0; i < BackButtonAnims.Length ; i++)
			{

				if ( menu_lvl == 2 )	//NoDistractions and SpatialOffset
				{
					if (i == 4 || i == 5 || i == 10)
					{
						BackButtonAnims[i].enabled = true;
					}
					else
					{
						BackButtonAnims[i].enabled = false;
					}
				}
				else if(menu_lvl == 3|| menu_lvl == 4)				//Colocalized
				{

					if( i == 5 || i== 6 || i ==10 )
					{
						BackButtonAnims[i].enabled = true;
					}
					else{
						BackButtonAnims[i].enabled = false;
					}

				}
				else if (menu_lvl == 5)				//Admin Settings
				{

					if (i == 5 || i== 7)
					{
						BackButtonAnims[i].enabled = true;
					}
					else
					{
						BackButtonAnims[i].enabled = false;
					}

				}
				else if (menu_lvl == 7)
				{
					if(i == 13 || i == 12 || i == 11)
					{
						BackButtonAnims[i].enabled = true;
					}
					else
					{
						BackButtonAnims[i].enabled = false;
					}
				}

			}
		}
		change = false;
	}
}
