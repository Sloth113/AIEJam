using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    enum State
    {
        menu,
        inGame,
        pause
    }

    private State m_currentState = State.menu;
    



	// Use this for initialization
	void Start () {
	    	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
            GameOver();

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
