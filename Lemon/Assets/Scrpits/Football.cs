using UnityEngine;
using System.Collections;

public class Football : MonoBehaviour {

	public bool isFound;

	void Start (){
		isFound = false;
	}

	void Update(){
	}

	void AddToCount() {
		if (isFound == false) {
			isFound = true;
			ScoreCounter.points++;
		}
	}
}
