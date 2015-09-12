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

	void vortexCreation(){
		if (!vortexCreated && Input.GetMouseButton (0)) {
			vortexCreated = true;

			Vector3 curScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y);
			Vector3 mousePos = Camera.main.ScreenToWorldPoint (curScreenPoint);
			mousePos.z = 0;

			GameObject newVortexObject;
			Transform foo = (Transform)Instantiate(vortexObject, mousePos, Quaternion.identity);
			foo.SendMessage("setGroundSource",MovableGroundContainer);
			//newVortexObject = (GameObject)Instantiate(vortexObject, mousePos, Quaternion.identity);
			//newVortexObject.SendMessage("setGroundSource",MovableGroundContainer);
			//Debug.Log(foo.ToString());

		} else if(!Input.GetMouseButton (0)) {
			vortexCreated = false;
		}
	}
}
