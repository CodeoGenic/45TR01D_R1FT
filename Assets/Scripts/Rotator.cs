using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(1, 1, 1));
        transform.Rotate(new Vector3(15, 30, 45)*Time.deltaTime);
	    transform.Translate(new Vector3(-1, -1, -1));
        
	}
}
