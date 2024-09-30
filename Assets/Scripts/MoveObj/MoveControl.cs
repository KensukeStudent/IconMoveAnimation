using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MoveControl : MonoBehaviour
{
    [SerializeField]
    private GameObject[] objs = null;

    private Vector2[] objsVec = null;

    private bool isGo = false;

    [SerializeField]
    private Button[] buttons = null;

    [SerializeField]
    private float ativeDuration;

    [SerializeField]
    private new AudioSource audio = null;

    [SerializeField]
    private AudioClip clip1;

    [SerializeField]
    private AudioClip clip2;

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
                objs[i].GetComponent<MoveObj3>().enabled = false;

                objs[i].GetComponent<MoveObj1>().OnComplete = () =>
                {
                    audio.PlayOneShot(clip2);
                };
            }
            OnGO();
        });

        buttons[1].onClick.AddListener(() =>
        {
            for (int i = 0; i < objs.Length; i++)
            {
                objs[i].GetComponent<MoveObj1>().enabled = false;
                objs[i].GetComponent<MoveObj2>().enabled = true;
                objs[i].GetComponent<MoveObj3>().enabled = false;

                objs[i].GetComponent<MoveObj2>().OnComplete = () =>
                {
                    audio.PlayOneShot(clip2);
                };
            }
            OnGO();
        });

        buttons[2].onClick.AddListener(() =>
        {
            for (int i = 0; i < objs.Length; i++)
            {
                objs[i].GetComponent<MoveObj1>().enabled = false;
                objs[i].GetComponent<MoveObj2>().enabled = false;
                objs[i].GetComponent<MoveObj3>().enabled = true;

                objs[i].GetComponent<MoveObj3>().Init();
                objs[i].GetComponent<MoveObj3>().OnComplete = () =>
                {
                    audio.PlayOneShot(clip2);
                };
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
                audio.PlayOneShot(clip1);
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
