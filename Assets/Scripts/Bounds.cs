using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    public Transform VectorRight;
    public Transform VectorLeft;
    public Transform VectorForward;
    public Transform VectorBack;

    public void LateUpdate()
    {
        Vector3 wiewPos = transform.position;
        wiewPos.z = Mathf.Clamp(wiewPos.z, VectorBack.transform.position.z, VectorForward.transform.position.z);
        wiewPos.x = Mathf.Clamp(wiewPos.x, VectorLeft.transform.position.x, VectorRight.transform.position.x);
        transform.position = wiewPos;
    }
}
