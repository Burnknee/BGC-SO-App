using UnityEngine;
using System.Collections;

public class SplashScreenAnimManager : MonoBehaviour {

	private bool isDone = false;
	public GameObject fadeSprite;

	// Use this for initialization
	void Start () {
	
	}

	IEnumerator splashAnimation()
	{
		fadeSprite.animation.Play("SplashScreenFadeSpriteAnim");
		yield return new WaitForSeconds(fadeSprite.animation["SplashScreenFadeSpriteAnim"].length);
		isDone = true;
		Application.LoadLevel("Front-End");
	}

	// Update is called once per frame
	void Update () {
	
		if(!isDone)
		{
			StartCoroutine(splashAnimation());
		}

	}
}
