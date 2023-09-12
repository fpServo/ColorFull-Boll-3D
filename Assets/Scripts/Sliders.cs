using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliders : MonoBehaviour
{
    public Vector3 Pos1;
    public Vector3 Pos2;

    public float Speed;

    void Update()
    {
        gameObject.GetComponent<Transform>().localPosition = Vector3.Lerp(Pos1, Pos2, Mathf.PingPong(Time.time * Speed, 1.0f));
    }
}
