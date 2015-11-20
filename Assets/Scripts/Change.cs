using UnityEngine;
using System.Collections;

public class Change : MonoBehaviour {

	ChangeSkybox changeS;
	bool changed = false;
	Touch touch;

	void Start () {
		changeS = gameObject.GetComponent<ChangeSkybox> ();
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.touchCount == 1 && changed == false) {
			changeS.Warp();
			changed = true;
		}
		else if(Input.touchCount == 1 && changed == true) {
			changeS.MainSkybox();
			changed = false;
		}

		if (Input.GetKey ("f"))
		{
			changeS.Warp();
		}

		else if (Input.GetKey ("b"))
		{
			changeS.MainSkybox();
		}
	}
}
