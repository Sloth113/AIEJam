using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGunControl : MonoBehaviour, IGun {

    [SerializeField] private float m_cooldown;
    [SerializeField] private float m_heatPerShot;
    [SerializeField] private float m_heat;
    [Range(0, 0.1f)]
    [SerializeField] private float m_shotVariation = 0;
    [SerializeField] private float m_rateOfFire = 5;

    private LineRenderer m_lineRednder;
    private GameObject[] m_lineObjects;
    private int m_lineCount = 10;
    private int m_lineIndex = 0;
    
    private ParticleSystem m_particles;

    private float m_timer;

    [SerializeField] private Transform m_barrelEnd;

    
    // Use this for initialization
    void Start()
    {
        m_lineObjects = new GameObject[m_lineCount];
        foreach(GameObject objs in m_lineObjects)
        {
        //    objs.AddComponent<LineRenderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(m_timer < m_rateOfFire)
            m_timer += Time.deltaTime;
    }

    public bool Fire()
    {
        Vector3 forward = m_barrelEnd.forward + m_barrelEnd.up * Random.Range(-m_shotVariation, m_shotVariation) + m_barrelEnd.right * Random.Range(-m_shotVariation, m_shotVariation);
        Debug.DrawRay(m_barrelEnd.position, forward * 50, Color.blue);
        if (m_timer >= m_rateOfFire)
        {
            //Raycast
            RaycastHit info;
            if(Physics.Raycast(m_barrelEnd.position, m_barrelEnd.forward, out info, 100))
            {

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
