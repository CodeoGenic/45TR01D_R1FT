using UnityEngine;
using System.Collections;

public class MLauncher : MonoBehaviour {

	public Rigidbody missile;
	private bool shoot = true;

	// Use this for initialization
	void Start () {
		//Fire ();
		//StartFire ();

	}
	
	// Update is called once per frame
	void FixedUpdate () {

	}

	public void StartFire()
	{
		//Debug.Log ("Work*************kkkAAk: ");
		if (shoot) {
			InvokeRepeating ("Fire", 1f, 1f);
			shoot = false;
		}

	}

	public void ActivateShoot(){
		shoot = true;
	}

	public void StopFire()
	{
		CancelInvoke ("Fire");
	}

	void Fire()
	{
		Instantiate (missile, transform.position, transform.rotation);
	}
}
