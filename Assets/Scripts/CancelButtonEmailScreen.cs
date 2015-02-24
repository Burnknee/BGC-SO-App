using UnityEngine;
using System.Collections;

public class CancelButtonEmailScreen : MonoBehaviour {

	public GameObject titleLabel;
	public GameObject GameEngine;
	public int whoCalled;
	public GameObject initStartBtnAnchor;
	// Use this for initialization
	void Start () {
	
		GameEngine = GameObject.Find("GameEngine");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick()
	{
		//GameEngine.GetComponent<EmailManager>().CancelBtnClicked();

		if(whoCalled == 0)
		{
			titleLabel.GetComponent<UILabel>().text = "Settings";
			GameEngine.GetComponent<EmailManager>().reset();
		}
		else if(whoCalled == 1)
		{
			titleLabel.GetComponent<UILabel>().text = "Session ID";
			GameEngine.GetComponent<EmailManager>().reset();
		}

	}

	public void afterStartBtnAnim()
	{
		//Debug.Log("Hmm");
		initStartBtnAnchor.SetActive(false);
	}
}
