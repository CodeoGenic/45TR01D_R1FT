using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;

public class AstroidGen : MonoBehaviour {
	//public GameObject player;
	public GameObject astroid;
	public int pooledAmount = 10;
	private float width, height, length;
	
	Vector3 cube_pos2;
	public float delay = 4.0f;
	int counter;	
	public Transform[] astriodPositions;// can add as many tranforms to this has we want in the scene view:marcus- 07/06/15		
	List<GameObject> cubes;
	
	// Use this for initialization
	void Start () {
		cubes = new List<GameObject> ();
		for (int i = 0; i < pooledAmount; i++) {
			GameObject obj = (GameObject)Instantiate (astroid);
			obj.SetActive (false);
			cubes.Add (obj);
		}
		counter = 0;
		InvokeRepeating ("SpawnCubes", delay, 0.3f);
		InvokeRepeating ("calculateScale", delay, 0.2f);
		
	}
	// Update is called once per frame
	void Update () {	

	    if(Settings.gamestate == GameState.EXIT) {
            if(IsInvoking("calculateScale"))
                CancelInvoke("calculateScale");

            if(IsInvoking("SpawnCubes"))
                CancelInvoke("SpawnCubes");            
            
        }
	}
	
	void SpawnCubes(){
		
		for (int i = 0; i < this.cubes.Count; i++) {
			if(!(cubes[i].activeInHierarchy)){
				
				int astriodPositionsIndex = Random.Range (0, astriodPositions.Length);
				
				if( astriodPositionsIndex+1 >= astriodPositions.Length ){
					
				}else{
					cube_pos2 = astriodPositions[astriodPositionsIndex+1].position;
				}			
				cubes[i].transform.localScale = new Vector3(width,height,length);
				//sets position based on transforms placed in editor - marcus- 24/06/2015
				cubes[i].transform.position = astriodPositions[astriodPositionsIndex].position;
				cubes[i].transform.rotation = astriodPositions[astriodPositionsIndex].rotation;				
				cubes[i].SetActive(true);

			}else{
				if(cubes[i].transform.position.z < -10 ){
					cubes[i].SetActive(false);
				}
			}
		}
	}
	
	void calculateScale(){
		
		switch (counter) {
		case 3:			
			if(Settings.speed_level>4){
				width = length = Random.Range (3f, 4);
				height =Random.Range (3.5f, 5.5f);
			}
			else{
				width = length = Random.Range (3.2f, 1.5f);
				height =Random.Range (1.2f, 3.6f);
			}			
			break;
        case 5:           
                width = length = Random.Range(3.5f, 4);
                height = Random.Range(2f, 6f);               
            
            break;
		case 7:
			if(Settings.speed_level>8)
				width = height = length = Random.Range (2f, 5.5f);
			break;
		case 16:
			if(Settings.speed_level>15){
				width = height = Random.Range (2, 6);
				length = Random.Range (1,6);
			}
			counter = 0;
			break;
		default:
			width = height = length = 3.4f;
			break;
		}
		counter++;
	}
}
