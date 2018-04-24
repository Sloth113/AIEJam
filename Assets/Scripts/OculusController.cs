using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusController : MonoBehaviour {

    private OVRInput.Controller m_leftController = OVRInput.Controller.LTrackedRemote;
    private OVRInput.Controller m_rightController = OVRInput.Controller.RTrackedRemote;

    public GameObject m_leftHand;
    public GameObject m_rightHand;

    [SerializeField] private GameObject m_handle;
    [SerializeField] private GameObject m_gun;
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
        m_leftHand.transform.position = OVRInput.GetLocalControllerPosition(m_leftController);
        m_rightHand.transform.position = OVRInput.GetLocalControllerPosition(m_rightController);


        m_leftHand.transform.rotation = OVRInput.GetLocalControllerRotation(m_leftController);
        m_rightHand.transform.rotation = OVRInput.GetLocalControllerRotation(m_rightController);

        
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("InGun");
        if (other.name == "Handle")
        {
            if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
            {
                m_gun.GetComponent<IGun>().Fire();

            }
            if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) && OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
            {
                RaycastHit info;

                if (Physics.Raycast(m_leftHand.transform.position, -m_leftHand.transform.up, out info, 100))
                {
                    m_gun.GetComponent<IGun>().LookAt(info.point);
                }
            }
        }
    }
}
