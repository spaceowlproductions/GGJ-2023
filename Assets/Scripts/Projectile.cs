using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public Rigidbody2D rb2D;

    public float damage;

    public float lifeTime;

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0)
            Destroy(gameObject);
    }

    public void Fire(float speed, Vector3 target)
    {
        rb2D.velocity = (target - transform.position) * 3;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerStatusController>().Hit(damage);
            Destroy(gameObject);
        }
    }
}
