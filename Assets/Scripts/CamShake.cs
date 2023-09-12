using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    //Kamera titresimi//
    private bool ShakeControl = false;

    public IEnumerator CamShakes(float duration, float magnitude) { 


        Vector3 originalPoz = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPoz.z);

            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originalPoz;
    }

    public void CamShakeCall()
    {
        if (ShakeControl == false)
        {
            StartCoroutine(CamShakes(0.22f, 0.4f));
            ShakeControl = true;
        }
    }
}
