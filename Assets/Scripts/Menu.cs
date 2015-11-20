using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Threading;

public class Menu : MonoBehaviour {
	
	public GameObject mainPanel;
	public Button play;
	public Button exit;
	public AudioSource audioControl;
	public Text distance;
    public Text shipName;
	public Toggle music;
    public Toggle sound;
    public GameObject leaderPanel;
    public GameObject containerLeft;
    public GameObject containerRight;
    public GameObject leaderListview;
    public GameObject inputScoreview;
    public ListAdapter leaderBoard;
	public Settings Gsettings;
   

	void Start () {
        if(leaderPanel.activeSelf)
            leaderPanel.SetActive(false);

//		if (Settings.musicOn == false) {
//			audioControl.mute = true;
//            music.isOn = false;
//		} else {
//			audioControl.mute = false;
//            music.isOn = true;
//		}

		if (Gsettings.audioState() == 0 ) {
			audioControl.mute = true;
			music.isOn = false;
		} else if (Gsettings.audioState() == 1) {
			audioControl.mute = false;
			music.isOn = true;
		}


		distance.text = PlayerPrefs.GetInt("Player_Distance").ToString();

		//mainPanel = mainPanel.GetComponent<Canvas>();
		play = play.GetComponent<Button>();
		exit = exit.GetComponent<Button>();
		if (mainPanel.activeSelf) {
			mainPanel.SetActive(false);
		}

	}
	
	// Update is called once per frame
	void Update () {
       
		
	}
	public void ExitPress(){
		mainPanel.SetActive(true);
		play.enabled = false;
		exit.enabled = false;
		
	}
	public void NoPress(){
		mainPanel.SetActive(false);
		play.enabled = true;
		exit.enabled = true;
	}

	public void startGame(){
		//Application.LoadLevel (1);
		Application.LoadLevel(2);
	}
    public void goToStore()
    {
        //Application.LoadLevel (1);
        Application.LoadLevel(3);
    }




	public void toggelAudio(){
        Debug.Log("toggelAudio");

        if (Gsettings.audioState() == 0)
        {
            Debug.Log("audio is mute");
            audioControl.mute = false;
            music.isOn = true;
        }
        else if (Gsettings.audioState() == 1)
        {
            Debug.Log("audio is on");
            audioControl.mute = true;
            music.isOn = false;
        }
	}
   
    public void toggleSound()
    {
        mainPanel.SetActive(true);
        play.enabled = false;
        exit.enabled = false;

    }

    public void toggleLeaderBoard()
    {
        leaderPanel.SetActive(!leaderPanel.activeSelf);
        inputScoreview.SetActive(false);
        leaderListview.SetActive(true);

        //if (leaderPanel.activeSelf)
       // {
            containerLeft.SetActive(!containerLeft.activeSelf);
            containerRight.SetActive(!containerRight.activeSelf);
       // }
    }
   

	public void exitGame(){

       if(audioControl.isPlaying)
            audioControl.Stop();

       #if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
       #else 		
	    Application.Quit ();    
       #endif

	

	}
    public void switchLeaderBoardView()
    {
        if (!inputScoreview.activeSelf)
        {

            leaderListview.SetActive(!leaderListview.activeSelf);
            inputScoreview.SetActive(!inputScoreview.activeSelf);
            return;
        }
        else
        {
            if(leaderBoard.AddNewHighscore())
                StartCoroutine("WaitForComplete");
        }
       

        
    }
    public IEnumerator WaitForComplete()
    {
        while (!leaderBoard.isUploadDone)
        {

          yield return null;
        }
        leaderListview.SetActive(!leaderListview.activeSelf);
        inputScoreview.SetActive(!inputScoreview.activeSelf);
           
    }
   

}
