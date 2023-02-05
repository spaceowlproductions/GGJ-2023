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

    public AudioSource audioSource;

    public float damage;

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
                collision.transform.parent.GetComponent<AudioSource>().PlayOneShot(AudioController.deathClips[Random.Range(0, AudioController.deathClips.Length)], audioSource.volume);
                Die();
            }
            else
            {
                audioSource.PlayOneShot(AudioController.hitClips[Random.Range(0, AudioController.hitClips.Length)]);
            }

            uiAnim.SetBool("Open", true);

            if (healthUITimeout != null)
                StopCoroutine(healthUITimeout);

            healthUITimeout = StartCoroutine(HealthUITimeout());

            healthBar.fillAmount = health / fullHealth;

        }

        if (collision.tag == "PlayerHealth")
        {
            collision.gameObject.GetComponent<PlayerStatusController>().Hit(damage);
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
