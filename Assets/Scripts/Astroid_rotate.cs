using UnityEngine;
using System.Collections;

public class Astroid_rotate : MonoBehaviour {

	// Use this for initialization
	public Rigidbody rigidbody;
	public float speed = 10;

	void Start () {		 
		InvokeRepeating ("increaseSpeed",15.0f,5.0f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0,0,-Time.deltaTime*speed);
	}
	// Update is called once per frame
	void FixedUpdate () {
		//Rotate around the center of the of the object
		//transform.Translate(rigidbody.centerOfMass*Time.fixedDeltaTime);
		transform.Rotate(new Vector3(0,0, 45)*Time.fixedDeltaTime);
		//transform.Translate(-rigidbody.centerOfMass*Time.fixedDeltaTime);		
	}
	void increaseSpeed(){
		speed += Settings.speedUP;
		//a speed tracker
		Settings.speed_level++;
	}
}
