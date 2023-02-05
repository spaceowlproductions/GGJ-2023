using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public bool playerNearby;

    public GameObject projectilePrefab;

    public float attackCooldown;

    Transform playerTrans;

    public float health;

    public AudioSource audioSource;

    public float throwVelocity;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player nearby.");
            if (playerTrans == null)
                playerTrans = collision.transform;

            playerNearby = true;
            Attack(playerTrans.position);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Player left.");
            playerNearby = false;
        }
    }

    public virtual void Attack(Vector3 playerPos)
    {
        if (!playerNearby) { return; }

        GameObject projectile = Instantiate(projectilePrefab);
        projectile.transform.position = transform.position;
        projectile.GetComponent<Projectile>().Fire(throwVelocity, playerPos);

        StartCoroutine(AttackWait());

        audioSource.clip = AudioController.attackClips[Random.Range(0, AudioController.attackClips.Length)];
        audioSource.Play();
    }

    public IEnumerator AttackWait()
    {
        yield return new WaitForSeconds(attackCooldown);

        Attack(playerTrans.position);
    }

    public void Hit(float damage)
    {
        health -= damage;
    }

}
