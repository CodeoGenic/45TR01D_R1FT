using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Boomlagoon.JSON;

public class ListAdapter : MonoBehaviour
{

	public GameObject listLayout;
	public GameObject container;
	public GameObject spinner;
	public InputField player_name;
	public InputField player_loc;
	public Text error_name;
	public Text error_loc;
	public Text highScore;
	public bool isUploadDone;
	List<GameObject> item_list;
	//http://api-rift.rohanpetty.com/api.php?getArScore=player&postscore=&name=&score=&location=
	const string save_method = "postscore=";
	const string _name = "&name=";
	const string _score = "&score=";
	const string _loc = "&location=";
	const string _id = "&userid=";
	const string publicCode = "getArScore=";
	const string webURL = "http://api-rift.rohanpetty.com/api.php?";

	void Awake ()
	{
		item_list = new List<GameObject> ();
		highScore.text = highScore.text + " " + PlayerPrefs.GetInt ("Player_Distance");
	}

	void Start ()
	{
	}

	// Update is called once per frame
	void Update ()
	{

		if (container.activeSelf && isUploadDone) {

			//showEntries ();

		} 
	}

	public void showEntries ()
	{
		for (int i = 0; i < this.item_list.Count; i++) {
			if (!(item_list [i].activeInHierarchy))
				item_list [i].SetActive (true);
		}
	}

	public void clearEntries ()
	{

//
//		for (int i = 0; i < this.item_list.Count; i++) {
//			if (!(item_list [i].activeInHierarchy))
//				item_list.
//		}
		if (item_list.Count > 1) {

			for (int i = 0; i < this.item_list.Count; i++) {
				Destroy(item_list[i]);

			}
		}
		item_list.Clear ();

	}

	public void getDataFromServer ()
	{
		if (!spinner.activeSelf) {
			spinner.SetActive (true);
		}
		StartCoroutine ("DownloadHighscoresFromDatabase");
	}

	public bool AddNewHighscore ()
	{
		string username;
		if (player_name.text.Length > 1)
			username = player_name.text;
		else {
			error_name.text = "Field is empty";
			return false;
		}

		int score = PlayerPrefs.GetInt ("Player_Distance");

		string country = player_loc.text;

		if (!spinner.activeSelf) {
			spinner.SetActive (true);
			isUploadDone = false;
		}
		StartCoroutine (UploadNewHighscore (username, score, country));
		return true;
	}

	IEnumerator UploadNewHighscore (string username, int score, string country)
	{
		WWW www;
		if (PlayerPrefs.HasKey ("unique_id")) {
			string ID = "" + PlayerPrefs.GetInt ("unique_id");
			www = new WWW (webURL + save_method + _name + username + _score + score + _loc + country + _id + ID);
		} else {
			www = new WWW (webURL + save_method + _name + username + _score + score + _loc + country);
		}
        

        
		yield return www;

		if (string.IsNullOrEmpty (www.error)) {
			print ("Upload Successful");
			spinner.SetActive (false);
			isUploadDone = true;
			if (!PlayerPrefs.HasKey ("unique_id")) {
				PlayerPrefs.SetInt ("unique_id", int.Parse (www.text));
			}
           

		} else {

			print ("Error uploading: " + www.error);
		}
	}

	IEnumerator DownloadHighscoresFromDatabase ()
	{

		string url = webURL + publicCode + "player";
		Debug.Log (url);
		WWW www = new WWW (url);
		yield return www;

		if (!string.IsNullOrEmpty (www.error)) {
			//Debug.Log("yielding null");
			yield return null;
		} else {
			spinner.SetActive (false);
			FormatHighscores (www.text);
		}
	}

	void FormatHighscores (string textStream)
	{
		Debug.Log ("formathighscores");
		JSONObject results = JSONObject.Parse (textStream);
		JSONArray query = results.GetArray ("query");

		Debug.Log (query.ToString ());

		for (int i = 0; i < query.Length; i++) {
			//Debug.Log(query[i].Obj.GetString("player"));
			//Debug.Log(int.Parse(query[i].Obj.GetString("score")));
			//Debug.Log(query[i].Obj.GetString("location"));

			GameObject obj = (GameObject)Instantiate (listLayout);
			obj.SetActive (false);
			Text name = obj.transform.Find ("pl name").GetComponent<Text> ();
			Text score = obj.transform.Find ("pl score").GetComponent<Text> ();
			Text country = obj.transform.Find ("country").GetComponent<Text> ();
			name.text = query [i].Obj.GetString ("player");
			score.text = query [i].Obj.GetNumber ("score").ToString ();
			country.text = query [i].Obj.GetString ("location");
			obj.transform.SetParent (container.transform);
			obj.transform.localScale = new Vector3 (1, 1, 1);

			item_list.Add (obj);

		}
		showEntries ();

	}

	public void nameValidator ()
	{
		error_name.text = "";
	}

	public void countryValidator ()
	{
		error_loc.text = "";
	}



}
