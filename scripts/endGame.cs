using UnityEngine;
using System.Collections;

public class endGame : MonoBehaviour {
	public int score = 0; 
	public GUIText finalScore;

	// Use this for initialization
	void Start () {
		score = PlayerPrefs.GetInt ("ScoreValue");
		ShowScore ();
	}
	
	// Update is called once per frame
	void Update () {
		ShowScore ();
	}
	void ShowScore()
	{
		finalScore.text = "Final Score: " + score;
	}
}
