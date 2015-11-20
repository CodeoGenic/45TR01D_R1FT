using UnityEngine;
using System.Collections;

public class ShootPlayer : MonoBehaviour {

	public float shootingRange = 300f;
	public float bulletFireRate = 20.75f;

	float timer;
	Ray shootRay;
	RaycastHit hit;
	LineRenderer visualLine;
	float effectVisibleTime = 0.3f;
	Transform player;
	// Use this for initialization
	void Awake () {
		visualLine = GetComponent<LineRenderer> ();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		visualLine.SetColors (Color.red, Color.red);
		visualLine.SetWidth (0.01f, 0.01f);
	}
	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;

		if (transform.position.z <= player.position.z + 150 && timer >= bulletFireRate) 
		{
			Shoot();
		}

		if (timer >= bulletFireRate * effectVisibleTime) 
		{
			DisableEffects();
		}

	}

	public void DisableEffects()
	{
		visualLine.enabled = false;
	}

	void Shoot()
	{
		Debug.Log("works");
		timer = 0;
		visualLine.enabled = true;
		visualLine.SetPosition (0, transform.position);

		shootRay.origin = transform.position;
		shootRay.direction = transform.forward;

		if (Physics.Raycast (shootRay, out hit, shootingRange)) {
			visualLine.SetPosition (1, hit.point);
		} else {
			visualLine.SetPosition (1, shootRay.origin + shootRay.direction * shootingRange);
		}

	}
}
