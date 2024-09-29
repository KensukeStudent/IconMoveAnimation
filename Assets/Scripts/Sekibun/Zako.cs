using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zako : MonoBehaviour
{
    [SerializeField]
    private float len = 10;

    private void Update()
    {
        var pos = transform.position;
        // 三角関数でsinの周期を表す
        pos.x = Mathf.Sin(Time.time) * len;
        transform.position = pos;
    }
}
