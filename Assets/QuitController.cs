using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitController : MonoBehaviour
{
    public Animator quitAnim;

    bool quitEnabled;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!quitEnabled)
            {
                StartCoroutine(QuitCountdown());
            }
            else
            {
                Debug.Log("Quit!");
                Application.Quit();
            }
        }
    }

    IEnumerator QuitCountdown()
    {
        quitEnabled = true;
        quitAnim.SetBool("Open", true);

        yield return new WaitForSeconds(3);

        quitAnim.SetBool("Open", false);
        quitEnabled = false;
    }

}
