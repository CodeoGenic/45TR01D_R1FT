using UnityEngine;
using System.Collections;

public class FollowPath : MonoBehaviour {

	Vector3[] path, path2, path3, path4, path5;
	Bounds bound;
	int pathSet = 0;
	Vector3 target, playerOrgin;
	Rigidbody aiShip;
	Transform player;
	private MLauncher launcher;

	// Use this for initialization
	void Awake () {

		player = GameObject.FindGameObjectWithTag ("Player").transform;
		playerOrgin = player.position;

		path2 = new []{ new Vector3(10.0f,20.0f,40f), new Vector3(10f,10f,20f), 
			playerOrgin, new Vector3(0f,10f,-10f), new Vector3( 0f, -5f, -20f), new Vector3(10f,-10f,5f),
			new Vector3(5f,5f,15f), new Vector3(0f,20f,20f)};

		path3 = new []{ new Vector3(30.0f,6.0f,60f), new Vector3(9f,40f,40f), 
			new Vector3(15.2f,2f,20f), new Vector3(0f,0f,5f), new Vector3( 4f, 7f, -30f), new Vector3(16f,4f, 5f)};

		path4 = new []{ new Vector3(20.0f,30.0f,60f), new Vector3(5f,70f,40f), 
			new Vector3(28.2f,21f,20f), new Vector3(0f,0f,5f), new Vector3( 4f, 7f, -30f), new Vector3(16f,4f, 5f)};

		path5 = new []{ new Vector3(20.0f,30.0f,60f), new Vector3(5f,-70f,30f), 
			new Vector3(11.2f,16f,20f), new Vector3(0f,0f,5f), new Vector3( 4f, -17f, -30f), new Vector3(16f,4f, 5f)};

		aiShip = FindObjectOfType <Rigidbody> ();
		launcher = GetComponent<MLauncher> ();

		path = path2;
		target = path[0];
		bound = new Bounds (path[0], new Vector3(1f,1f,1f));
	
	}
	// Update is called once per frame
	void FixedUpdate () {

		float speed = 7f * Time.deltaTime;
		//Debug.Log(transform.position);
		//Debug.Log ("Work*************: ");


		//Debug.Log ("Work*************: " + path[pathSet]);
		//Vector3 targetDirection = target - transform.position;
		//transform.position = Vector3.MoveTowards (transform.position, target, speed);
	
		Quaternion rotVal = Quaternion.LookRotation (target - transform.position);

		//Vector3 direction = Vector3.RotateTowards (transform.forward, targetDirection, 20f, 0.0f);
		//transform.rotation = Quaternion.LookRotation (direction);
		aiShip.MoveRotation(Quaternion.RotateTowards(transform.rotation, rotVal, 2f));
		transform.position += transform.forward * speed;
	
		if (bound.Contains(transform.position))
		{
			pathSet++;

			if(pathSet >= path.Length)
			{
				pathSet = 0;
				
				path = getPath();
			}			 
				//transform.position.z < 20f

			//Debug.Log ("PositionZ: " + transform.position.z);

			bound.center = path[pathSet];
			target = path[pathSet];

			//Debug.Log ("**Playter Orgin: " + playerOrgin + "In array: " + path[2]);
		}

		if(path[pathSet].Equals(playerOrgin) && transform.position.z <= 5f)
		{
			pathSet++;
			bound.center = path[pathSet];
			target = path[pathSet];
			launcher.StopFire();
			launcher.ActivateShoot();

		}

		if (path[pathSet].Equals(playerOrgin)) 
		{

			launcher.StartFire();
		}

	}

	Vector3[] getPath()
	{
		int val = Random.Range (0, 4);
		Debug.Log ("Random*************: " + val);
		Vector3[] temp = path2;
		/*
		if (val == 0) {
			temp = path2;
		} else if (val == 1) {
			temp = path3;
		} else if (val == 2) {
			temp = path4;
		} else {
			temp = path5;
		}
		*/
		return temp;
	}
}
