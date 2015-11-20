using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Assets.Scripts;

public class GameLogic : MonoBehaviour
{


	//public Canvas mainPanel;
	public Button play;
	public Button exit;
	bool timeIsSlowed;
	public GameObject pauseMenu;
	public GameObject panel_1;
	public GameObject panel_2;
	public AudioSource audioControl;
	public GameObject gameOver;
	public GameObject endGame;
	private GameObject panel3;
	public ScoreV3 score;
	private AccelScript player;
	public Toggle touchBtn;
	public Toggle accelBtn;
	private Touch_Control touchFunction;
	public SceneFade sceneFade;
	private bool isExiting;
	public Toggle music;
	bool gameStarted;
	public Settings Gsettings;
	public Transform shipPos;
	int chosenShip;
	GameState state;
	GameObject ship1;
	GameObject ship2;
	GameObject ship3;
	GameObject ship1Cam;
	GameObject ship2Cam;
	GameObject ship3Cam;

	// Use this for initialization
	void Awake ()
	{
		//audioCheck = PlayerPrefs.GetInt ("Audio");
		chosenShip = PlayerPrefs.GetInt ("chosenShip");
		//chosenShip = 0;
		ship1 = GameObject.Find ("ship1");
		ship2 = GameObject.Find ("ship2");
		ship3 = GameObject.Find ("ship3");
		ship1Cam = GameObject.Find ("ship1Cam");
		ship2Cam = GameObject.Find ("ship2Cam");
		ship3Cam = GameObject.Find ("ship3Cam");

		if (chosenShip == 0) {
			ship1.SetActive (true);
			ship2.SetActive (false);
			ship3.SetActive (false);
			ship1Cam.SetActive (true);
			ship2Cam.SetActive (false);
			ship3Cam.SetActive (false);
			player = ship1.GetComponent<AccelScript> ();
			touchFunction = ship1.GetComponent<Touch_Control> ();
		} else if (chosenShip == 1) {
			ship1.SetActive (false);
			ship2.SetActive (true);
			ship3.SetActive (false);
			ship1Cam.SetActive (false);
			ship2Cam.SetActive (true);
			ship3Cam.SetActive (false);
			player = ship2.GetComponent<AccelScript> ();
			touchFunction = ship2.GetComponent<Touch_Control> ();
		} else if (chosenShip == 2) {
			ship1.SetActive (false);
			ship2.SetActive (false);
			ship3.SetActive (true);
			ship1Cam.SetActive (false);
			ship2Cam.SetActive (false);
			ship3Cam.SetActive (true);
			player = ship3.GetComponent<AccelScript> ();
			touchFunction = ship3.GetComponent<Touch_Control> ();
		}
		isExiting = false;
		state = GameState.PLAYING;
		Settings.gamestate = state;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		Time.timeScale = 0.0f;


		//score = score.GetComponent<ScoreV3> ();
		score.setDistance (0);
		score.stopScore ();
		audioControl.mute = true;
		gameStarted = false;
		if (pauseMenu.activeSelf) {
			pauseMenu.SetActive (false);
		}
		panel3 = panel_2.transform.FindChild ("sensitivity_panel").gameObject;
	
		gameOver.SetActive (false);
		Settings.health = 10000;
		if (!accelBtn.isOn && !touchBtn.isOn) {
			accelBtn.isOn = true;
			player.accelerometer = true;
			touchFunction.touchOn = false;
		}
           


	}
	
	// Update is called once per frame
	void Update ()
	{
        

		if (Input.GetKeyDown (KeyCode.Escape)) {
			pause (pauseMenu);
		}
		if (Settings.health <= 0) {
			if (!gameOver.activeSelf) {
				gameOver.SetActive (true);
				if (score.getDistance () > score.getOldDistance ()) {

					PlayerPrefs.SetInt ("Player_Distance", score.getDistance ());
					PlayerPrefs.Save ();
				}
				score.stopScore ();
				state = GameState.EXIT;
				Settings.gamestate = state;
				sceneFade.startSceneFade ();  
			}
		}

		if (isExiting) {
			if (!endGame.activeSelf) {
				endGame.SetActive (true);
				Debug.Log ("isExiting");
				score.stopScore ();
				state = GameState.EXIT;
				Settings.gamestate = state;
				sceneFade.startSceneFade (1.1f);
			}
		}
               
        
		
	}

