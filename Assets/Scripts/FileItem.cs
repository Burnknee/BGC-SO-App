using UnityEngine;
using System.Collections;

public class FileItem : MonoBehaviour {

	public string nameOfFile;
	private GameObject GameEngine;
	public GameObject itsBG;
	
	// Use this for initialization
	void Start () {
		GameEngine = GameObject.Find("GameEngine");
	}

	
	void OnClick()
	{
		GameEngine.GetComponent<EmailManager>().FileClicked(gameObject);
	}
}
