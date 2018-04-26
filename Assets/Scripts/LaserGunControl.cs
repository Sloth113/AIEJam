using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGunControl : MonoBehaviour, IGun {

    [SerializeField] private float m_cooldown = 10;
    [Range(0,100)]
    [SerializeField] private float m_heatPerShot = 1;
    [SerializeField] private float m_heat;
    [SerializeField] private float m_coolDelay = 0.5f;
    [SerializeField] private float m_heatThreshold = 70f;
    private float m_heatTimer = 0;
    [Range(0, 0.1f)]
    [SerializeField] private float m_shotVariation = 0;

    [SerializeField] private float m_rateOfFire = 5;
    [SerializeField] private float m_timeBetweenShots;

    [SerializeField] private float m_currentROF;

    [SerializeField] private GameObject m_laser;
    private int m_lineCount = 10;
    private int m_lineIndex = 0;
    
    private ParticleSystem m_particles;

    private float m_timer;

    [SerializeField] private Transform m_barrelEnd;
    [SerializeField] private GameObject m_light;

    
    // Use this for initialization
    void Start()
    {
        m_timeBetweenShots = 1 / m_rateOfFire;
        m_currentROF = m_timeBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_timer < m_rateOfFire)
            m_timer += Time.deltaTime;

        RaycastHit info;
        if (Physics.Raycast(m_barrelEnd.position, m_barrelEnd.forward, out info, 100))
        {
            if (m_light != null)
                m_light.transform.position = info.point - ((info.point - m_barrelEnd.position).normalized * 0.1f) ;
        }


        if (m_heat > 0)
        {
            if (m_heatTimer > m_coolDelay)
            {
                m_heat -= m_cooldown * Time.deltaTime;
            }
            else
            {
                m_heatTimer += Time.deltaTime;
            }
            if(m_heat > m_heatThreshold)
            {
                m_currentROF = 1/ (m_rateOfFire - (m_rateOfFire * m_heat / 100));
            }
            else
            {
                m_currentROF = 1 / m_rateOfFire;
            }
        }
        else
        {
            m_heat = 0;
        }
    }

    public bool Fire()
    {
        Vector3 forward = m_barrelEnd.forward + m_barrelEnd.up * Random.Range(-m_shotVariation, m_shotVariation) + m_barrelEnd.right * Random.Range(-m_shotVariation, m_shotVariation);
        Debug.DrawRay(m_barrelEnd.position, forward * 50, Color.blue);
        m_heatTimer = 0;
        if (m_timer >= m_currentROF && m_heat + m_heatPerShot < 100)
        {
            m_timer = 0;
            Instantiate<GameObject>(m_laser, m_barrelEnd.position, m_barrelEnd.rotation);
            m_heat += m_heatPerShot;
            //Raycast
            RaycastHit info;
            if(Physics.Raycast(m_barrelEnd.position, m_barrelEnd.forward, out info, 100))
            {
                if(info.transform.tag == "Enemy")
                {
					info.transform.gameObject.GetComponent<AI> ().RemoveHealth ();
                }
            }
            //laser effect
            return true;
        }
        return false;
    }

    public void LookAt(Vector3 pos)
    {
        //Do constraints 
        transform.LookAt(pos);
    }

    public bool Reload()
    {
        return false;
    }

}
