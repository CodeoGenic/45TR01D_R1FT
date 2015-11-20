using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneFade : MonoBehaviour {
	public int scene;
	public Color screenColor = Color.black;
	public float fadeTime = 0.5f;
    public float delay = 0;
	// Use this for initialization

	void Start () {
		//myColor = GetComponent<Test> ().myColor;
	}
	
	
	void OnGUI () {
//		if (GUI.Button (new Rect (0, 0, 100, 30), "Start")) {
//			Initiate.Fade(scene,myColor,0.5f);	
//		}
	}

	public void startSceneFade(){
        if (delay > 0)
            Invoke("delayStart", delay);
        else
		   Initiate.Fade(scene,screenColor,fadeTime);	
	}
    public void startSceneFade(float delay)
    {
        Debug.Log("scenefade called");
        if (delay > 0)
            Invoke("delayStart", delay);
        else
            Initiate.Fade(scene, screenColor, fadeTime);
    }
    /// <summary>
    /// Delay start time of scene fader. Delay time in seconds
    /// </summary>
    public void delayStart(){
        Initiate.Fade(scene, screenColor, fadeTime);
    }
}
