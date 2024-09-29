using DG.Tweening;
using UnityEngine;

/// <summary>
/// DOTweenを使用したアニメーション
/// </summary>
public class MoveObj1 : MonoBehaviour
{
    [SerializeField]
    private float spreadDuration = 1.5f;

    [SerializeField]
    private float spreadRadius = 30.0f;

    [SerializeField]
    private float goalDuration = 3.0f;

    [SerializeField]
    private Transform goalPos = null;

    private Sequence sequence = null;

    private void OnEnable()
    {
        sequence?.Kill();

        var spreadAngle = UnityEngine.Random.Range(0.0f, 360f);
        var spreadVec = new Vector3(spreadRadius * Mathf.Sin(spreadAngle), spreadRadius * Mathf.Cos(spreadAngle), 0);

        sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(transform.position + spreadVec, spreadDuration).SetEase(Ease.OutCubic))
        .Append(transform.DOMove(goalPos.position, goalDuration).SetEase(Ease.InCubic));

        sequence.AppendCallback(() =>
        {
            gameObject.SetActive(false);
        });


        sequence.Play();
    }
}
