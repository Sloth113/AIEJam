using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusController : MonoBehaviour {

    private OVRInput.Controller m_leftController = OVRInput.Controller.LTrackedRemote;
    private OVRInput.Controller m_rightController = OVRInput.Controller.RTrackedRemote;

    public GameObject m_leftHand;
    public GameObject m_rightHand;

    [SerializeField] private GameObject m_handle;
    [SerializeField] private GameObject m_gun; // pivot point
    [SerializeField] private bool m_trigger;
    // Use this for initialization
    void Start()
    {
        if (m_leftHand == null || m_rightHand == null)
        {
            //Set new 
        }
    }

    // Update is called once per frame
    void Update()
    {
        m_leftHand.transform.localPosition = OVRInput.GetLocalControllerPosition(m_leftController);
        m_rightHand.transform.localPosition = OVRInput.GetLocalControllerPosition(m_rightController);


        m_leftHand.transform.localRotation = OVRInput.GetLocalControllerRotation(m_leftController);
        m_rightHand.transform.localRotation = OVRInput.GetLocalControllerRotation(m_rightController);

		if (m_leftHand.GetComponent<HandSphere> ().inTrigger && m_rightHand.GetComponent<HandSphere>().inTrigger) {
			if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
			{
				m_gun.GetComponent<IGun>().Fire();

			}
			if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) && OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
			{
				RaycastHit info;
				Debug.DrawRay (m_leftHand.transform.position, (m_gun.transform.position - m_leftHand.transform.position) * 100, Color.red);
				if (Physics.Raycast(m_leftHand.transform.position, (m_gun.transform.position - m_leftHand.transform.position), out info, 100))
				{
					m_gun.transform.LookAt (info.point);
				}
			}
		}
        
    }
}
