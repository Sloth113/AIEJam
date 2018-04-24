using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenVRController : MonoBehaviour {

    private SteamVR_TrackedObject m_trackedObj;
    [SerializeField] private GameObject m_handle;
    [SerializeField] private GameObject m_gun;
    [SerializeField] private OpenVRController m_otherHnad;
    [SerializeField] private bool m_trigger;
    

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

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Handle")
        {
            if (m_Controller.GetHairTriggerDown())
            {
                RaycastHit info;

                if (Physics.Raycast(m_trackedObj.transform.position, m_trackedObj.transform.forward, out info, 100))
                {
                    m_gun.GetComponent<IGun>().LookAt(info.point);
                }
                if (m_trigger)
                {
                    m_gun.GetComponent<IGun>().Fire();
                }
            }
        }
    }
}
