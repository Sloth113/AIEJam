using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenVRController : MonoBehaviour {

    private SteamVR_TrackedObject m_trackedObj;

    private SteamVR_Controller.Device m_Controller
    {
        get { return SteamVR_Controller.Input((int)m_trackedObj.index); }
    }

    private void Awake()
    {
        m_trackedObj = GetComponent<SteamVR_TrackedObject>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Other stuff
	}
}
