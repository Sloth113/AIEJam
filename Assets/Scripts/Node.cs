using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

	public Node[] potentialNodes;
	public bool FinalNode;
	public bool ChangeSpeed;
	public float NewSpeed;
	public bool playSound;
	public AudioSource AS;
	// Use this for initialization
	public void CheckNextNode(AI enemy)
	{
		if (!FinalNode) {
			enemy.setTarget (potentialNodes[Random.Range(0, potentialNodes.Length)].transform);
		} else 
		{
			Debug.Log ("Node Triggering Damage = " + gameObject.name);
			enemy.KillPlayer ();
			Debug.Log ("Node Tripped by " + enemy.gameObject.name);
		}
		if (ChangeSpeed) 
		{
			enemy.SetSpeed (NewSpeed);
		}
		if (playSound) 
		{
			AS.Play ();
		}
	}
}
