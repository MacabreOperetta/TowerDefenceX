using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    private Transform target;
    private Enemy targetenemy;
    [Header("General")]
    public float range = 15f;
    [Header("Bullets")]
    public float firerate = 1f;
    private float firecountdown = 0f;
    public GameObject bulletprefab;
    [Header("Laser")]
    public int damageovertime = 30;
    public float slowpercent = .5f;
    public bool uselaser = false;
    public LineRenderer line;
    public ParticleSystem impacteffect;
    public Light impactlight;

    [Header("Unity Setup Fields")]

    public string enemytag = "Enemy";
    public Transform parttorotate;
    public float turnspeed = 10f;


    public Transform firepoint;

	// Use this for initialization
	void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}
	
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemytag);
        float shortestdistance = Mathf.Infinity;
        GameObject nearestenemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distancetoenemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distancetoenemy<shortestdistance)
            {
                shortestdistance = distancetoenemy;
                nearestenemy = enemy;
            }
        }

        if(nearestenemy !=null && shortestdistance<=range)
        {
            target = nearestenemy.transform;
            targetenemy = nearestenemy.GetComponent<Enemy>();
        }
        else
        { target = null; }
    }
	// Update is called once per frame
	void Update () {
        if (target == null)
        {
            if(uselaser)
            {
                if (line.enabled)
                {

                    line.enabled = false;
                    impacteffect.Stop();
                    impactlight.enabled = false;
                }

            }
            return;
        }
        LockOnTarget();

        if(uselaser)
        {
            Laser();
        }
        else
        {
            if (firecountdown <= 0)
            {
                Shoot();
                firecountdown = 1f / firerate;
            }
            firecountdown -= Time.deltaTime;
        }


	}
    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookrotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(parttorotate.rotation, lookrotation, Time.deltaTime * turnspeed).eulerAngles;
        parttorotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
    void Laser()
    {
        targetenemy.GetComponent<Enemy>().TakeDamage(damageovertime * Time.deltaTime);
        targetenemy.Slow(slowpercent);
        if (!line.enabled)
        {
            line.enabled = true;
            impacteffect.Play();
            impactlight.enabled = true;
        }

        line.SetPosition(0, firepoint.position);
        line.SetPosition(1, target.position);

        Vector3 dir = firepoint.position - target.position;

        impacteffect.transform.position = target.position + dir.normalized;

        impacteffect.transform.rotation = Quaternion.LookRotation(dir);

    }
    void Shoot()
    {
        GameObject bulletGo= Instantiate(bulletprefab, firepoint.position, firepoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if(bullet !=null)
        {
            bullet.Chase(target);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,range);
    }
}
