using UnityEngine;
using System.Collections;

//Used FPSDisplay.cs as a base
public class MouseInfo : MonoBehaviour
{
	float deltaTime = 0.0f;

	public int x;
	public int y;
	
	void Update()
	{
		deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
	}
	
	void OnGUI()
	{
		int w = Screen.width, h = Screen.height;

		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float mouseZ = Input.mousePosition.z; //This should always be zero
		bool mouse0Pressed = Input.GetMouseButton (0);
		bool mouse1Pressed = Input.GetMouseButton (1);
		bool mouse2Pressed = Input.GetMouseButton (2);
		
		GUIStyle style = new GUIStyle();
		
		Rect rect = new Rect(x, y, w, h * 2 / 100);
		style.alignment = TextAnchor.UpperLeft;
		style.fontSize = h * 2 / 100;
		style.normal.textColor = new Color (0.0f, 0.0f, 0.5f, 1.0f);

		string text = string.Format("Mouse X:{0} \nMouse Y:{1}\nMouse Z:{2}", mouseX,mouseY,mouseZ);
		text += string.Format ("\n\nMouse 0 Pressed:{0}\nMouse 1 Pressed:{1}\nMouse 2 Pressed:{2}",mouse0Pressed
		                       ,mouse1Pressed,mouse2Pressed);
		GUI.Label(rect, text, style);
	}
}