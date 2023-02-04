using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBlinker : MonoBehaviour
{

    float originalHeight;

    void Awake()
    {
        originalHeight = transform.localScale.y;

        Blink();
    }

    void Blink()
    {
        StartCoroutine(BlinkAnim());
    }

    IEnumerator BlinkAnim()
    {
        float elapsedTime = 0f;

        float duration = Random.Range(.3f, .5f);

        float eyeHeight = transform.localScale.y;


        while (transform.localScale.y > 0f)
        {

            transform.localScale = new Vector3(transform.localScale.x, eyeHeight - (elapsedTime / duration), transform.localScale.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        eyeHeight = transform.localScale.y;
        elapsedTime = 0f;

        while (transform.localScale.y < originalHeight)
        {

            transform.localScale = new Vector3(transform.localScale.x, eyeHeight + (elapsedTime / duration), transform.localScale.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        StartCoroutine(BlinkTimer());
        yield break;


    }

    IEnumerator BlinkTimer()
    {
        yield return new WaitForSeconds(Random.Range(1f, 5f));

        Blink();
    }


}
