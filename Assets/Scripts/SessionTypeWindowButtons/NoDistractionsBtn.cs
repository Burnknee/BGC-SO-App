using UnityEngine;
using System.Collections;

public class NoDistractionsBtn : MonoBehaviour {

	private GameObject GameEngine;
	public GameObject StartSessionBtn;
	public GameObject titleLabel;

	// Use this for initialization
	void Start () {
	
		GameEngine = GameObject.Find ("GameEngine");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnClick()
	{
		titleLabel.GetComponent<UILabel>().text = "No Distractions";
		GameEngine.GetComponent<MenuManager>().updateBackButtonAnims (2);
		UIButtonPlayAnimation[] StartSessionAnims;
		StartSessionAnims = StartSessionBtn.GetComponents<UIButtonPlayAnimation>();
		StartSessionAnims[4].enabled = false;
		StartSessionAnims[0].enabled = true;
	}


}
