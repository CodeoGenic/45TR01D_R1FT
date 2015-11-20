using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Store : MonoBehaviour {
    
    public GameObject mainPanel;
    public Toggle ship;
    public Toggle fuel;
    public Toggle item;
	
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void returnToMenu()
    {
        //Application.LoadLevel (1);
        Application.LoadLevel(0);
    }
}
