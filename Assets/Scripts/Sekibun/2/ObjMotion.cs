using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMotion : MonoBehaviour
{
    private Vector3 p1;

    [SerializeField]
    private Transform moveObj = null;

    [SerializeField]
    private Transform _target = null;

    private Vector3 target => _target.position;

    private void Update()
    {
        var pos = moveObj.position;
        p1 += (target - pos) * 4f * Time.deltaTime; // 4はばね係数
        p1 -= p1 * 1f * Time.deltaTime; // ドラッグによる速度比例抵抗
        pos += p1 * Time.deltaTime;
        moveObj.position = pos;
        float LookRotation = Vector2.SignedAngle(Vector2.up, p1);
        moveObj.eulerAngles = new Vector3(0, 0, Mathf.LerpAngle(moveObj.eulerAngles.z, LookRotation, 0.1f));
        // moveObj.rotation = Quaternion.LookRotation(p1, Vector3.forward);
    }
}
