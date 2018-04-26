using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthTemperaryScript : MonoBehaviour {
	public int playerHealth;
	public Text healthDisplay;

	public void CheckHealth()
	{
		playerHealth -= 1;
		healthDisplay.text = ("LIFE: " + playerHealth);
		if (playerHealth <= 0) 
		{
			OnDeath ();
		}
	}
	void OnDeath()
	{
		healthDisplay.text = ("LIFE: DEAD");
	}
}
