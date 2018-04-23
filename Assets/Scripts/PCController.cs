using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCController : MonoBehaviour {

    [SerializeField] private GameObject m_gun;
    private IGun m_gunScript;
    // Use this for initialization
    void Start () {
		if(m_gun != null)
        {
            m_gunScript = m_gun.GetComponent<IGun>();
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            m_gunScript.Fire();
        }
    }
}
