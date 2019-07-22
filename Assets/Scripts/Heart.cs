using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour {
    public GameObject heart;
    public int number;

	// Update is called once per frame
	void Update () {
        if (number > PlayerStats.lives)
            heart.SetActive(false);
    }
}
