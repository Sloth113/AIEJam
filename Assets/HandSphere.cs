using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//For oculus
public class HandSphere : MonoBehaviour {
	public bool inTrigger = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.name == "Handle")
        {
			inTrigger = true;
        }
    }
	private void OnTriggerExit(Collider other){
		inTrigger = false;
	}
}
