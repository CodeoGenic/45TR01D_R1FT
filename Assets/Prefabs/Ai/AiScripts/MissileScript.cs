using UnityEngine;
using System.Collections;

public class MissileScript : MonoBehaviour {

	Rigidbody missile;
	Transform target;
	Vector3 actTarget; 

	// Use this for initialization
	void Start () {

		target = GameObject.FindGameObjectWithTag ("Player").transform;

		missile = FindObjectOfType <Rigidbody> ();

		//float d = Mathf.Infinity;
		//float dist = (target.position - transform.position).sqrMagnitude;

	}
	
	// Update is called once per frame
	void Update () {
			
		Vector3 distance = actTarget - transform.position;
		//missile.velocity = transform.forward * 0f;
		//Debug.Log ("Active****");
		transform.position = Vector3.MoveTowards (transform.position, actTarget, Time.deltaTime * 20f);
		Quaternion rotVal = Quaternion.LookRotation (actTarget - transform.position);
		missile.MoveRotation(Quaternion.RotateTowards(transform.rotation, rotVal, 25f));

		if (transform.position.z < target.position.z + 7f) {

		} else {
			actTarget = target.position;
		}

	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag == "Player") 
		{
			//Debug.Log("The collider box");
			Destroy(gameObject);
			//Debug.Log("dd");
		}					
	}

}
