using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float ForwardSpeed;

    // Update is called once per frame
    void Update()
    {
        if (Veriables.FirstTouch == 1)
        {
            transform.position += new Vector3(0, 0, ForwardSpeed * Time.deltaTime);

        }

    }
}
