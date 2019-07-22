using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static bool GameIsOver;
    public GameObject gameoverUI;
    public GameObject youwonuı;
    // Use this for initialization
    void Start () {
        GameIsOver = false;
        Time.timeScale = 1;
    }
	
	// Update is called once per frame
	void Update () {
        if (GameIsOver)
            return;

		if(PlayerStats.lives <=0)
        {
            EndGame();
        }
	}
    void EndGame()
    {
        GameIsOver = true;
        gameoverUI.SetActive(true);
    }
    public void YouWon()
    {
        GameIsOver = true;
        youwonuı.SetActive(true);
        Time.timeScale = 0;
    }
}
