using UnityEngine;
using System.Collections;

public class FolderItem : MonoBehaviour {

	public string nameOfFolder;
	private GameObject GameEngine;
	public GameObject itsBG;

	// Use this for initialization
	void Start () {
		GameEngine = GameObject.Find("GameEngine");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick()
	{
		GameEngine.GetComponent<EmailManager>().FolderClicked(gameObject);
	}
}
