using UnityEngine;
using System.Collections;

public class ScoreDisplay : MonoBehaviour {

	void OnGUI()
	{
		int w = Screen.width, h = Screen.height;
		
		GUIStyle style = new GUIStyle();
		
		Rect rect = new Rect(1000, 10, w, h * 2 / 100);
		style.alignment = TextAnchor.UpperLeft;
		style.fontSize = 20;
		style.normal.textColor = new Color (0.0f, 0.0f, 0.5f, 1.0f);
		string text = "Current Score: " + ScoreCounter.points;
		GUI.Label(rect, text, style);
	}
}
