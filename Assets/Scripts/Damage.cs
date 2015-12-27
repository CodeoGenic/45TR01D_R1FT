using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {
	
    //public PickUps pickups;// the script needs to be refrenced Marcus - 09/06/15
    // Andrew 8/6/2015
    public HealthScript health;// refrence health script Marcus - 15/06/2015
	private int asteroidDamage = 500;
	public Animator anim;
	void Awake(){
		//pickups = GetComponent<PickUps>();//this is how you refrence the script Marcus - 09/06/15
		health = GetComponent<HealthScript>();
	}
	void OnTriggerEnter(Collider item)
	{
		if (item.tag == "Asteroid") // if the gameobject name is _astriod//using tags is better marcus-15/06/2015
		{
			anim.SetBool("Idel",false);
			anim.SetTrigger("Impact");//set of the Impact anim on collision with asteroid - marcus - 15/06/2015
			//doDamage();
			health.ApplyDamage(asteroidDamage);
			Invoke("startAnimation",1.5f);
		 
           // Debug.Log(health.GetHealth);

			if ( health.GetHealth() <= 0)// if the health is 0
			{
				Debug.Log("Game Over");

			}

	    }

		//Had to comment this section out has it dose nothing at the moment are you working on this 
		// cause at the moment there is no health variable to refrence 
		// I changed all the PickUps variables to pickups to match the varible I created -Marcus: 09/06/15 
	}
	void startAnimation(){
		anim.SetBool ("Idel", true);		
	}
	}


	
	
