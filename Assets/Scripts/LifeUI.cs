using UnityEngine;
using UnityEngine.UI;

public class LifeUI : MonoBehaviour {
    public Text lifetext;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        lifetext.text = PlayerStats.lives.ToString();
	}
}
