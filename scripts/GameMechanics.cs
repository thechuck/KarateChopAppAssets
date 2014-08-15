using UnityEngine;
using System.Collections;


public class GameMechanics : MonoBehaviour {

	public Sprite Instructor02;
	public Sprite Instructor01;
	public float startTime = 0.75f;
	public AudioClip grunt;
	private bool Instructor2 = false;
    
	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer>().sprite = Instructor02;
		Instructor2 = true;
		Debug.Log ("Instructor2 true");
	}

	void Update(){
		//every 2 seconds check and see which instructor image is up and change them.
        
		startTime -= Time.deltaTime;
		if ( startTime <= 0.0f)
		{
			InstructorSwap ();
			startTime = 0.75f;
		}
		
	}

	void InstructorSwap()
	{
		if (Instructor2)
		{
			Instructor2 = false;
			Debug.Log ("Instructor2 false");
			GetComponent<AudioSource>().PlayOneShot(grunt);
			GetComponent<SpriteRenderer>().sprite = Instructor01;
		}
		else
		{
			Instructor2 = true;
			Debug.Log ("Instructor2 true");
			GetComponent<SpriteRenderer>().sprite = Instructor02;
			
		}
		}

}
