using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zako1 : MonoBehaviour
{
    [SerializeField]
    private float len = 10;

    private void Update()
    {
        var pos = transform.position;
        // sinを微分した値で計算する
        // -> 微分
        // sin(x)  cos(x)
        // cis(x)  -sin(x)
        // <- 積分
        pos.x += Mathf.Cos(Time.time) * len * Time.deltaTime;
        transform.position = pos;
    }
}
