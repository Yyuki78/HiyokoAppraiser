using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiyokoSpawner : MonoBehaviour
{
    [SerializeField] int Level;//このジェネレーターのレベル
    [SerializeField] GameObject HiyokoPrefab;
    
    //大体45秒程度

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.currentLevel < Level)
        {
            this.gameObject.SetActive(false);
        }

        if (this.gameObject.activeSelf == false) return;
        switch (GameManager.currentLevel)
        {
            case 1:
                StartCoroutine(Generator1());
                break;
            case 2:
                StartCoroutine(Generator2());
                break;
            case 3:
                StartCoroutine(Generator3());
                break;
            case 4:
                StartCoroutine(Generator4());
                break;
            case 5:
                StartCoroutine(Generator5());
                break;
            default:
                Debug.Log("レベル設定失敗");
                break;
        }
    }

    //出現数12
    private IEnumerator Generator1()
    {
        //ゲーム開始の待機時間1f+1Levelなので2f
        yield return new WaitForSeconds(3f);
        for(int i = 0; i < 3; i++)
        {
            Instantiate(HiyokoPrefab, this.gameObject.transform);
            yield return new WaitForSeconds(4f);
        }
        for (int i = 0; i < 9; i++)
        {
            Instantiate(HiyokoPrefab, this.gameObject.transform);
            yield return new WaitForSeconds(3f);
        }
        //ゲームは39秒経過
        yield return new WaitForSeconds(1f);
        yield break;
    }

    //出現数16
    private IEnumerator Generator2()
    {
        //ゲーム開始の待機時間1f+2Levelなので2f
        yield return new WaitForSeconds(3f);
        if (Level == 1)
        {
            for (int i = 0; i < 4; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(3f);
            }
            for (int i = 0; i < 5; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(4f);
            }
            //ゲームは32秒経過
            yield return new WaitForSeconds(8f);
            yield break;
        }
        else
        {
            yield return new WaitForSeconds(10f);
            for (int i = 0; i < 7; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(4f);
            }
            //ゲームは38秒経過
            yield return new WaitForSeconds(2f);
            yield break;
        }
    }

    //出現数24
    private IEnumerator Generator3()
    {
        //ゲーム開始の待機時間1f+3Levelなので1f
        yield return new WaitForSeconds(2f);
        if (Level == 1)
        {
            for (int i = 0; i < 4; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(3f);
            }
            for (int i = 0; i < 5; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(4f);
            }
            //ゲームは32秒経過
            yield return new WaitForSeconds(8f);
            yield break;
        }
        else if(Level == 2)
        {
            yield return new WaitForSeconds(5f);
            for (int i = 0; i < 8; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(4f);
            }
            //ゲームは37秒経過
            yield return new WaitForSeconds(4f);
            yield break;
        }
        else
        {
            yield return new WaitForSeconds(10f);
            for (int i = 0; i < 7; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(4f);
            }
            //ゲームは38秒経過
            yield return new WaitForSeconds(2f);
            yield break;
        }
    }

    //出現数28
    private IEnumerator Generator4()
    {
        //ゲーム開始の待機時間1f+3Levelなので1f
        yield return new WaitForSeconds(2f);
        if (Level == 1)
        {
            for (int i = 0; i < 3; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(3f);
            }
            for (int i = 0; i < 6; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(4f);
            }
            //ゲームは33秒経過
            yield return new WaitForSeconds(8f);
            yield break;
        }
        else if (Level == 2)
        {
            yield return new WaitForSeconds(4f);
            for (int i = 0; i < 8; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(4f);
            }
            //ゲームは36秒経過
            yield return new WaitForSeconds(4f);
            yield break;
        }
        else if (Level == 3)
        {
            yield return new WaitForSeconds(10f);
            for (int i = 0; i < 6; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(4f);
            }
            //ゲームは34秒経過
            yield return new WaitForSeconds(6f);
            yield break;
        }
        else
        {
            yield return new WaitForSeconds(15f);
            for (int i = 0; i < 5; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(4f);
            }
            //ゲームは35秒経過
            yield return new WaitForSeconds(5f);
            yield break;
        }
    }

    //出現数33
    private IEnumerator Generator5()
    {
        //ゲーム開始の待機時間1f+3Levelなので1f
        yield return new WaitForSeconds(2f);
        if (Level == 1)
        {
            for (int i = 0; i < 4; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(3f);
            }
            for (int i = 0; i < 6; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(4f);
            }
            //ゲームは36秒経過
            yield return new WaitForSeconds(8f);
            yield break;
        }
        else if (Level == 2)
        {
            yield return new WaitForSeconds(1f);
            for (int i = 0; i < 9; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(4f);
            }
            //ゲームは37秒経過
            yield return new WaitForSeconds(3f);
            yield break;
        }
        else if (Level == 3)
        {
            yield return new WaitForSeconds(6f);
            for (int i = 0; i < 7; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(4f);
            }
            //ゲームは34秒経過
            yield return new WaitForSeconds(6f);
            yield break;
        }
        else
        {
            yield return new WaitForSeconds(7f);
            for (int i = 0; i < 7; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(4f);
            }
            //ゲームは35秒経過
            yield return new WaitForSeconds(5f);
            yield break;
        }
    }
}
