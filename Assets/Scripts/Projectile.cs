using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    [SerializeField] private float m_speed = 50;
    [SerializeField] private float m_life = 2;
    [SerializeField] private float m_spawnTime;
    // Use this for initialization
    void Start () {
        m_spawnTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * m_speed * Time.deltaTime;
        if(Time.time - m_spawnTime > m_life)
        {
            Destroy(this.gameObject);
        }
	}
    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
