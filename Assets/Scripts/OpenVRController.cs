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
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("InGun");
        if(other.name == "Handle")
        {
            if (m_Controller.GetHairTrigger())
            {
                    m_gun.GetComponent<IGun>().Fire();
             
            }
            if (m_Controller.GetPress(SteamVR_Controller.ButtonMask.Grip))
            {
                RaycastHit info;

                if (Physics.Raycast(m_trackedObj.transform.position, -m_trackedObj.transform.up, out info, 100))
                {
                    m_gun.GetComponent<IGun>().LookAt(info.point);
                }
            }
        }
    }
}
