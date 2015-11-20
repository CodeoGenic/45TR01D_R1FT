using UnityEngine;
using System.Collections;

public class CharacterSelect : MonoBehaviour {
	int chosenShip;

	GameObject ship1;
	GameObject ship2;
	GameObject ship3;

	void Awake() {
		ship1 = GameObject.Find ("ship1");
		ship2 = GameObject.Find ("ship2");
		ship3 = GameObject.Find ("ship3");

		IntialLoad ();
	}
	
	// Update is called once per frame
	void Update () {
//		if (Input.GetMouseButtonUp (0)) {
//			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//			RaycastHit hit;
//
//			if(Physics.Raycast(ray,out hit,100)){
//				if(hit.collider.name == "Character1"){
//					SelectedCharater1();
//				}
//
//				if(hit.collider.name == "Character2"){
//					SelectedCharater2();
//				}
//
//				if(hit.collider.name == "Character3"){
//					SelectedCharater3();
//				}
//
//				if(hit.collider.name == "Character4"){
//					SelectedCharater4();
//				}
//			}
//		}

	}

	void Rotate(){

	}

	void IntialLoad(){
	
	int intial = PlayerPrefs.GetInt ("ship");

		if (chosenShip == 0) {
			SelectedCharater1();
		}
		if (chosenShip == 1) {
			SelectedCharater2();
		}
		if (chosenShip == 2) {
			SelectedCharater3();
		}
	}

 public	void SelectedCharater1(){
		Debug.Log("Chracter 1 Selected");
		chosenShip = 0;
		ship1.SetActive (true);
		ship2.SetActive (false);
		ship3.SetActive (false);

	}

public void SelectedCharater2(){
		Debug.Log("Chracter 2 Selected");
		chosenShip = 1;
		ship1.SetActive (false);
		ship2.SetActive (true);
		ship3.SetActive (false);

	}

public void SelectedCharater3(){
		Debug.Log("Chracter 3 Selected");
		chosenShip = 2;
		ship1.SetActive (false);
		ship2.SetActive (false);
		ship3.SetActive (true);


	}

	void SelectedCharater4(){
		Debug.Log("Chracter 4 Selected");
		chosenShip = 3;
	}

	public void StartGame(){
		PlayerPrefs.SetInt ("chosenShip", chosenShip);
		PlayerPrefs.Save ();
		Application.LoadLevel(1);
	}


}
