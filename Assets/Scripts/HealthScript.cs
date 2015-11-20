using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthScript : MonoBehaviour {

	private int health;

    public Slider h;



	void Awake () {

		health = 10000;
        Settings.health = health;
	}

	void Update () {
		
		h.value = health; // Inscreases and decreases the slider based on the health.
        
	}

	/**
	 * Decreases the health by the value passed.
	 */
	public void ApplyDamage(int d)
	{
		Settings.health = health -= d;

	}

	/**
	 * Increases the health by the value passed.
	 */
	public void AddHealth(int b)
	{
        if (health <= 10000)
        {
            health += b;
            Debug.Log("Health gained. Health is now: " + health);
        }
	}

	/**
	 * Gets the health.
	 */
	public int GetHealth()
	{
		return health;
	}
}
