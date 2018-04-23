using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

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
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = (transform.position + (target.position - transform.position).normalized * speed * Time.deltaTime);
		transform.LookAt (target.position);
		if (Vector3.Distance (transform.position, target.position) < minDis) {
			Node targetNode = target.GetComponent<Node> ();
			targetNode.CheckNextNode (GetComponent<AI>());
		}

	}

	public void setTarget(Transform newTarget)
	{
		target = newTarget;
	}

	public void KillPlayer()
	{
		print ("He Ded");
	}
	public void setHealth()
	{
		health--;
	}
}
