using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//For oculus
public class HandSphere : MonoBehaviour {

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
            //if click
            //set in Controller
        }
    }
}
