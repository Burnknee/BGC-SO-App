using UnityEngine;
using System.Collections;

public class BackBtn : MonoBehaviour {

	private GameObject GameEngine;
	public GameObject ResultsWindow;
	public GameObject BackButtonOffset;
	public GameObject titleLabel;
	
	// Use this for initialization
	void Start () {
		
		GameEngine = GameObject.Find ("GameEngine");
	}

	void OnClick()
	{
		if(GameEngine.GetComponent<MenuManager>().menu_lvl == 2 || GameEngine.GetComponent<MenuManager>().menu_lvl == 4 )
		{
			BackButtonOffset.GetComponent<Animation>().enabled = true;
			BackButtonOffset.animation.Play("BackButtonOutRightAnim");
			GameEngine.GetComponent<MenuManager>().menu_lvl = 1;
			titleLabel.GetComponent<UILabel>().text = "Session Types";

		}
		else if(GameEngine.GetComponent<MenuManager>().menu_lvl == 3)
		{
			BackButtonOffset.GetComponent<Animation>().enabled = true;
			BackButtonOffset.animation.Play("BackButtonOutRightAnim");
			GameEngine.GetComponent<MenuManager>().menu_lvl = 1;
			titleLabel.GetComponent<UILabel>().text = "Session Types";

		}
		else if(GameEngine.GetComponent<MenuManager>().menu_lvl == 5)
		{
			BackButtonOffset.GetComponent<Animation>().enabled = true;
			BackButtonOffset.animation.Play("BackButtonOutRightAnim");
			GameEngine.GetComponent<MenuManager>().menu_lvl = 1;
			titleLabel.GetComponent<UILabel>().text = "Session Types";

		}
		else if(GameEngine.GetComponent<MenuManager>().menu_lvl == 7)
		{
			//Play Anim Backwards
			ResultsWindow.animation["ResultsScreenMoveRightToMid"].speed = -1;
			ResultsWindow.animation["ResultsScreenMoveRightToMid"].time = ResultsWindow.animation["ResultsScreenMoveRightToMid"].length;
			ResultsWindow.animation.Play("ResultsScreenMoveRightToMid");

			BackButtonOffset.GetComponent<Animation>().enabled = true;
			BackButtonOffset.animation.Play("BackButtonOutRightAnim");
			GameEngine.GetComponent<MenuManager>().menu_lvl = 1;
			titleLabel.GetComponent<UILabel>().text = "Session Types";

		}



	}
}
