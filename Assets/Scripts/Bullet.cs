using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;
    public float speed = 70f;
    public int damage = 50;
    public float explotionrad = 0f;
    public GameObject impacteffect;

    public void Chase(Transform _target)
    {
        target = _target;

    }
	// Update is called once per frame
	void Update () {
		if(target== null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distanceThisframe = speed * Time.deltaTime;

        if(dir.magnitude <=distanceThisframe)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisframe, Space.World);
        transform.LookAt(target);
	}
    void HitTarget()
    {
        GameObject effect = Instantiate(impacteffect, transform.position, transform.rotation);
        Destroy(effect, 5f);

        if(explotionrad>0f)
        {
            Explode();
        }else
        {
            Damage(target);
        }


        Destroy(gameObject);
    }
    void Explode()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, explotionrad);
        foreach(Collider collider in cols)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        if(e!=null)
        {
            e.TakeDamage(damage);
        }
    }
}
