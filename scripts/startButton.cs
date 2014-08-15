using UnityEngine;
using System.Collections;

public class startButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0))
		{
			Debug.Log ("Pressed left click.");
			Application.LoadLevel ("PlayScreen");
		}
	
	}
}
