using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Wave : MonoBehaviour {
    public static int enemiesalive = 0;

    public Transform spawnpoint;

    public Waveeee[] waves;

    public float wavetime = 5f;
    private float countdown = 2f;
    public Text countdowntext;
    private int wavenumber = 0;
    public GameManager gamemanager;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(enemiesalive>0)
        {
            return;
        }
        if (wavenumber == waves.Length&& enemiesalive==0)
        {
            gamemanager.YouWon();

        }
        if (countdown <=0f)
        {
            StartCoroutine(SpawnWave());
            countdown = wavetime;
            return;
        }
        countdown -= Time.deltaTime;
        countdown =Mathf.Clamp(countdown,0f,Mathf.Infinity);
        countdowntext.text = string.Format("{0:00.00}", countdown);
	}
    IEnumerator SpawnWave()
    {
        PlayerStats.round++;
        Waveeee wave = waves[wavenumber];
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f/wave.rate);
        }


         wavenumber++;

    }
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnpoint.position, spawnpoint.rotation);
        enemiesalive++;
    }
}
