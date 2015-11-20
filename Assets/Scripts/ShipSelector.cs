using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ShipSelector : MonoBehaviour {
	 int chosenShip;




	void Start () {



	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ship1(){
		chosenShip = 0;
		onShipSelect ();
	}
	public void ship2(){
		chosenShip = 1;
		onShipSelect ();
	}
	public void ship3(){
		chosenShip = 2;
		onShipSelect ();
	}
    public void onShipSelect()
    {
		PlayerPrefs.SetInt ("chosenShip", chosenShip);
		PlayerPrefs.Save ();
		

        Application.LoadLevel(1);
    }
}
