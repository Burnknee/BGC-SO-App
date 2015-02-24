using UnityEngine;
using System.Collections;

public class ColocalizedBtn : MonoBehaviour {

	private GameObject GameEngine;
	public GameObject StartSessionBtn;
	public GameObject titleLabel;
	// Use this for initialization
	void Start () {
		
		GameEngine = GameObject.Find ("GameEngine");
	}

	void OnClick()
	{
		titleLabel.GetComponent<UILabel>().text = "Co-Localized";
		GameEngine.GetComponent<MenuManager>().updateBackButtonAnims (3);
		UIButtonPlayAnimation[] StartSessionAnims;
		StartSessionAnims = StartSessionBtn.GetComponents<UIButtonPlayAnimation>();
		StartSessionAnims[0].enabled = false;
		StartSessionAnims[4].enabled = true;
	}
}
