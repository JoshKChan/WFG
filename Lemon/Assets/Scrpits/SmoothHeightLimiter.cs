using UnityEngine;
using System.Collections;

/*
 * Intended to "smoothly" move 2D physics objects below a given height limit (y coordinate).
 * Moves them down by adding a force.
 */
public class SmoothHeightLimiter : MonoBehaviour {
	
	public float heightLimit;
	public float force;
	
	void setHeightLimit(float newLimit){
		heightLimit = newLimit;
	}
	
	// Use this for initialization
	void Start () {
		force = -9.0f;
		heightLimit = 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (aboveHeightLimit ()) {
			//Apply a force downwards
			Rigidbody2D rigidBody = (Rigidbody2D)gameObject.GetComponent("Rigidbody2D");
			rigidBody.AddForce (new Vector2 (0, force), ForceMode2D.Impulse);
		}
	}
	
	private bool aboveHeightLimit(){
		float currentHeight = transform.position.y;
		Debug.Log ("currHeight: "+currentHeight);
		return (currentHeight > heightLimit);
	}
	
	
}
