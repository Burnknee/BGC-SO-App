using UnityEngine;
using System.Collections;

public class SendEmailBtn : MonoBehaviour {

	private GameObject GameEngine;

	// Use this for initialization
	void Start () {
	
		GameEngine = GameObject.Find ("GameEngine");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick()
	{

		GameEngine.GetComponent<EmailManager>().ShowEmailScreen(0);
		GameEngine.GetComponent<EmailManager>().updateNumOfFiles();
	}

}
