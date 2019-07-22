using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	public void Play () {
        SceneManager.LoadScene("Main Scene");
	}
	
	// Update is called once per frame
	public void Quit () {
        Debug.Log("Quit");
        Application.Quit();
    }
}
