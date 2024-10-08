using UnityEngine;
using System;

/// <summary>
/// 初速度・加速度を使用したアニメーション
/// </summary>
public class MoveObj2 : MonoBehaviour
{
    [SerializeField, Header("初速度")]
    private float v0;

    [SerializeField, Header("加速度")]
    private float v1;

    /// <summary>
    /// 現在の速度
    /// </summary>
    private float currentV;

    [SerializeField, Header("累乗数")]
    private int powCount = 2;

    [SerializeField]
    private Transform goalPos = null;

    /// <summary>
    /// 初回移動ベクトル方向
    /// </summary>
    private Vector3 startVec;

    public Action OnComplete = null;

    private void OnEnable()
    {
        var spreadAngle = UnityEngine.Random.Range(0.0f, 360f);
        startVec = new Vector3(Mathf.Sin(spreadAngle), Mathf.Cos(spreadAngle), 0);

        currentV = v0;
    }

    private void Update()
    {
        if (Vector2.Distance(goalPos.position, transform.position) < 0.1f)
        {
            gameObject.SetActive(false);
            OnComplete?.Invoke();
            return;
        }

        if (currentV > 0)
        {
            transform.position += startVec * currentV * Time.deltaTime;
        }
        else
        {
            var diff = transform.position - goalPos.position;
            float speed = -Mathf.Abs(Mathf.Pow(currentV, powCount));
            transform.position += diff * speed * Time.deltaTime;
        }
        currentV -= v1 * Time.deltaTime;
    }
}
