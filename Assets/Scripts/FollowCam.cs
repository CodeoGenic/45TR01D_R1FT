/* Vivek 05/06/15
 * Attach this code to the main camera and then provide the reference to the ship
 * Adjust the parameters if necessary.
 */

using UnityEngine;
using System.Collections;
public class FollowCam : MonoBehaviour {
	GameObject ship;
   public  Transform player; // Provide ship reference
	public float smoothDam = 1.3f; // How smoothly the camera should follow.
	public float followX = 0.0f; // Following distance.
	public float followY = 1.0f;
	public float followZ = -3.5f;
	private Vector3 speed = Vector3.zero;
	private Vector3 targetPos;

	void Awake () {


//		chosenShip = PlayerPrefs.GetInt("chosenShip");
//		ship1 = GameObject.Find("ship1");
//		ship2 = GameObject.Find("ship2");
//		ship3 = GameObject.Find("ship3");
//		
//		if (chosenShip == 0) {
//			player = ship1.GetComponent<Transform>();
//		}
//		else if(chosenShip == 1){
//			player = ship2.GetComponent<Transform>();
//		}
//		else if(chosenShip == 2){
//			player = ship3.GetComponent<Transform>();
//		}
		//targetPos = player.TransformPoint (new Vector3 (followX, followY, followZ)); 	
	}


    void FixedUpdate()
    {
        //Distance between camera and the ship
        targetPos = player.TransformPoint(new Vector3(followX, followY, followZ));
        //follow the ship
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref speed, smoothDam);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref speed, smoothDam);
    }
}
