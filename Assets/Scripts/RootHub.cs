using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RootHub : MonoBehaviour
{
    public bool infected = true;

    public bool healed;

    public float healHoldTimer;

    bool playerNear;

    Coroutine healRoutine;

    PlayerStatusController playerStatusController;

    public Animator uiAnim;
    public Image infectionHealBar;

    public Animator healUIAnim;

    public GameStateController gameController;


    void Update()
    {
        if(playerNear)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if (infected)
                    healRoutine = StartCoroutine(HealRootSequence());
                else if(!healed)
                    playerStatusController.Heal();
            }

            if (Input.GetKeyUp(KeyCode.E))
            {
                if(infected)
                {
                    StopHealingProcess();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerNear = true;

            if (playerStatusController == null)
                playerStatusController = collision.GetComponentInChildren<PlayerStatusController>();

            playerStatusController.currentHub = this;

            if(infected)
                uiAnim.SetBool("Open", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerNear = false;
            collision.GetComponent<PlayerStatusController>().currentHub = null;

            if(infected)
                uiAnim.SetBool("Open", false);
        }
    }

    public void StopHealingProcess()
    {
        healUIAnim.SetBool("Healing", false);

        if (healRoutine != null)
            StopCoroutine(healRoutine);

        infectionHealBar.fillAmount = 1f;
    }

    void RootHealingFinished()
    {
        infected = false;

        healUIAnim.SetBool("Healing", false);
        uiAnim.SetBool("Open", false);
        uiAnim.SetBool("PlayerHeal", true);

        gameController.lastSaveSpot = transform;
    }

    IEnumerator HealRootSequence()
    {
        healUIAnim.SetBool("Healing", true);
        float elapsedTime = 0f;

        while(elapsedTime < healHoldTimer)
        {
            elapsedTime += Time.deltaTime;

            infectionHealBar.fillAmount = 1 - (elapsedTime / healHoldTimer);

            yield return null;
        }

        RootHealingFinished();

        yield break;
    }

}
