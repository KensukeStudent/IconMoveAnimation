using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MoveControl : MonoBehaviour
{
    [SerializeField]
    private GameObject[] objs = null;

    private Vector2[] objsVec = null;

    [SerializeField]
    private bool isGo = false;

    [SerializeField]
    private Button[] buttons = null;

    [SerializeField]
    private float ativeDuration;

    private void Awake()
    {
        objsVec = new Vector2[objs.Length];
        for (int i = 0; i < objsVec.Length; i++)
        {
            objsVec[i] = objs[i].transform.position;
        }

        SetEvent();
    }

    private void SetEvent()
    {
        buttons[0].onClick.AddListener(() =>
        {
            for (int i = 0; i < objs.Length; i++)
            {
                objs[i].GetComponent<MoveObj1>().enabled = true;
                objs[i].GetComponent<MoveObj2>().enabled = false;
            }
            OnGO();
        });

        buttons[0].onClick.AddListener(() =>
        {
            for (int i = 0; i < objs.Length; i++)
            {
                objs[i].GetComponent<MoveObj1>().enabled = false;
                objs[i].GetComponent<MoveObj2>().enabled = true;
            }
            OnGO();
        });
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
                yield return new WaitForSeconds(ativeDuration);
            }
            break;
        }

        isGo = false;
    }

    private void OnGO()
    {
        if (!isGo)
        {
            isGo = true;
            StartCoroutine(CO());
        }
    }
}
