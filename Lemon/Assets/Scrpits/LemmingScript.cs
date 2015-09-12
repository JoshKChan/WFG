using UnityEngine;
using System.Collections;

public class LemmingScript : MonoBehaviour {

	public float speedFactor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		MoveForward();
	}

	/*
	 * Automatically move forward.
	 * 
	 * TODO Only move when "feet" are on some kind of "ground"?
	 */
	void MoveForward(){
		transform.Translate(Vector3.right * Time.deltaTime * speedFactor);
	}
}
