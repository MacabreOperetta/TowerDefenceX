using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour {
    public Text roundstext;
	// Use this for initialization
	void OnEnable () {
        roundstext.text = PlayerStats.round.ToString();
	}
	
	// Update is called once per frame
	public void Retry () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
