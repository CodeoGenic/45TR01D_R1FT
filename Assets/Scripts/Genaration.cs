using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Genaration : MonoBehaviour {

	List<GameObject> pickUps;


	public GameObject pickUp;
	//public Transform[] Positions;
	public int pooleSize;
	public float delay = 4.0f;

	void Start () {
		pickUps = new List<GameObject> ();
		for (int i = 0; i < pooleSize; i++) {
			GameObject obj = (GameObject)Instantiate (pickUp);
			obj.SetActive (false);
			pickUps.Add (obj);
		}

		InvokeRepeating ("Spawn", delay, delay);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
	void Spawn(){
		
		for (int i = 0; i < this.pickUps.Count; i++) {
			if(!(pickUps[i].activeInHierarchy)){
				
				//int PositionsIndex = Random.Range (0, Positions.Length);

				pickUps[i].transform.position = new Vector3(Random.Range(-2.8f, 2.8f),
				                                          Random.Range(-1.5f, 3.5f),
				                                          20f) ;// set the positions:marcus-07/06/015
				//pickUps[i].transform.rotation = Quaternion.Euler(0,0,0);				
				pickUps[i].SetActive(true);
				
			}else{
				if(pickUps[i].transform.position.z < -10 ){
					pickUps[i].SetActive(false);
				}
			}
		}
	}
}
