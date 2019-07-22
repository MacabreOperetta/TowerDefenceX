using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
    public float startspeed = 10f;
    [HideInInspector]
    public float speed;

    public float starthealth = 100;
    private float health;
    public int value = 50;

    public GameObject deatheffect;
    public Image healthbar;
    // Use this for initialization

    private void Start()
    {
        speed = startspeed;
        health = starthealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthbar.fillAmount = health/starthealth;
        if(health<=0)
        {
            Die();
        }
    }
    public void Slow(float percent)
    {
        speed = startspeed*(1f - percent);
    }
    void Die()
    {
        PlayerStats.money += value;
        GameObject effect= Instantiate(deatheffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Wave.enemiesalive--;
        Destroy(gameObject);
    }
	// Update is called once per frame

}
