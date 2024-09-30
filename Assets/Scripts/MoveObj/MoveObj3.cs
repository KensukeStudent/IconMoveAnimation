using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 初速度・加速度を使用したアニメーション
/// </summary>
public class MoveObj3 : MonoBehaviour
{
    private class NextPos
    {
        public Vector3 nextVec;

        public Transform nextPos;

        public Vector3 GetPos()
        {
            return nextPos == null ? nextVec : nextPos.position;
        }
    }

    [SerializeField]
    private Transform lastGoal = null;

    private Vector3 p1;

    private List<NextPos> list = new List<NextPos>();

    private int no = 0;

    public void Init()
    {
        no = 0;
        list.Clear();

        var spreadAngle = UnityEngine.Random.Range(0.0f, 360f);
        var startVec = new Vector3(Mathf.Sin(spreadAngle), Mathf.Cos(spreadAngle), 0);
        list.Add(new NextPos()
        {
            nextVec = startVec
        });
        list.Add(new NextPos()
        {
            nextPos = lastGoal
        });
    }

    private void Update()
    {
        if (Vector2.Distance(list[no].GetPos(), transform.position) < 0.3f)
        {
            no++;

            if (no == list.Count)
            {
                gameObject.SetActive(false);
                return;
            }
        }

        var pos = transform.position;
        var targetPos = list[no].GetPos();
        p1 += (targetPos - pos) * 4f * Time.deltaTime; // 4はばね係数
        p1 -= p1 * 1f * Time.deltaTime; // ドラッグによる速度比例抵抗
        pos += p1 * Time.deltaTime;
        transform.position = pos;
        float LookRotation = Vector2.SignedAngle(Vector2.up, p1);
        transform.eulerAngles = new Vector3(0, 0, Mathf.LerpAngle(transform.eulerAngles.z, LookRotation, 0.1f));
    }
}
