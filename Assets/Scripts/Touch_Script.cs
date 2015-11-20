using UnityEngine;
using System.Collections;

public class Touch_Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Touch myTouch = Input.GetTouch (0);
	     
	
			//Input.touches
	}

	void OnGUI()
	{
		foreach (Touch touch in Input.touches) {
			string message = "";
			message += "ID: " + touch.fingerId +"\n";
			message += "Phase: " + touch.phase +"\n";
			message += "TapCount:" + touch.tapCount+"\n";
			message += "position x:" + touch.position.x +"\n";
			message += "position y:" + touch.position.y+"\n";

			int num = touch.fingerId;
			GUI.Label(new Rect(0 + 130 * num,0,120,100),message);
		}
	}
}
