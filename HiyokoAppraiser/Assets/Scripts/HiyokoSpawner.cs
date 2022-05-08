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
        if (GameManager.GameMode == 1)
        {
            if (1 < Level)
            {
                this.gameObject.SetActive(false);
            }
        }
        else if (GameManager.GameMode == 2)
        {
            if (GameManager.currentLevel2 < Level)
            {
                this.gameObject.SetActive(false);
            }
        }
        else
        {
            if (GameManager.currentLevel3 < Level)
            {
                this.gameObject.SetActive(false);
            }
        }


        if (this.gameObject.activeSelf == false) return;

        if (GameManager.GameMode == 1)
        {
            StartCoroutine(TutrialGenerator(GameManager.currentLevel));
        }
        else if (GameManager.GameMode == 2)
        {
            switch (GameManager.currentLevel2)
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
        else
        {
            switch (GameManager.currentLevel3)
            {
                case 1:
                    StartCoroutine(HGenerator1());
                    break;
                case 2:
                    StartCoroutine(HGenerator2());
                    break;
                case 3:
                    StartCoroutine(HGenerator3());
                    break;
                case 4:
                    StartCoroutine(HGenerator4());
                    break;
                case 5:
                    StartCoroutine(HGenerator5());
                    break;
                default:
                    Debug.Log("レベル設定失敗");
                    break;
            }
        }

        if (GameManager.HiyokoSize == 1)
        {
            this.gameObject.transform.localScale = new Vector3(1, 1, 1);
        }else if(GameManager.HiyokoSize == 2)
        {
            this.gameObject.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
        }
        else
        {
            this.gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
    }

    //チュートリアルの生成1,2=1体、3,4=2体、5=3体
    private IEnumerator TutrialGenerator(int level)
    {
        yield return new WaitForSeconds(5f);
        if (level == 1 || level == 2)
        {
            Instantiate(HiyokoPrefab, this.gameObject.transform);
        }
        else if (level == 3 || level == 4)
        {
            Instantiate(HiyokoPrefab, this.gameObject.transform);
            yield return new WaitForSeconds(5f);
            Instantiate(HiyokoPrefab, this.gameObject.transform);
        }
        else
        {
            Instantiate(HiyokoPrefab, this.gameObject.transform);
            yield return new WaitForSeconds(3f);
            Instantiate(HiyokoPrefab, this.gameObject.transform);
            yield return new WaitForSeconds(3f);
            Instantiate(HiyokoPrefab, this.gameObject.transform);
        }
    }

    //出現数10
    private IEnumerator Generator1()
    {
        //ゲーム開始の待機時間1f+1Levelなので2f
        yield return new WaitForSeconds(5f);
        for (int i = 0; i < 2; i++)
        {
            Instantiate(HiyokoPrefab, this.gameObject.transform);
            yield return new WaitForSeconds(4f);
        }
        for (int i = 0; i < 8; i++)
        {
            Instantiate(HiyokoPrefab, this.gameObject.transform);
            yield return new WaitForSeconds(4f);
        }
        //ゲームは40秒経過
        yield return new WaitForSeconds(1f);
        yield break;
    }

    //出現数13
    private IEnumerator Generator2()
    {
        //ゲーム開始の待機時間1f+2Levelなので2f
        yield return new WaitForSeconds(5f);
        if (Level == 1)
        {
            for (int i = 0; i < 5; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(4f);
            }
            yield return new WaitForSeconds(5f);
            for (int i = 0; i < 3; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(6f);
            }
            //ゲームは43秒経過
            yield return new WaitForSeconds(3f);
            yield break;
        }
        else
        {
            yield return new WaitForSeconds(10f);
            for (int i = 0; i < 5; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(6f);
            }
            //ゲームは40秒経過
            yield return new WaitForSeconds(2f);
            yield break;
        }
    }

    //出現数16
    private IEnumerator Generator3()
    {
        //ゲーム開始の待機時間1f+3Levelなので1f
        yield return new WaitForSeconds(4f);
        if (Level == 1)
        {
            for (int i = 0; i < 3; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(4f);
            }
            for (int i = 0; i < 4; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(7f);
            }
            //ゲームは40秒経過
            yield return new WaitForSeconds(3f);
            yield break;
        }
        else if (Level == 2)
        {
            yield return new WaitForSeconds(10f);
            for (int i = 0; i < 5; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(7f);
            }
            //ゲームは45秒経過
            yield return new WaitForSeconds(4f);
            yield break;
        }
        else
        {
            yield return new WaitForSeconds(15f);
            for (int i = 0; i < 4; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(6f);
            }
            //ゲームは39秒経過
            yield return new WaitForSeconds(2f);
            yield break;
        }
    }

    //出現数20
    private IEnumerator Generator4()
    {
        //ゲーム開始の待機時間1f+3Levelなので1f
        yield return new WaitForSeconds(4f);
        if (Level == 1)
        {
            for (int i = 0; i < 3; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(4f);
            }
            for (int i = 0; i < 4; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(7f);
            }
            //ゲームは40秒経過
            yield return new WaitForSeconds(3f);
            yield break;
        }
        else if (Level == 2)
        {
            yield return new WaitForSeconds(10f);
            for (int i = 0; i < 5; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(6f);
            }
            //ゲームは40秒経過
            yield return new WaitForSeconds(4f);
            yield break;
        }
        else if (Level == 3)
        {
            yield return new WaitForSeconds(15f);
            for (int i = 0; i < 5; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(6f);
            }
            //ゲームは45秒経過
            yield return new WaitForSeconds(2f);
            yield break;
        }
        else
        {
            yield return new WaitForSeconds(20f);
            for (int i = 0; i < 3; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(7f);
            }
            //ゲームは41秒経過
            yield return new WaitForSeconds(5f);
            yield break;
        }
    }

    //出現数24
    private IEnumerator Generator5()
    {
        //ゲーム開始の待機時間1f+3Levelなので1f
        yield return new WaitForSeconds(4f);
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
                yield return new WaitForSeconds(6f);
            }
            //ゲームは42秒経過
            yield return new WaitForSeconds(3f);
            yield break;
        }
        else if (Level == 2)
        {
            yield return new WaitForSeconds(10f);
            for (int i = 0; i < 6; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(5f);
            }
            //ゲームは40秒経過
            yield return new WaitForSeconds(4f);
            yield break;
        }
        else if (Level == 3)
        {
            yield return new WaitForSeconds(15f);
            for (int i = 0; i < 5; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(6f);
            }
            //ゲームは45秒経過
            yield return new WaitForSeconds(2f);
            yield break;
        }
        else
        {
            yield return new WaitForSeconds(20f);
            for (int i = 0; i < 4; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(5f);
            }
            //ゲームは40秒経過
            yield return new WaitForSeconds(5f);
            yield break;
        }
    }

    //出現数15
    private IEnumerator HGenerator1()
    {
        //ゲーム開始の待機時間1f+1Levelなので2f
        yield return new WaitForSeconds(5f);
        for (int i = 0; i < 10; i++)
        {
            Instantiate(HiyokoPrefab, this.gameObject.transform);
            yield return new WaitForSeconds(3f);
        }
        for (int i = 0; i < 5; i++)
        {
            Instantiate(HiyokoPrefab, this.gameObject.transform);
            yield return new WaitForSeconds(2.4f);
        }
        //ゲームは42秒経過
        yield return new WaitForSeconds(1f);
        yield break;
    }

    //出現数19
    private IEnumerator HGenerator2()
    {
        //ゲーム開始の待機時間1f+2Levelなので2f
        yield return new WaitForSeconds(5f);
        if (Level == 1)
        {
            for (int i = 0; i < 6; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(3f);
            }
            for (int i = 0; i < 5; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(4.4f);
            }
            //ゲームは40秒経過
            yield return new WaitForSeconds(3f);
            yield break;
        }
        else
        {
            yield return new WaitForSeconds(10f);
            for (int i = 0; i < 8; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(4f);
            }
            //ゲームは42秒経過
            yield return new WaitForSeconds(2f);
            yield break;
        }
    }

    //出現数24
    private IEnumerator HGenerator3()
    {
        //ゲーム開始の待機時間1f+3Levelなので1f
        yield return new WaitForSeconds(4f);
        if (Level == 1)
        {
            for (int i = 0; i < 7; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(3f);
            }
            for (int i = 0; i < 5; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(4f);
            }
            //ゲームは41秒経過
            yield return new WaitForSeconds(3f);
            yield break;
        }
        else if (Level == 2)
        {
            yield return new WaitForSeconds(10f);
            for (int i = 0; i < 6; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(5f);
            }
            //ゲームは40秒経過
            yield return new WaitForSeconds(4f);
            yield break;
        }
        else
        {
            yield return new WaitForSeconds(15f);
            for (int i = 0; i < 6; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(4.5f);
            }
            //ゲームは42秒経過
            yield return new WaitForSeconds(2f);
            yield break;
        }
    }

    //出現数29
    private IEnumerator HGenerator4()
    {
        //ゲーム開始の待機時間1f+3Levelなので1f
        yield return new WaitForSeconds(4f);
        if (Level == 1)
        {
            for (int i = 0; i < 7; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(3f);
            }
            for (int i = 0; i < 4; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(5f);
            }
            //ゲームは41秒経過
            yield return new WaitForSeconds(3f);
            yield break;
        }
        else if (Level == 2)
        {
            yield return new WaitForSeconds(5f);
            for (int i = 0; i < 6; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(6f);
            }
            //ゲームは41秒経過
            yield return new WaitForSeconds(4f);
            yield break;
        }
        else if (Level == 3)
        {
            yield return new WaitForSeconds(10f);
            for (int i = 0; i < 7; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(4.5f);
            }
            //ゲームは41.5秒経過
            yield return new WaitForSeconds(2f);
            yield break;
        }
        else
        {
            yield return new WaitForSeconds(15f);
            for (int i = 0; i < 5; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(5.5f);
            }
            //ゲームは42.5秒経過
            yield return new WaitForSeconds(5f);
            yield break;
        }
    }

    //出現数33
    private IEnumerator HGenerator5()
    {
        //ゲーム開始の待機時間1f+3Levelなので1f
        yield return new WaitForSeconds(4f);
        if (Level == 1)
        {
            for (int i = 0; i < 8; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(3f);
            }
            for (int i = 0; i < 5; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(4f);
            }
            //ゲームは44秒経過
            yield return new WaitForSeconds(3f);
            yield break;
        }
        else if (Level == 2)
        {
            yield return new WaitForSeconds(5f);
            for (int i = 0; i < 8; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(5f);
            }
            //ゲームは45秒経過
            yield return new WaitForSeconds(4f);
            yield break;
        }
        else if (Level == 3)
        {
            yield return new WaitForSeconds(10f);
            for (int i = 0; i < 7; i++)
            {
                Instantiate(HiyokoPrefab, this.gameObject.transform);
                yield return new WaitForSeconds(4.5f);
            }
            //ゲームは41.5秒経過
            yield return new WaitForSeconds(2f);
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
            //ゲームは45秒経過
            yield return new WaitForSeconds(5f);
            yield break;
        }
    }
}
