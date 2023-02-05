using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHealth : MonoBehaviour
{
    public float health;
    float fullHealth;

    public float hitDamage;

    public Animator uiAnim;

    Coroutine healthUITimeout;
    public Image healthBar;

    private void Awake()
    {
        fullHealth = health;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Weapon")
        {
            health -= hitDamage;
            Debug.Log("Hit");

            if (health <= 0)
            {
                Die();
            }

            uiAnim.SetBool("Open", true);

            if (healthUITimeout != null)
                StopCoroutine(healthUITimeout);

            healthUITimeout = StartCoroutine(HealthUITimeout());

            healthBar.fillAmount = health / fullHealth;

        }
    }

    public void Die()
    {
        Destroy(transform.parent.gameObject);
    }

    IEnumerator HealthUITimeout()
    {
        yield return new WaitForSeconds(5);

        uiAnim.SetBool("Open", false);
    }

}
