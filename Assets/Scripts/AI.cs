using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

	PlayerHealthTemperaryScript PHTC;
	public int health;
	public Transform target;
	public float minDis;
	float speed;
	public float minSpeed;
	public float maxSpeed;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		speed = Random.Range (minSpeed, maxSpeed + 1);
		PHTC = FindObjectOfType<PlayerHealthTemperaryScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = (transform.position + (target.position - transform.position).normalized * speed * Time.deltaTime);
		transform.LookAt (target.position);
		if (Vector3.Distance (transform.position, target.position) < minDis) {
			Node targetNode = target.GetComponent<Node> ();
			targetNode.CheckNextNode (GetComponent<AI>());
		}
		if (health <= 0) 
		{
			OnDeath ();
		}

	}

	public void setTarget(Transform newTarget)
	{
		target = newTarget;
	}

	public void KillPlayer()
	{
		PHTC.CheckHealth ();
		Destroy (gameObject);
	}
	public void RemoveHealth()
	{
		health --;
	}
	public void OnDeath()
	{
		Destroy (gameObject);
	}
}