	public void CalibrateAccelerometer (GameObject readyPnl)
	{
		player.CalibrateAccelerometer ();
		Time.timeScale = 1.0f;
		score.startScore ();
		if (Gsettings.audioState () == 0) {
			audioControl.mute = true;
			music.isOn = false;
		} else if (Gsettings.audioState () == 1) {
			audioControl.mute = false;
			music.isOn = true;
		}
		readyPnl.SetActive (false);
		gameStarted = true;
	}

//	public void toggelAudio(){
//		if (audioCheck == 0 ) {
//			PlayerPrefs.SetInt("Audio",1);
//			audioControl.mute = false;
//			audioCheck = PlayerPrefs.GetInt("Audio");
//			PlayerPrefs.Save();
//		} else if (audioCheck == 1) {
//			PlayerPrefs.SetInt("Audio",0);
//			audioControl.mute = true;
//			audioCheck = PlayerPrefs.GetInt("Audio");
//			PlayerPrefs.Save();
//		}
//		
//	}

	public void MenuPress ()
	{
		pause (pauseMenu);		
	}

	public void NoPress ()
	{
		pause (pauseMenu);	
	}

	public void exitGame ()
	{
		score.stopScore ();
		state = GameState.EXIT;
		Settings.gamestate = state;
		audioControl.Stop ();
		PlayerPrefs.SetInt ("Audio", Gsettings.audioState ());
		PlayerPrefs.Save ();
		#if UNITY_EDITOR
            pause(pauseMenu);
            isExiting = true;
		#else		
		pause (pauseMenu);  
		isExiting = true;
		#endif
	}

	public void pause (GameObject pauseMenu)
	{
		if (!isExiting) {
			pauseMenu.SetActive (!pauseMenu.activeSelf);//checks if pause menu is active 
			//if so sets it inactive if not sets it active: Marcus 10/06/2015
			if (!panel_1.activeInHierarchy) {
				panel_2.SetActive (!panel_2.activeSelf);//toggle off /on
				panel_1.SetActive (!panel_1.activeSelf);
			}

			if (Time.timeScale >= 0.2f) {
				Time.timeScale = 0.0f;
				if (Gsettings.audioState () == 1) {
					audioControl.mute = true;
				}
				score.stopScore ();
			} else {
				if (timeIsSlowed) {
					Time.timeScale = 0.2f;
					score.startScore ();
					if (Gsettings.audioState () == 1) {
						audioControl.mute = false;
					}
				} else if (gameStarted == false) {
					Time.timeScale = 0.0f;
				} else {
					Time.timeScale = 1.0f;
					score.startScore ();
					if (Gsettings.audioState () == 1) {
						audioControl.mute = false;
					}
				}
                

			}
		}
		
	}

	public void timeSlowed ()
	{
		if (!timeIsSlowed) {
			timeIsSlowed = true;
			Time.timeScale = 0.2f;
			AccelScript.Speed = 200;

		} else {
			timeIsSlowed = false;
			Time.timeScale = 1.0f;
			AccelScript.Speed = 40;
		}
	}

	public void settings ()
	{
		panel_1.SetActive (!panel_1.activeSelf);
		panel_2.SetActive (!panel_2.activeSelf);
	}

	public void back_press ()
	{
		panel_1.SetActive (!panel_1.activeSelf);
		panel_2.SetActive (!panel_2.activeSelf);
	}

	public void touchCntrl ()
	{
		player.accelerometer = false;
		panel3.SetActive (false);
		touchFunction.touchOn = true;
		
	}

	public void accelCntrl ()
	{

		touchFunction.touchOn = false;
		player.accelerometer = true;
		panel3.SetActive (true);

		if (!accelBtn.isOn) {

		}
	}

	public void togglePcCntrl ()
	{
		player.togglePcCntrl ();
	}


}
