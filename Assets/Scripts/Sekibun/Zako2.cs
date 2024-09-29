using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zako2 : MonoBehaviour
{
    [SerializeField]
    private float len = 10;

    private Vector3 p1;

    private void Start()
    {
        p1.x = len;
    }

    private void Update()
    {
        var pos = transform.position;
        // sinを微分したcosをさらに微分したものを計算する
        // -> 微分
        // sin(x)  cos(x)
        // cos(x)  -sin(x)
        // <- 積分
        p1.x += -Mathf.Sin(Time.time) * len * Time.deltaTime;
        pos.x += p1.x * Time.deltaTime;
        transform.position = pos;
    }
}
