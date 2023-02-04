using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    bool playerNearby;

    public GameObject projectilePrefab;

    public float attackCooldown;

    Transform playerTrans;

    public float health;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("Player nearby.");
            if(playerTrans == null)
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

    public void Attack(Vector3 playerPos)
    {
        if (!playerNearby) { return; }

        GameObject projectile = Instantiate(projectilePrefab);
        projectile.GetComponent<Projectile>().Fire(3f, playerPos);

        StartCoroutine(AttackWait());
    }

    IEnumerator AttackWait()
    {
        yield return new WaitForSeconds(attackCooldown);

        Attack(playerTrans.position);
    }

    public void Hit(float damage)
    {
        health -= damage;
    }

}
