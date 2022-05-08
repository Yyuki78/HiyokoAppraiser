using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{
    //それぞれのゲート
    [SerializeField] GameObject GateR1;
    [SerializeField] GameObject GateL1;
    [SerializeField] GameObject GateR2;
    [SerializeField] GameObject GateL2;
    [SerializeField] GameObject GateU1;
    [SerializeField] GameObject GateD1;
    [SerializeField] GameObject GateU2;
    [SerializeField] GameObject GateD2;

    private int level;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.GameMode == 1)
        {
            level = 1;
        }
        else if (GameManager.GameMode == 2)
        {
            level = GameManager.currentLevel2;
        }
        else
        {
            level = GameManager.currentLevel3;
            if (GameManager.currentLevel3 == 4 || GameManager.currentLevel3 == 5)
            {
                level = 6;
            }
        }
        StartCoroutine(GateAnimetion());
    }

    private IEnumerator GateAnimetion()
    {
        yield return new WaitForSeconds(1f);
        switch (level)
        {
            case 1:
                yield return new WaitForSeconds(1f);
                StartCoroutine(GateOpen1(1));
                break;
            case 2:
                yield return new WaitForSeconds(1f);
                StartCoroutine(GateOpen1(1));
                yield return new WaitForSeconds(10f);
                StartCoroutine(GateOpen1(2));
                break;
            case 3:
                StartCoroutine(GateOpen1(1));
                yield return new WaitForSeconds(10f);
                StartCoroutine(GateOpen1(2));
                yield return new WaitForSeconds(5f);
                StartCoroutine(GateOpen2(1));
                break;
            case 4:
                StartCoroutine(GateOpen1(1));
                yield return new WaitForSeconds(10f);
                StartCoroutine(GateOpen1(2));
                yield return new WaitForSeconds(5f);
                StartCoroutine(GateOpen2(1));
                yield return new WaitForSeconds(5f);
                StartCoroutine(GateOpen2(2));
                break;
            case 5:
                StartCoroutine(GateOpen1(1));
                yield return new WaitForSeconds(10f);
                StartCoroutine(GateOpen1(2));
                yield return new WaitForSeconds(5f);
                StartCoroutine(GateOpen2(1));
                yield return new WaitForSeconds(5f);
                StartCoroutine(GateOpen2(2));
                break;
            case 6:
                StartCoroutine(GateOpen1(1));
                yield return new WaitForSeconds(5f);
                StartCoroutine(GateOpen1(2));
                yield return new WaitForSeconds(5f);
                StartCoroutine(GateOpen2(1));
                yield return new WaitForSeconds(5f);
                StartCoroutine(GateOpen2(2));
                break;
            default:
                Debug.Log("ゲートアニメーションに失敗");
                break;
        }
    }

    private IEnumerator GateOpen1(int gate)
    {
        switch (gate)
        {
            case 1:
                for(int i = 0; i < 20; i++)
                {
                    GateR1.transform.localPosition += new Vector3(0.1f, 0, 0);
                    GateL1.transform.localPosition -= new Vector3(0.1f, 0, 0);
                    yield return new WaitForSeconds(0.1f);
                }
                break;
            case 2:
                for (int i = 0; i < 20; i++)
                {
                    GateR2.transform.localPosition += new Vector3(0.1f, 0, 0);
                    GateL2.transform.localPosition -= new Vector3(0.1f, 0, 0);
                    yield return new WaitForSeconds(0.1f);
                }
                break;
        }
    }

    private IEnumerator GateOpen2(int gate)
    {
        switch (gate)
        {
            case 1:
                for (int i = 0; i < 20; i++)
                {
                    GateU1.transform.localPosition += new Vector3(0, 0.05f, 0);
                    GateD1.transform.localPosition -= new Vector3(0, 0.05f, 0);
                    yield return new WaitForSeconds(0.1f);
                }
                break;
            case 2:
                for (int i = 0; i < 20; i++)
                {
                    GateU2.transform.localPosition += new Vector3(0, 0.05f, 0);
                    GateD2.transform.localPosition -= new Vector3(0, 0.05f, 0);
                    yield return new WaitForSeconds(0.1f);
                }
                break;
        }
    }
}
