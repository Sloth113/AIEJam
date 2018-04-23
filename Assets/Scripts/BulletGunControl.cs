using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGunControl : MonoBehaviour, IGun {

    [SerializeField] private int m_bulletCount = 30;
    [SerializeField] private int m_magSize = 30;
    [SerializeField] private float m_fireRate = 5.0f; //rounds per second

    private float m_timer;

    [SerializeField] private GameObject m_bulletPrefab;
    [SerializeField] private Transform m_bulletSpawn;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(m_timer < m_fireRate)
        {
            m_timer += Time.deltaTime;
        }
	}
    public bool Reload()
    {
        m_bulletCount = m_magSize;
        return true;
    }
    public bool Fire()
    {
        if(m_timer >= m_fireRate && m_bulletCount > 0)
        {
            m_bulletCount--;
            m_timer = 0;
            Instantiate<GameObject>(m_bulletPrefab, m_bulletSpawn.position, m_bulletSpawn.rotation);
            return true;
        }
        return false;
    }

    public void LookAt(Vector3 pos)
    {
        transform.LookAt(pos);
    }
}
