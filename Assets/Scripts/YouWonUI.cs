using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouWonUI : MonoBehaviour {
    public static bool youwon;
    public GameObject youwonuı;
	// Use this for initialization
	void Start () {
        youwon = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (youwon)
            return;
        }
    void YouWon()
    {
        youwon = true;
        youwonuı.SetActive(true);
    }
}
