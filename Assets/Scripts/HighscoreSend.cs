using UnityEngine;
using System.Collections;


public class HighscoreSend : MonoBehaviour {

    string name;
	public int distance;
    string location;
    int level;
	string text;
	string data;
	string post_url = "http://www.codeogenic.oliverswebsite.com/API.php";
	WWWForm wwwForm;
	WWW www;
	ScoreV3 scoreV3;
	string distanceValue;

	// Use this for initialization
	void start()
	{
    	scoreV3 = GetComponent<ScoreV3>();
//		distance = scoreV3.getDistance();
		connection ();
	}
    IEnumerator connection()
	{
		wwwForm = new WWWForm();
		//wwwForm.AddField ("Name",name);
		wwwForm.AddField ("Distance",distance);
		//wwwForm.AddField ("Location",location);
		//wwwForm.AddField ("Level",level);
		//wwwForm.AddField ("Score", score);
	    
		www = new WWW (post_url,wwwForm);
		yield return www;
		if (www.error != null)
		{
			Debug.Log("Error"+www.error);
		}
		else{
			text = www.text;
			www.Dispose();
			Debug.Log("Success"+www.text);
		}
	}


	IEnumerator RetrieveData()
	{
		WWW www = new WWW (post_url);
		yield return www;


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
