using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateController : MonoBehaviour
{
    public Transform lastSaveSpot;

    public GameObject deathScreen;
    public static GameObject DeathScreen;

    public GameObject winScreen;
    public static GameObject WinScreen;

    // Start is called before the first frame update
    void Awake()
    {
        DeathScreen = deathScreen;
        WinScreen = winScreen;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void ActivateDeathScreen()
    {
        DeathScreen.SetActive(true);
    }

    public static void ActivateWinScreen()
    {
        WinScreen.SetActive(true);
    }


    public void Restart(PlayerStatusController player)
    {
        if (lastSaveSpot == null)
            SceneManager.LoadScene(0);
        else
        {
            player.transform.position = lastSaveSpot.position;
            player.Heal();
        }
    }
}
