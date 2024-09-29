using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zako3 : MonoBehaviour
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

        // pos.x = Mathf.Sin(Time.time) * len;のことから
        // 上記をpos.xに置き換えても同じ動きをする想定
        p1.x += -pos.x * Time.deltaTime;
        pos.x += p1.x * Time.deltaTime;
        transform.position = pos;
    }
}
