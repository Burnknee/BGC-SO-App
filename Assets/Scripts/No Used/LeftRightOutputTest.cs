using UnityEngine;
using System.Collections;

public class LeftRightOutputTest : MonoBehaviour {

	//AudioClip Left;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick()
	{
		Debug.Log ("WTF");
		audio.pan = 0;
		audio.PlayOneShot((AudioClip)Resources.Load ("RightLeftAudioTEst/left"),0.5f);
	}

}
