using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public static bool FirstTime = true;
    public static bool ClearEasy = false;
    public static bool ClearNormal = false;
    public static bool ClearHard = false;
    public static int ClearRound;

    [SerializeField] GameObject Tutrial;
    [SerializeField] GameObject GameSetting;

    [SerializeField] GameObject TutrialHiyokoPrefab;

    [SerializeField] GameObject BGImage;
    [SerializeField] GameObject SmallerImage;

    [SerializeField] GameObject EasyButton;
    [SerializeField] GameObject NormalButton;
    [SerializeField] GameObject HardButton;

    [SerializeField] GameObject GameContinueButton;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < ClearRound; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-8.5f, 8.5f), Random.Range(-4.5f, 4.5f), 0);
            Instantiate(TutrialHiyokoPrefab, pos, new Quaternion(0, 0, 0, 0), this.gameObject.transform);
        }
        Tutrial.SetActive(false);
        GameSetting.SetActive(false);
        SmallerImage.SetActive(false);
        BGImage.SetActive(false);
        if (FirstTime)
        {
            GameManager.UltType = 1;
            GameManager.HiyokoSize = 2;
            GameContinueButton.SetActive(false);
        }
        if (ClearEasy == false)
        {
            EasyButton.SetActive(false);
            NormalButton.SetActive(false);
        }
        else
        {
            GameManager.GameMode = 2;
            EasyButton.SetActive(true);
            NormalButton.SetActive(true);
        }

        if (ClearNormal == false)
        {
            HardButton.SetActive(false);
        }
        else
        {
            GameManager.GameMode = 3;
            HardButton.SetActive(true);
        }

        if (GameManager.GameMode == 1)
        {
            if (GameManager.reachLevel >= 2 || GameManager.reachLevel == 5)
            {
                GameContinueButton.SetActive(true);
            }
            else
            {
                GameContinueButton.SetActive(false);
            }
        }else if(GameManager.GameMode == 2 || GameManager.reachLevel2 == 5)
        {
            if (GameManager.reachLevel2 >= 2)
            {
                GameContinueButton.SetActive(true);
            }
            else
            {
                GameContinueButton.SetActive(false);
            }
        }
        else
        {
            if (GameManager.reachLevel3 >= 2 || GameManager.reachLevel3 == 5)
            {
                GameContinueButton.SetActive(true);
            }
            else
            {
                GameContinueButton.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (GameManager.GameMode == 1)
        {
            if (GameManager.reachLevel == 2 || GameManager.reachLevel == 3 || GameManager.reachLevel == 4)
            {
                GameContinueButton.SetActive(true);
            }
            else
            {
                GameContinueButton.SetActive(false);
            }
        }
        else if (GameManager.GameMode == 2)
        {
            if (GameManager.reachLevel3 == 2 || GameManager.reachLevel2 == 3 || GameManager.reachLevel2 == 4)
            {
                GameContinueButton.SetActive(true);
            }
            else
            {
                GameContinueButton.SetActive(false);
            }
        }
        else
        {
            if (GameManager.reachLevel3 == 2 || GameManager.reachLevel3 == 3 || GameManager.reachLevel3 == 4)
            {
                GameContinueButton.SetActive(true);
            }
            else
            {
                GameContinueButton.SetActive(false);
            }
        }
    }

    public void OnClickGameStart()
    {
        if (FirstTime)
        {
            Tutrial.SetActive(true);
        }
        else
        {
            StartCoroutine(StartGame());
            if (GameManager.GameMode == 1)
            {
                GameManager.currentLevel = 0;
            }
            else if (GameManager.GameMode == 2)
            {
                GameManager.currentLevel2 = 0;
            }
            else
            {
                GameManager.currentLevel3 = 0;
            }
        }
    }

    public void OnClickContinueGame()
    {
        if (GameManager.GameMode == 1)
        {
            GameManager.currentLevel = GameManager.reachLevel - 1;
        }
        else if (GameManager.GameMode == 2)
        {
            GameManager.currentLevel2 = GameManager.reachLevel2 - 1;
        }
        else
        {
            GameManager.currentLevel3 = GameManager.reachLevel3 - 1;
        }
        StartCoroutine(StartGame());
    }

    public void OnClickGameSetting()
    {
        GameSetting.SetActive(true);
    }

    private IEnumerator StartGame()
    {
        SmallerImage.SetActive(true);
        BGImage.SetActive(true);
        yield return new WaitForSeconds(0.01f);
        for (int i = 0; i < 49; i++)
        {
            SmallerImage.transform.localScale -= new Vector3(1f, 1f, 0);
            yield return new WaitForSeconds(0.005f);
        }
        GameManager.FirstLevel = true;
        SceneManager.LoadScene("SampleScene");
        yield break;
    }
}
