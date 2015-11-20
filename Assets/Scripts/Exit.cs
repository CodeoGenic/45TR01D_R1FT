using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {
	//This script is used for the exit scene - marcus 18/06/2015
	// Use this for initialization
	void Start () {
		#if UNITY_EDITOR 
		UnityEditor.EditorApplication.isPlaying = false;
		#else 
		Application.Quit ();
		#endif
	}
	

}
