using UnityEngine;
using System.Collections;

public class Geomancy : MonoBehaviour {
	
	bool vortexCreated;
	
	public Transform vortexObject;
	public Transform MovableGroundContainer;
	
	// Use this for initialization
	void Start () {
		vortexCreated = false;
	}
	
	// Update is called once per frame
	void Update () {
		vortexCreation ();
	}
	
	/*
	 * 	Create a Vortex at the same location as the mouse if either the left or right mouse button
	 *  is down.
	 */
	void vortexCreation(){
		if (!vortexCreated) {
			bool leftMouseDown = Input.GetMouseButton (0);
			bool rightMouseDown = Input.GetMouseButton (1);
			if(leftMouseDown || rightMouseDown){
				vortexCreated = true;
				Vector3 curScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y);
				Vector3 mousePos = Camera.main.ScreenToWorldPoint (curScreenPoint);
				mousePos.z = 0;
				
				Transform foo = (Transform)Instantiate (vortexObject, mousePos, Quaternion.identity);
				foo.SendMessage ("setGroundSource", MovableGroundContainer);
			}
		}else if (!Input.GetMouseButton (0) && !Input.GetMouseButton (1)){
			vortexCreated = false;
		}
	}//vortexCreation
}
