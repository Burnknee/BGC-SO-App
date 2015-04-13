using UnityEngine;
using System.Collections;

public class CalibrationPlayToneBtn : MonoBehaviour {

	private AudioClip theCaltone; 
	//private AudioSource _AudioSource;
	private int dB_temp;
	private float conv_temp;

	public UILabel Cal_dB_Label;
	public UILabel Cal_Conv_Label;
	// Use this for initialization
	void Start () {
	
		theCaltone =  (AudioClip)Resources.Load ("CRMwavesprocessed/caltone");
		//_AudioSource = new AudioSource();
		//_AudioSource = gameObject.AddComponent ("AudioSource") as AudioSource;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick()
	{
		//UnityNumber = db*Conv

		if(!audio.isPlaying)
		{
			int.TryParse(Cal_dB_Label.text, out dB_temp);
			float.TryParse(Cal_Conv_Label.text, out conv_temp);

			audio.volume = (float)dB_temp * conv_temp;
			Debug.Log("Volume: "+audio.volume);
			audio.clip = theCaltone;
			audio.Play();
		}
		else
		{
			Debug.Log("Its Playing!");
		}

	}
}
