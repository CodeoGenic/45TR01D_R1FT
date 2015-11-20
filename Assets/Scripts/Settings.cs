using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class Settings : MonoBehaviour {

	public static float speedUP = 1.8f;
	public static int speedX2 = 2;
	public static int speedX3 = 5;
	public static int Level = 0;
	public static int speed_level = 0;
	public static float health = 10000;
	public static float shield = 4;
    public static GameState gamestate;
    public static bool musicOn;
    public static bool soundOn;
	public AudioSource audioControl;
	public AudioSource soundControl;
	int audioCheck;
	int soundCheck;
	// Use this for initialization
	void Awake () {
		Level = 0;
        if (!PlayerPrefs.HasKey ("firsttime")) {            
			PlayerPrefs.SetInt ("firsttime", 0);
			PlayerPrefs.SetInt ("ship", 0);
			PlayerPrefs.Save ();
		}
		if(!PlayerPrefs.HasKey("Audio")){
			PlayerPrefs.SetInt("Audio", 1);
			PlayerPrefs.Save();
		}
        if (!PlayerPrefs.HasKey("sound"))
        {
            PlayerPrefs.SetInt("sound", 0);
            PlayerPrefs.Save();
        }
		audioCheck = PlayerPrefs.GetInt ("Audio");
		soundCheck = PlayerPrefs.GetInt ("sound");
	}
	
	// Update is called once per frame
	void Update () {
//		if (PlayerPrefs.GetInt ("Audio") == 1) {            
//			musicOn = true;
//		} else {
//			musicOn = false;
//		}
//
//
//        if (PlayerPrefs.GetInt("sound") == 1)
//        {
//            soundOn = true;
//        }
//        else
//        {
//            soundOn = false;
//        }
	}

	public int audioState(){
		audioCheck = PlayerPrefs.GetInt("Audio");
		return audioCheck;
	}

	public int soundState(){
		soundCheck = PlayerPrefs.GetInt("sound");
		return soundCheck;
	}

	public void toggelAudio(){
		audioCheck = PlayerPrefs.GetInt("Audio");
		if (audioCheck == 0 ) {
			PlayerPrefs.SetInt("Audio",1);
			audioControl.mute = false;
			audioCheck = PlayerPrefs.GetInt("Audio");
			PlayerPrefs.Save();
		} else if (audioCheck == 1) {
			PlayerPrefs.SetInt("Audio",0);
			audioControl.mute = true;
			audioCheck = PlayerPrefs.GetInt("Audio");
			PlayerPrefs.Save();
		}
		
	}

	public void toggelSound(){
		soundCheck = PlayerPrefs.GetInt("sound");
		if (soundCheck == 0 ) {
			PlayerPrefs.SetInt("sound",1);
			soundControl.mute = false;
			soundCheck = PlayerPrefs.GetInt("sound");
			PlayerPrefs.Save();
		} else if (soundCheck == 1) {
			PlayerPrefs.SetInt("sound",0);
			soundControl.mute = true;
			soundCheck = PlayerPrefs.GetInt("sound");
			PlayerPrefs.Save();
		}
		
	}


}
