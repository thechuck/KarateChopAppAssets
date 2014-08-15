using UnityEngine;
using System.Collections;

public class boardScript : MonoBehaviour
{
   
		public Sprite board;
		public Sprite badBoard1;
		public Sprite badBoard2;
		public Sprite badBoard3;
		public Sprite badBoard4;
		public Sprite noBoard;
		public Sprite broken;
		public Sprite face;
		public GUIText scoreText;
	    public GameObject InstructorFace;

    
		public AudioClip chop;
		public AudioClip ouch;

	private int score = 0;
	private float seconds = 0.75f;

		private bool boardBroken = true;
	private bool badBoard = false;
	private bool isBoard = false;
	private bool scoreCount = false;
	private bool end = false;
	private bool faceOn = false;

		public float startTime = 0.75f;
		// Use this for initialization
		void Start ()
		{
		PlayerPrefs.SetInt ("ScoreValue", score);
		PlayerPrefs.Save ();
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				startTime -= Time.deltaTime;
				seconds -= Time.deltaTime;
		if (end && (seconds <=0.0f))
			
		{
			EndGame();
		}

	//	if (faceOn) {
//			InstructorFace.transform.T;
//		}

		if (startTime <= 0.0f) {
		 				BoardSwap ();
						startTime = 0.75f;
						scoreCount = false;
				}
				if (Input.GetMouseButtonDown (0) && isBoard) {
						BreakBoard ();
						boardBroken = true;
			
				}


		}
		void BoardSwap ()
		{
				if (!boardBroken) {	
			    end = true;
				InstructorFace.GetComponent<SpriteRenderer> ().sprite = face;
						
			    seconds = 0.75f;

						
				}
				
				if (!end && !isBoard) {
            
						isBoard = true;
						boardBroken = false;
						Debug.Log ("isBoard true");
						float boardNum = Random.value * 100.0f; 
						if (boardNum > 25.0) {
								badBoard = false;
								Debug.Log ("badBoard false");
								GetComponent<SpriteRenderer> ().sprite = board;
						} else {
								badBoard = true;
								boardBroken = true;
								Debug.Log ("badBoard true");
								int boardType = Random.Range (1, 5);
								switch (boardType) {
								case 1:
										{
												GetComponent<SpriteRenderer> ().sprite = badBoard1;
												break;
										}
								case 2:
										{
												GetComponent<SpriteRenderer> ().sprite = badBoard2;
												break;
										}
								case 3:
										{
												GetComponent<SpriteRenderer> ().sprite = badBoard3;
												break;
										}
								case 4:
										{
												GetComponent<SpriteRenderer> ().sprite = badBoard4;
												break;
										}
								case 5: 
										{
												GetComponent<SpriteRenderer> ().sprite = badBoard1;
												break;
										}

								}
						}
				} else {
						isBoard = false;
						Debug.Log ("isBoard false");
						GetComponent<SpriteRenderer> ().sprite = noBoard;			
				}
		}

		void BreakBoard ()
		{
				
				if (!badBoard) {
		 			GetComponent<AudioSource> ().PlayOneShot (chop);
						if (!scoreCount) {
								score += 1;
								PlayerPrefs.SetInt ("ScoreValue", score);
								PlayerPrefs.Save ();
								UpdateScore ();
						}
						GetComponent<SpriteRenderer> ().sprite = broken;		
						scoreCount = true;
						Debug.Log ("Pressed left click." + score);

				} else {
						InstructorFace.GetComponent<SpriteRenderer> ().sprite = face;
						faceOn = true;
						GetComponent<AudioSource> ().PlayOneShot (ouch);
						seconds = 0.75f;
						end = true;
				}				
		}

		void UpdateScore ()
		{
				scoreText.text = "Score: " + score;
		}


	void EndGame ()
	{              
		Application.LoadLevel ("EndScreen");
	}

}
