using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AccelScript : MonoBehaviour {
	//ship movement limits 
	public float maxTargetAngle = 90f;
	//max tilt for device 
	public float maxTiltDeviceAngle = 0.7f;
	//speed ship moves higher = faster 
	public float lerpSpeed = 3f;
	private float outputLerpX;
	private float outputLerpY;
	// deadZone no movement 
	public float deadZone = 0.4f;

	public float falloffAngle = 3f;
	public Slider Sensitivity;
	public float speed = 50f;
	public static float Speed;
	public bool pcControl = false;
	public bool accelerometer = true;
	public float trim = 0.5f;
	float keyboardSpeed = 0.1f;
	private BoxCollider collider;
	public GameObject myObject;
	public Animator anim;
	Vector3 movement,pos, center;
	Quaternion rot;
	private Quaternion calibrationQuaternion;
	// Use this for initialization
	//[System.Serializable]

	/// <summary>
	/// \setsu up thposition of the ship
	/// </summary>
	void Start () {
		Speed = speed;
		rot = transform.rotation;
		center = transform.eulerAngles;
		collider = myObject.GetComponent<BoxCollider> ();
		Input.compensateSensors = true;

	}

	/// <summary>
	/// Start this instance.
	/// </summary>
	//void Start(){
		//CalibrateAccelerometer ();
	//}

	/// <summary>
	/// Calibrates the accelerometer.
	/// </summary>
	public void CalibrateAccelerometer () {//
		Vector3 accelerationSnapshot = Input.acceleration;
		Quaternion rotateQuaternion = Quaternion.FromToRotation (new Vector3 (0.0f, 0.0f, -1.0f), accelerationSnapshot);
		transform.position = accelerationSnapshot;
		transform.rotation = rotateQuaternion;
		calibrationQuaternion = Quaternion.Inverse (rotateQuaternion);
	}

	/// <summary>
	/// Fixs the acceleration.
	/// </summary>
	/// <returns>The acceleration.</returns>
	/// <param name="acceleration">Acceleration.</param>

	//Get the 'calibrated' value from the Input
	  Vector3 FixAcceleration (Vector3 acceleration) {/////////////////////////
		Vector3 fixedAcceleration = calibrationQuaternion * acceleration;
		return fixedAcceleration;
	}
	/// <summary>
	/// Toggles the pc cntrl.
	/// </summary>

	public void togglePcCntrl(){
		if (pcControl)
			pcControl = false;
		else
			pcControl = true;
	}
	// Update is called once per frame

	void Sensitivitycntl(){
		float inputTiltAngleX = Mathf.Clamp(Input.acceleration.normalized.x,-maxTiltDeviceAngle, maxTiltDeviceAngle);
		float outPutAngleX = Mathf.Pow(Mathf.Clamp(Mathf.Abs(inputTiltAngleX)-deadZone, 0, maxTiltDeviceAngle)/(maxTiltDeviceAngle-deadZone), falloffAngle) * maxTiltDeviceAngle;
		float outputDeviceX = Mathf.Clamp(maxTiltDeviceAngle/inputTiltAngleX,-1,1) * outPutAngleX;
		
		outputLerpX = Mathf.Lerp(outputLerpX, outputDeviceX, lerpSpeed * Time.deltaTime); // lerpSpeed variable is defined as 2.5 but can be any value you feel is best
		float outputX = (outputLerpX/maxTiltDeviceAngle) * maxTargetAngle; // retarget it to new angle
		movement.x = outputX;

		float inputTiltAngleY = Mathf.Clamp(Input.acceleration.normalized.y,-maxTiltDeviceAngle, maxTiltDeviceAngle);
		float outPutAngleY = Mathf.Pow(Mathf.Clamp(Mathf.Abs(inputTiltAngleY)-deadZone, 0, maxTiltDeviceAngle)/(maxTiltDeviceAngle-deadZone), falloffAngle) * maxTiltDeviceAngle;
		float outputDeviceY = Mathf.Clamp(maxTiltDeviceAngle/inputTiltAngleY,-1,1) * outPutAngleY;
		
		outputLerpY = Mathf.Lerp(outputLerpY, outputDeviceY, lerpSpeed * Time.deltaTime); // lerpSpeed variable is defined as 2.5 but can be any value you feel is best
		float outputY = (outputLerpY/maxTiltDeviceAngle) * maxTargetAngle; // retarget it to new angle
		movement.y = outputY;


	}


	void FixedUpdate () {

		speed = Speed * Sensitivity.value;

		//if (Application.isEditor) {

			float vertical = Input.GetAxis("Vertical");
			float horizontal = Input.GetAxis("Horizontal");

			if (vertical>0) { //top
				transform.Translate (0, keyboardSpeed * Time.deltaTime * speed, 0);
				transform.rotation = Quaternion.Euler(-30,rot.eulerAngles.y,rot.eulerAngles.z);
				
			} else if (vertical<0) {//bottom
				transform.Translate (0, -keyboardSpeed * Time.deltaTime * speed, 0);
				transform.rotation = Quaternion.Euler(16,rot.eulerAngles.y,rot.eulerAngles.z);
				
			} else if (horizontal<0) {//left
				transform.Translate (-keyboardSpeed * Time.deltaTime * speed, 0, 0);
				transform.rotation = Quaternion.Euler(rot.eulerAngles.x,-30,rot.eulerAngles.z);
				
			} else if (horizontal>0) {//right
				transform.Translate (keyboardSpeed * Time.deltaTime * speed, 0, 0);
				transform.rotation = Quaternion.Euler(rot.eulerAngles.x,30,rot.eulerAngles.z);
				//transform.rotation = Quaternion.AngleAxis(30, Vector3.up);
				
			} else if (pcControl) {
				transform.position = Vector3.Lerp (transform.position, new Vector3 (0, 0, 0), Time.deltaTime * 2.0f);
				transform.eulerAngles=center;
			}
			else{
				transform.eulerAngles=center;
			}
		//}
	
	
		//if(Application.isMobilePlatform){
			Debug.Log("ismobile");

			if (Input.acceleration != null && accelerometer) {



				movement = Vector3.zero;
				movement.x += Input.acceleration.x*trim;
			    movement.y += (Input.acceleration.y *trim) -Input.acceleration.z;			
				
				Debug.Log (movement);
				if (movement.sqrMagnitude > 1)
					movement.Normalize ();	
		//	Sensitivitycntl();

//	
			Vector3 acceleration = FixAcceleration(movement);
			acceleration *= Time.deltaTime;
			transform.Translate (acceleration*speed);
		//	transform.eulerAngles = acceleration *= Time.deltaTime;
				   // Vector3 accelerationRaw = Input.acceleration;//
				    // Vector3 acceleration = FixAcceleration (accelerationRaw);//
				// movement = new Vector3 (acceleration.x, acceleration.y,0.0f );//
				//transform.Translate (movement * speed * Time.deltaTime);//
           
				///maybe animation isnt best for this
			if(acceleration.x > -0.1 && acceleration.x < 0.1){
					anim.SetBool("Idel",true);
				}
			if(acceleration.x<-0.1){//left
					anim.SetBool("Idel",false);
					transform.rotation = Quaternion.Euler(rot.eulerAngles.x,-30,rot.eulerAngles.z);
				}
			else if(acceleration.x>0.1){ //right
					anim.SetBool("Idel",false);
					transform.rotation = Quaternion.Euler(rot.eulerAngles.x,30,rot.eulerAngles.z);
				}

			else if(acceleration.y>0.1){//Up
					anim.SetBool("Idel",false);
					transform.rotation = Quaternion.Euler(-30,rot.eulerAngles.y,rot.eulerAngles.z);
				}
			else if(acceleration.y<-0.1){//down
					anim.SetBool("Idel",false);
					transform.rotation = Quaternion.Euler(30,rot.eulerAngles.y,rot.eulerAngles.z);				
				}
			} else {
				if(pcControl)
					transform.position = Vector3.Lerp(transform.position, new Vector3 (0,0,0), Time.deltaTime * 2.0f);
				transform.eulerAngles=center;
			}
	//	}
	
		//I assume these if statements are what clamp the ship to the screen. I've changed it to use
		//clamping to get rid of all the if statements.
		pos = Vector3.zero;
		pos = transform.position;
		pos.x = Mathf.Clamp(pos.x,-3.5f,3.5f);//clamps between 0.15 and 0.85
		pos.y = Mathf.Clamp(pos.y,-3.5f, 3.5f);
		pos.z = Mathf.Clamp(pos.z,0f, 2.4f);
		transform.position = pos;
			
		
	}



}
