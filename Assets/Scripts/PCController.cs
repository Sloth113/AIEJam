using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCController : MonoBehaviour {

    [SerializeField] private GameObject m_gun;
    private IGun m_gunScript;
	public AudioSource gunSoundSource;
	public AudioClip gunSoundClip;
    // Use this for initialization
    void Start () {
		if(m_gun != null)
        {
            m_gunScript = m_gun.GetComponent<IGun>();
        }
		gunSoundSource.clip = gunSoundClip;
		gunSoundSource.playOnAwake = false;
		gunSoundSource.loop = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Mouse0)) 
		{
			//startAudio
			gunSoundSource.Play();
		}
		if (Input.GetKey(KeyCode.Mouse0))
        {
			
            m_gunScript.Fire();
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
            m_gunScript.LookAt(hitInfo.point);
		if (Input.GetKeyUp(KeyCode.Mouse0)) 
		{
			gunSoundSource.Pause ();
			//stop audio
		}
    }
}
