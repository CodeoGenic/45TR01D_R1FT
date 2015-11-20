using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Timers;

public class ScoreV3 : MonoBehaviour {
	int oldDistance;
	int score;
	int distance;
	int divisible;
	Timer time;
	public Text dis;
	HealthScript health;
	
	void Awake () {
		oldDistance = PlayerPrefs.GetInt ("Player_Distance");
		score = 0;
		distance = 0;
		divisible = 0;
		time = new Timer ();
		time.Elapsed += new ElapsedEventHandler (OnTimedEvent); // Calls the OnTimedEvent method based on the time interval.
		time.Interval = 1000; // Change interval between score ticks. Currently set at 5 seconds.
		time.Start (); // Starts the timer.
		health = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthScript> ();
	}

	public void Update()
	{
		dis.text = "km: "+getDistance().ToString (); // Changes the Text UI object. Gets the distance and converts it to string.

		if (divisible != (distance / 10000))
		{
			health.AddHealth(500);
		}

		//Debug.Log (divisible + " " + score / 10000);

		//Debug.Log (distance / 10000);

		divisible = distance / 10000;
	}

	/**
	 * Set the score.
	 */
	public void setScore(int s)
	{
		score = s;
	}

	/**
	 * Get the score.
	 */
	public int getScore()
	{
		return score;
	}

	/**
	 * Set the distance.
	 */
	public void setDistance(int d)
	{
		distance = d;
	}

	/**
	 * Gets the distance.
	 */
	public int getDistance()
	{
		return distance;
	}

	public int getOldDistance()
	{
		return oldDistance;
	}

	/**
	 * Stops the timer thus stopping the score from increasing.
	 */
	public void stopScore()
	{
		time.Stop ();

	}
	public void startScore()
	{
		time.Start();
		
	}

	/**
	 * Increases the score and distance based on the time interval.
	 */
	void OnTimedEvent(object source, ElapsedEventArgs e)
	{
		setScore(getScore() + 1);
		setDistance (getDistance() + 80);

		//Debug.Log (score);
		//Debug.Log (distance);
	}
}
