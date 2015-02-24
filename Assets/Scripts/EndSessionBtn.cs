using UnityEngine;
using System.Collections;

public class EndSessionBtn : MonoBehaviour {
	public GameObject TheLabel;
	public GameObject initStartBtnAnchor;
	public GameObject initStartBtn;
	public GameObject titleLabel;
	private GameObject GameEngine;

	// Use this for initialization
	void Start () {
		GameEngine = GameObject.Find("GameEngine");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick()
	{

		//Vector3 new_pos = new Vector3(-200,100,0);
		//Disable the start button and also change the id too
		//initStartBtn.transform.position = new_pos;
		TheLabel.GetComponent<UILabel>().text = "Enter ID";
		gameObject.SetActive(false);
		titleLabel.GetComponent<UILabel>().text = "Email";
		GameEngine.GetComponent<EmailManager>().ShowEmailScreen(1);
		GameEngine.GetComponent<EmailManager>().updateNumOfFiles();

	}

	//public void afterStartBtnAnim()
	//{
	//	initStartBtnAnchor.SetActive(false);
	//}
}
