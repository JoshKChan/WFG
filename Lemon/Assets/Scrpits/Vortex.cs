using UnityEngine;
using System.Collections;

public class Vortex : MonoBehaviour {
	
	private Transform MovableGroundContainer;
	private bool moveUp = false;
	private float maximumRange = 5;
	
	// Use this for initialization
	void Start () {
	}
	
	void setGroundSource(Transform groundContainer){
		MovableGroundContainer = groundContainer;
	}
	
	void setMoveUp(bool input){
		moveUp = input;
	}
	
	// Update is called once per frame
	void Update () {
		if (!Input.GetMouseButton (0) && !Input.GetMouseButton (1)) {
			Destroy (this.gameObject);
		} else {
			correctForceDirection();
			followMouse();
			exertForce();
		}
	}
	
	/*
	 * 	If the left mouse is down, apply the force up. Otherwise apply forces downward.
	 */
	void correctForceDirection(){
		if (Input.GetMouseButton (0)) {
			moveUp = true;
		} else {
			moveUp = false;
		}
	}
	
	/*
	 *  For a given location, determine the distance between the cursor and the input Transform.
	 *  Use that distance to determine force that should be applied.
	 * 
	 *  This needs lots of trial and error to find an algorithm that produces a good force.
	 *  Factors that you could play with:
	 * 		- Maximum Range
	 * 		- Whether to use the x difference or XY difference as distance
	 * 		- Formula to turn distance into force
	 */
	float calculateForce(Transform location){
		float force = 0;
		float distance;
		
		if (location) {
			Vector3 curScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y);
			Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenPoint);
			distance = Mathf.Abs(location.position.x - curPosition.x);
			curPosition.z = location.position.z;
			if(distance < maximumRange){
				distance = Vector3.Distance (location.position, curPosition);
				//force = 1;
				//force = maximumRange - distance; //too strong
				force = Mathf.Abs(1-(distance/maximumRange));
				force *= 10f;
			}
			Debug.Log("Distance: "+distance+"\tForce: "+force);
		}
		return force;
	}
	
	float force = 1;
	void exertForce(){
		if (MovableGroundContainer != null) {
			foreach (Transform child in MovableGroundContainer) {
				float force = calculateForce(child);
				if(force > 0){
					Rigidbody2D rigidBody = (Rigidbody2D)child.GetComponent ("Rigidbody2D");
					if(!moveUp){
						force*=-1;
						Debug.Log("Vortex.exertForce()\tDownwards");
					}
					rigidBody.AddForce (new Vector2 (0, force), ForceMode2D.Impulse);
				}
			}
			Debug.Log("exertForce()");
		} else {
			Debug.Log("No ground container. Cannot exertForce()");
		}
	}
	
	//isBelowXTolerance
	void isBelow(Transform other){
		//
	}
	
	void followMouse(){
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
		curPosition.z = 0;
		transform.position = curPosition;
	}
	
}
