using UnityEngine;
using System.Collections;

public class LoadinyScreen : MonoBehaviour {

	public GUITexture background;
	public GUIText text;
	public GUITexture loadingBar;
	int counter = 0;
	int loadProgress = 0;
	// Use this for initialization
	void Start () {
	
		background = background.GetComponent<GUITexture> ();
		text = text.GetComponent<GUIText> ();
		loadingBar = loadingBar.GetComponent<GUITexture> ();
		InvokeRepeating ("Loading",0,0.3f);
		StartCoroutine (LoadingScreen(2));
	}
	
	// Update is called once per frame
	void Update () {


	}
	void Loading(){
		counter++;
		
		switch(counter){
		case 0:
			text.text = "LOADING.";
			break;
		case 1:
			text.text = "LOADING..";
			break;
		case 3:
			text.text = "LOADING...";
			break;
		}

	}
	IEnumerator LoadingScreen(int screen){
//		loadingBar.transform.localScale = new Vector3 (loadProgress, loadingBar.transform.localScale.y, 
//		                                               loadingBar.transform.localScale.z);

//		loadingBar.pixelInset.width = new Vector3 (loadProgress, loadingBar.transform.localScale.y, 
//		                                               loadingBar.transform.localScale.z);
		AsyncOperation asyn = Application.LoadLevelAsync(screen);
		float width = loadingBar.pixelInset.width;
		while (!asyn.isDone) {
			loadProgress = (int)(asyn.progress*100);
//			loadingBar.transform.localScale = new Vector3 (asyn.progress, loadingBar.transform.localScale.y,
//			                                               loadingBar.transform.localScale.z);
			loadingBar.pixelInset = new Rect(loadingBar.pixelInset.x,loadingBar.pixelInset.y,width+(loadProgress*10),
			                                       loadingBar.pixelInset.height);
			yield return null;
		}
       


	}

}
