using UnityEngine;
using System.Collections;

public class AdminSettingsManager : MonoBehaviour {

	public GameObject General_BG;
	public GameObject Email_BG;
	public GameObject Progressive_BG;
	public GameObject Adaptive_BG;
	public GameObject Calibration_BG;

	public GameObject Title_Label;

	public GameObject General_Window;
	public GameObject Email_Window;
	public GameObject Progressive_Window;
	public GameObject Adaptive_Window;
	public GameObject Calibration_Window;


	// Use this for initialization
	void Start () {
	
		General_BG.GetComponent<UISprite>().depth = 1;
		Email_BG.GetComponent<UISprite>().depth = 0;
		Progressive_BG.GetComponent<UISprite>().depth = 0;
		Adaptive_BG.GetComponent<UISprite>().depth = 0;
		Calibration_BG.GetComponent<UISprite>().depth = 0;

		Title_Label.GetComponent<UILabel>().text = "General Options";
		/*General_Window.SetActive(true);
		Email_Window.SetActive(false);
		Progressive_Window.SetActive(false);
		Adaptive_Window.SetActive(false);*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Group_Clicked( int grp_num)
	{

		/*Option: 
			0 => General
			1 => Email
			2 => Progressive
			3 => Adaptive

		 */

		if(grp_num == 0)
		{
			General_BG.GetComponent<UISprite>().depth = 1;
			Email_BG.GetComponent<UISprite>().depth = -1;
			Progressive_BG.GetComponent<UISprite>().depth = -1;
			Adaptive_BG.GetComponent<UISprite>().depth = -1;
			Calibration_BG.GetComponent<UISprite>().depth = -1;

			Title_Label.GetComponent<UILabel>().text = "General Options";
			General_Window.SetActive(true);
			Email_Window.SetActive(false);
			Progressive_Window.SetActive(false);
			Adaptive_Window.SetActive(false);
			Calibration_Window.SetActive(false);
		}
		else if(grp_num == 1)
		{
			General_BG.GetComponent<UISprite>().depth = -1;
			Email_BG.GetComponent<UISprite>().depth = 1;
			Progressive_BG.GetComponent<UISprite>().depth = -1;
			Adaptive_BG.GetComponent<UISprite>().depth = -1;
			Calibration_BG.GetComponent<UISprite>().depth = -1;


			Title_Label.GetComponent<UILabel>().text = "Email Options";
			General_Window.SetActive(false);
			Email_Window.SetActive(true);
			Progressive_Window.SetActive(false);
			Adaptive_Window.SetActive(false);
			Calibration_Window.SetActive(false);


		}
		else if(grp_num == 2)
		{
			General_BG.GetComponent<UISprite>().depth = -1;
			Email_BG.GetComponent<UISprite>().depth = -1;
			Progressive_BG.GetComponent<UISprite>().depth = 1;
			Adaptive_BG.GetComponent<UISprite>().depth = -1;
			Calibration_BG.GetComponent<UISprite>().depth = -1;


			Title_Label.GetComponent<UILabel>().text = "Progressive Options";
			General_Window.SetActive(false);
			Email_Window.SetActive(false);
			Progressive_Window.SetActive(true);
			Adaptive_Window.SetActive(false);
			Calibration_Window.SetActive(false);

		}
		else if (grp_num == 3)
		{
			General_BG.GetComponent<UISprite>().depth = -1;
			Email_BG.GetComponent<UISprite>().depth = -1;
			Progressive_BG.GetComponent<UISprite>().depth = -1;
			Adaptive_BG.GetComponent<UISprite>().depth = 1;
			Calibration_BG.GetComponent<UISprite>().depth = -1;


			Title_Label.GetComponent<UILabel>().text = "Adaptive Options";
			General_Window.SetActive(false);
			Email_Window.SetActive(false);
			Progressive_Window.SetActive(false);
			Adaptive_Window.SetActive(true);
			Calibration_Window.SetActive(false);

		}
		else if (grp_num == 4)
		{
			General_BG.GetComponent<UISprite>().depth = -1;
			Email_BG.GetComponent<UISprite>().depth = -1;
			Progressive_BG.GetComponent<UISprite>().depth = -1;
			Adaptive_BG.GetComponent<UISprite>().depth = -1;
			Calibration_BG.GetComponent<UISprite>().depth = 1;

			
			Title_Label.GetComponent<UILabel>().text = "Calibration";
			General_Window.SetActive(false);
			Email_Window.SetActive(false);
			Progressive_Window.SetActive(false);
			Adaptive_Window.SetActive(false);
			Calibration_Window.SetActive(true);

		}


	}
}
