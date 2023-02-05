using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusController : MonoBehaviour
{
    public float health;
    float fullHealth;

    public RootHub currentHub;

    public Animator uiAnim;

    Coroutine healthUITimeout;
    public Image healthBar;

    void Awake()
    {
        fullHealth = health;
    }

    public void Hit(float damage)
    {
        health -= damage;
        if (currentHub != null)
            currentHub.StopHealingProcess();

        uiAnim.SetBool("Open", true);

        if(healthUITimeout != null)
            StopCoroutine(healthUITimeout);

        healthUITimeout = StartCoroutine(HealthUITimeout());

        healthBar.fillAmount = health / fullHealth;
    }

    public void Heal()
    {
        uiAnim.SetBool("Open", true);

        if (healthUITimeout != null)
            StopCoroutine(healthUITimeout);

        healthUITimeout = StartCoroutine(HealthUITimeout());

        StartCoroutine(HealAnim());
    }

    IEnumerator HealAnim()
    {
        float elapsedTime = 0f;
        float timer = 5f;

        float originalHealth = health;

        while(elapsedTime < timer)
        {
            elapsedTime += Time.deltaTime;
            health = Mathf.Lerp(originalHealth, fullHealth, elapsedTime / timer);
            healthBar.fillAmount = health;
            yield return null;
        }
    }

    IEnumerator HealthUITimeout()
    {
        yield return new WaitForSeconds(5);

        uiAnim.SetBool("Open", false);
    }
}
