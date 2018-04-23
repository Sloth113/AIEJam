using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusController : MonoBehaviour {

    private OVRInput.Controller m_leftController = OVRInput.Controller.LTrackedRemote;
    private OVRInput.Controller m_rightController = OVRInput.Controller.RTrackedRemote;

    public GameObject m_leftHand;
    public GameObject m_rightHand;

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
        m_leftHand.transform.position = OVRInput.GetLocalControllerPosition(m_leftController);
        m_rightHand.transform.position = OVRInput.GetLocalControllerPosition(m_rightController);
    }
}
