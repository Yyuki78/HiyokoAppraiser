using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameClear : MonoBehaviour
{
    //レベル1～4まではレベルクリア演出
    //レベル5はゲームクリア演出

    [SerializeField] GameObject levelClear;
    [SerializeField] GameObject gameClear;
    [SerializeField] GameObject _cleartext;
    [SerializeField] TextMeshProUGUI _notetext;//ゲームクリア時の通知

    [SerializeField] TextMeshProUGUI _text;

    [SerializeField] GameObject ChangeImage;

    // Start is called before the first frame update
    void Start()
    {
        gameClear.SetActive(false);
        levelClear.SetActive(false);
        _cleartext.SetActive(false);


        if (GameManager.GameMode == 1)
        {
            if (GameManager.currentLevel == 5)
            {
                StartCoroutine(clearLevel());
            }
            else
            {
                levelClear.SetActive(true);
                StartCoroutine(nextLevel());
            }
        }
        else if (GameManager.GameMode == 2)
        {
            if (GameManager.currentLevel2 == 5)
            {
                StartCoroutine(clearLevel());
            }
            else
            {
                levelClear.SetActive(true);
                StartCoroutine(nextLevel());
            }
        }
        else
        {
            if (GameManager.currentLevel3 == 5)
            {
                StartCoroutine(clearLevel());
            }
            else
            {
                levelClear.SetActive(true);
                StartCoroutine(nextLevel());
            }
        }

        TitleManager.ClearRound += 1;
    }

    private IEnumerator nextLevel()
    {
        _text.text = "";
        yield return new WaitForSeconds(2);
        _text.text = "次のレベル開始まで...3";
        yield return new WaitForSeconds(1);
        _text.text = "次のレベル開始まで...2";
        yield return new WaitForSeconds(1);
        _text.text = "次のレベル開始まで...1";
        yield return new WaitForSeconds(1);
        ChangeImage.SetActive(true);
        ChangeImage.transform.localScale = new Vector3(0, 0, 0);
        for (int i = 0; i < 50; i++)
        {
            ChangeImage.transform.localScale += new Vector3(0.5f, 0.5f, 0);
            yield return new WaitForSeconds(0.002f);
        }
        SceneManager.LoadScene("SampleScene");
    }

    private IEnumerator clearLevel()
    {
        _cleartext.SetActive(true);
        if (GameManager.GameMode == 1)
        {
            if (TitleManager.ClearEasy == false)
            {
                _notetext.text = "ノーマルモードが\n解放されました!";
                TitleManager.ClearEasy = true;
            }
            else
            {
                _notetext.text = "クリアおめでとう！";
            }
        }
        else if (GameManager.GameMode == 2)
        {
            if (TitleManager.ClearNormal == false)
            {
                _notetext.text = "ハードモードが\n解放されました!";
                TitleManager.ClearNormal = true;
            }
            else
            {
                _notetext.text = "ノーマルモードクリア\nおめでとう！";
            }
        }
        else
        {
            if (TitleManager.ClearHard == false)
            {
                _notetext.text = "完全クリア\nおめでとう！";
                TitleManager.ClearHard = true;
            }
            else
            {
                _notetext.text = "ハードモードクリアおめでとう！";
            }
        }
        yield return new WaitForSeconds(2.5f);
        gameClear.SetActive(true);
    }

    public void OnClick()
    {
        StartCoroutine(SceneChange());
    }

    private IEnumerator SceneChange()
    {
        ChangeImage.SetActive(true);
        ChangeImage.transform.localScale = new Vector3(0, 0, 0);
        for (int i = 0; i < 50; i++)
        {
            ChangeImage.transform.localScale += new Vector3(1f, 1f, 0);
            yield return new WaitForSeconds(0.005f);
        }
        SceneManager.LoadScene("TitleScene");
    }
}
