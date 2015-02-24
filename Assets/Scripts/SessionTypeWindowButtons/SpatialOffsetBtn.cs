using UnityEngine;
using System.Collections;

public class SpatialOffsetBtn : MonoBehaviour {

	private GameObject GameEngine;
	public GameObject StartSessionBtn;
	public GameObject titleLabel;

	// Use this for initialization
	void Start () {
		
		GameEngine = GameObject.Find ("GameEngine");
	}

	void OnClick()
	{
		titleLabel.GetComponent<UILabel>().text = "Spatial Offset";
		GameEngine.GetComponent<MenuManager>().updateBackButtonAnims (4);
		UIButtonPlayAnimation[] StartSessionAnims;
		StartSessionAnims = StartSessionBtn.GetComponents<UIButtonPlayAnimation>();
		StartSessionAnims[0].enabled = false;
		StartSessionAnims[4].enabled = true;
	}
}
