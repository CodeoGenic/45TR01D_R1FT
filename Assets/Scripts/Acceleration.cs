using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Acceleration : MonoBehaviour {
	[System.Serializable]
	public class Boundary 
	{
		public float xMin, xMax, yMin, yMax,zMin,zMax;
	}


	private Vector3 pos = Vector3.zero;
	private Quaternion calibrationQuaternion;
	public Slider Sensitivity;
	public float speed;
	public float tilt;
	public Boundary boundary;
	public Rigidbody rigidbodycontroll;
	// Use this for initialization
	void Start () {
		CalibrateAccelerometer ();
	}


	
	// Update is called once per frame
	void FixedUpdate () {
	 
		Vector3 accelerationRaw = Input.acceleration;
		Vector3 acceleration = FixAcceleration(accelerationRaw);
		Vector3 movement = Vector3.zero;
		movement.x += acceleration.x;
		movement.y += acceleration.y;


		Debug.Log (movement);
		//rigidbodycontroll.position = movement*speed * Time.deltaTime;

		//rigidbodycontroll.position = new Vector3
		movement *= Time.deltaTime;
		transform.Translate(movement * speed);
		transform.position = new Vector3
			(
				Mathf.Clamp (pos.x, boundary.xMin, boundary.xMax), 
				Mathf.Clamp (pos.y, boundary.yMin, boundary.yMax),
				Mathf.Clamp (pos.z, boundary.zMin, boundary.zMax)
				);

		//rigidbodycontroll.transform.RotateAround (rigidbodycontroll.centerOfMass, Quaternion.Euler (0.0f, 0.0f, rigidbodycontroll.velocity.x * -tilt), 30);

	}

	/// <summary>
	/// Calibrates the accelerometer. - marcus-21/06/2015
	/// looks at hoe divice is held and callibrates from that 
	/// </summary>
	void CalibrateAccelerometer () {
		Vector3 accelerationSnapshot = Input.acceleration;
		Quaternion rotateQuaternion = Quaternion.FromToRotation (new Vector3 (0.0f, 0.0f, -1.0f), accelerationSnapshot);
		calibrationQuaternion = Quaternion.Inverse (rotateQuaternion);
	}

	/// <summary>
	/// Fixs the acceleration. - marcus-21/06/2015
	/// </summary>
	/// <returns>The acceleration.</returns>
	/// <param name="acceleration">Acceleration.</param>
	Vector3 FixAcceleration (Vector3 acceleration) {
		Vector3 fixedAcceleration = calibrationQuaternion * acceleration;
		return fixedAcceleration;
	}
}
