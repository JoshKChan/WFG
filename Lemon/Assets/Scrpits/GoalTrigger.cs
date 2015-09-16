using UnityEngine;
using System.Collections;

public class GoalTrigger : MonoBehaviour {
	GameObject football;

	void OnTriggerEnter2D()
	{
		Debug.Log ("Trigger went");
		football = GameObject.Find("Football"); 

		if (football != null) {

			football.SendMessage( "AddToCount", null );
		}
	}

}
