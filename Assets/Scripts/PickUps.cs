using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PickUps : MonoBehaviour {
	
	public int coins; // initialise coin pickup. Andrew 5:19pm 4.6.2015.
	public int bullets; // initalise bullets
	public float health;
	public  float shield;
	private int currentShield;
	private int currentHealth;
	public Slider  shieldSlider;
	public int spawn;
	
	public HealthScript healthScript;
	
	
	void Awake()
	{
		coins = 0;
		bullets = 0;		
		shield = 0;
        healthScript = GetComponent<HealthScript>();
        health = Settings.health;
        shieldSlider.value = shield;		
	}
	
	void Update()
	{
		
	}
	
	void OnTriggerEnter(Collider item)
	{ 
			
		switch (item.gameObject.tag)
		{
		case "coins": // if coin is picked up
			coins++; // add 100 to the score.
			Debug.Log ("Coins "+coins);
			break;
			
		case "bullets": // if bullet is picked up
			bullets += 1; // add 1 to the bullet variable.
			Debug.Log ("Builets "+ bullets); 
			break;
			
		case "health": // if file is named health
			//health += 10; 
			//healthScript.AddHealth(100);// add 10 to health
            Debug.Log("health before: "+health);
			lifeChange(); // call lifeChange method
			Debug.Log ("Health "+health);
			item.gameObject.SetActive(false);
			break;
			
		case "shield":
			shield += 1000;
			Debug.Log ("Shield "+shield);
			item.gameObject.SetActive(false);
			break;

		}
		//once the ship has collected the item remove the item. 
		
	}
	
	void lifeChange()
	{
		
		if (health <= 10000)  // if health is less than or equal to 10000 
		{
			healthScript.AddHealth(200); // health is set to 10000.
		     
		}
		if (health <= 0)
		{ 
			Debug.Log ("Game Over");
		}
		if (shield >= 100) {
			//shield = 100;
		}
	}
	
	public void healthChange()
	{
        
		if (shield > 1) 
		{
			shieldDamage(100);
            Debug.Log("shield damage");
		}
		
		else if (health > 0) 
		{
			healthScript.ApplyDamage(500);
            Debug.Log("health damage");
            
		}
	}

	public void shieldDamage(int shieldDamage)
	{
	 Settings.shield = shield -= shieldDamage;
	
	}

	 void spawnItems()
	{

		for (int i = 0; i < 10; i++)
		{
         
		}
	}

	
	//	public void setShield(float shield)
	//	{
	//		this.shield = shield;
	//	}
	//
	//	public void setHealth(float health)
	//	{
	//		this.health = health;
	//	}
	//
	//	public float getShield()
	//	{
	//		return shield;
	//	}
	//	
	//	public float getHealth()
	//	{
	//		return health;
	//	}
}



