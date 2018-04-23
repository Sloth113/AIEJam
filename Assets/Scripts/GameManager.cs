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
    struct SpawnInfo
    {
        [SerializeField] private GameObject spawn;
        [SerializeField] private float delay;
        [SerializeField] private float spawnRate;
        private float timer;
        [SerializeField] private float healthCondition;
    }

    private int m_spawnedEnemies = 0;
    private State m_currentState = State.menu;

    private float m_roundTimer;

    [SerializeField] SpawnInfo[] m_spawnInfo;

	// Use this for initialization
	void Start () {
	    	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
            GameOver();

        if(m_currentState == State.intro)
        {

        }
	}



    public void IntroOver()
    {

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
