using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    enum State
    {
        intro,
        menu,
        inGame,
        pause
    }

    [System.Serializable]
    public struct SpawnInfo
    {
        [SerializeField] public GameObject spawn; //prefab
        [SerializeField] public float delay; //how long before it spawns
        [SerializeField] public float spawnRate; //between each spawn
        public float timer; //Its own counter
        [SerializeField] public float healthCondition; //if health is above this spawn
        [SerializeField] public GameObject spawnObject;
    }

    private int m_spawnedEnemies = 0;
    private State m_currentState = State.inGame;

    private float m_roundTimer;

    [SerializeField] SpawnInfo[] m_spawnInfo;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
            GameOver();

        switch (m_currentState)
        {
            case State.intro:

                break;
            case State.menu:

                break;
            case State.inGame:
                InGame();
                break;
            case State.pause:

                break;
        }
    }

    private void InGame()
    {
        //Spawn enemies
        m_roundTimer += Time.deltaTime;
        for(int i =0; i< m_spawnInfo.Length; i++)
        {
            if (m_roundTimer > m_spawnInfo[i].delay )// && m_spawnInfo[i].healthCondition > m_player.health)
            {
                if(m_spawnInfo[i].timer >= m_spawnInfo[i].spawnRate)
                {
                    //Instantiate<GameObject>(m_spawnInfo[i].spawn);
                    GameObject spawn = Instantiate<GameObject>(m_spawnInfo[i].spawn, m_spawnInfo[i].spawnObject.transform.position, m_spawnInfo[i].spawnObject.transform.rotation);
                    spawn.GetComponent<AI>().setTarget(m_spawnInfo[i].spawnObject.transform);
                   m_spawnInfo[i].timer = 0;
                }
                else
                {
                    m_spawnInfo[i].timer += Time.deltaTime;
                }
            }
        }

        //Update UI ?

    }

    public void IntroOver()
    {
        m_currentState = State.menu;
    }
    public void Pause()
    {
        m_currentState = State.pause;
    }

    public void Unpause()
    {
        m_currentState = State.inGame;
    }

    public void Play()
    {
        m_currentState = State.inGame;
    }

    public void GameOver()
    {
        m_currentState = State.menu;
    }


}
