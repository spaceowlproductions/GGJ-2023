using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public Rigidbody2D rb2D;

    public float damage;

    public float lifeTime;

    public AudioSource audioSource;

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0)
            Destroy(gameObject);
    }

    public void Fire(float speed, Vector3 target)
    {
        rb2D.velocity = (target - transform.position) * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerHealth")
        {
            collision.gameObject.GetComponent<PlayerStatusController>().Hit(damage);
            Destroy(gameObject);
        }

        if(collision.tag == "Weapon")
        {
            Parry();
        }
    }

    public void Parry()
    {
        BulletHit();
    }

    public void BulletHit()
    {
        audioSource.clip = AudioController.deathClips[Random.Range(0, AudioController.deathClips.Length)];
        audioSource.Play();

        Destroy(gameObject);
    }
}
