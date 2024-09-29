using System.Collections;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    [SerializeField]
    private GameObject[] objs = null;

    private Vector2[] objsVec = null;

    [SerializeField]
    private bool isGo = false;

    private void Awake()
    {
        objsVec = new Vector2[objs.Length];
        for (int i = 0; i < objsVec.Length; i++)
        {
            objsVec[i] = objs[i].transform.position;
        }
    }

    private IEnumerator CO()
    {
        for (int i = 0; i < objsVec.Length; i++)
        {
            objs[i].transform.position = objsVec[i];
        }

        for (; ; )
        {
            for (int i = 0; i < objs.Length; i++)
            {
                objs[i].SetActive(true);
                yield return new WaitForSeconds(0.1f);
            }
            break;
        }

        isGo = false;
    }

    public void OnGO()
    {
        if (!isGo)
        {
            isGo = true;
            StartCoroutine(CO());
        }
    }
}
