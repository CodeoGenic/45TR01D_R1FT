using UnityEngine;
using System.Collections;

public class BillboardingScript : MonoBehaviour {

	Transform t;
	Transform target;

	// Use this for initialization
	void Start () {
	
	}

	void Awake()
	{
		t = transform;
		target = Camera.main.transform;
		t.rotation = Quaternion.Euler(0, 260, 0);
	}

	// Update is called once per frame
	void Update () {
		t.LookAt (target);
		t.rotation = t.rotation * Quaternion.Euler(90, 0, 0);
	}
}
