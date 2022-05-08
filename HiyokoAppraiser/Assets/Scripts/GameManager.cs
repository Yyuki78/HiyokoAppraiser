using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int GameMode;//ゲームモード(1=Tutrial,2=Normal,3=Hard)
    //Tutialとタイトル画面のチェックボックスで切り替える

    //モードごとに分ける
    public static int currentLevel;//現在のレベル
    public static int reachLevel;//到達したレベル(次回開始はここから)
    public static int currentLevel2;//現在のレベル
    public static int reachLevel2;//到達したレベル(次回開始はここから)
    public static int currentLevel3;//現在のレベル
    public static int reachLevel3;//到達したレベル(次回開始はここから)

    public static int HP;//残存HP

    public static int UltType;//必殺技の種類
    public static bool UltCan;//必殺技が使えるかどうか
    public static bool usingUlt = false;//UltUIで使用
    public bool Vanish = false;//HiyokoMoveで使用

    public static bool FirstLevel;//ゲーム開始時のレベルかどうか
    //Title+Tutrial+SceneButtons+GameStartUIで変更

    public static int HiyokoSize;//ひよこの大きさ 1=1,2=1.25,3=1.5

    public int mode1, mode2;
    //1.色2.帽子3.音
    //1.偶数2.素数3.以上

    public int score = 0;//未使用

    public static int transactionsNum;//処理済みのひよこ数

    public bool gameClear = false;
    public bool gameOver = false;
    [SerializeField] GameObject GameClear;
    [SerializeField] GameObject GameOver;

    private bool timeOver = false;

    private AudioSource _audio;
    [SerializeField] AudioClip _clip1;
    [SerializeField] AudioClip _clip2;

    [SerializeField] GameObject BGMObject;

    // Start is called before the first frame update
    void Awake()
    {
        //デバック用
        /*
        FirstLevel = true;
        UltType = 3;
        GameMode = 2;
        currentLevel2 = 4;*/
        if (GameManager.currentLevel < 0)
        {
            GameManager.currentLevel = 0;
        }
        if (GameManager.currentLevel2 < 0)
        {
            GameManager.currentLevel2 = 0;
        }
        if (GameManager.currentLevel3 < 0)
        {
            GameManager.currentLevel3 = 0;
        }

        if (FirstLevel)
        {
            GameManager.HP = 3;
            UltCan = true;
            if (GameMode == 1)
            {
                reachLevel = currentLevel;
            }
            else if (GameMode == 2)
            {
                reachLevel2 = currentLevel2;
            }
            else
            {
                reachLevel3 = currentLevel3;
            }
        }

        if (GameMode == 1)
        {
            currentLevel++;
            if (currentLevel == 1)
            {
                reachLevel = 1;
            }
            switch (currentLevel)
            {
                case 1:
                    mode1 = 1;
                    mode2 = 1;
                    break;
                case 2:
                    mode1 = 1;
                    mode2 = 3;
                    break;
                case 3:
                    mode1 = 2;
                    mode2 = 3;
                    break;
                case 4:
                    mode1 = 3;
                    mode2 = 1;
                    break;
                case 5:
                    mode1 = 1;
                    mode2 = 2;
                    break;
                default:
                    break;
            }
            Invoke(nameof(TimeOver), 4f);
        }
        else if (GameMode == 2)
        {
            if (currentLevel2 == 5)
            {
                mode2 = 2;
            }
            else
            {
                mode2 = Random.Range(1, 4);
            }
            mode2 = Random.Range(1, 4);
            if (mode2 == 2)
            {
                mode1 = Random.Range(1, 3);
            }
            else
            {
                mode1 = Random.Range(1, 4);
            }

            Invoke(nameof(TimeOver), 47f);

            currentLevel2++;
            if (currentLevel2 == 1)
            {
                reachLevel2 = 1;
            }
        }
        else
        {
            mode2 = Random.Range(1, 4);
            mode1 = Random.Range(1, 4);

            currentLevel3++;
            if (currentLevel3 == 1)
            {
                reachLevel3 = 1;
            }

            Invoke(nameof(TimeOver), 47f);
        }

        transactionsNum = 0;
        GameClear.SetActive(false);
        GameOver.SetActive(false);

        if (HP < 3)
        {
            HP++;
        }

        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeOver && gameOver == false)
        {
            if (GameMode == 1)
            {
                switch (currentLevel)
                {
                    case 1:
                        if (transactionsNum == 1)
                        {
                            BGMObject.SetActive(false);
                            gameClear = true;
                            GameClear.SetActive(true);
                            reachLevel = currentLevel;
                        }
                        break;
                    case 2:
                        if (transactionsNum == 1)
                        {
                            BGMObject.SetActive(false);
                            gameClear = true;
                            GameClear.SetActive(true);
                            reachLevel = currentLevel;
                        }
                        break;
                    case 3:
                        if (transactionsNum == 2)
                        {
                            BGMObject.SetActive(false);
                            gameClear = true;
                            GameClear.SetActive(true);
                            reachLevel = currentLevel;
                        }
                        break;
                    case 4:
                        if (transactionsNum == 2)
                        {
                            BGMObject.SetActive(false);
                            gameClear = true;
                            GameClear.SetActive(true);
                            reachLevel = currentLevel;
                        }
                        break;
                    case 5:
                        if (transactionsNum == 3)
                        {
                            BGMObject.SetActive(false);
                            gameClear = true;
                            GameClear.SetActive(true);
                            reachLevel = currentLevel;
                        }
                        break;
                    default:
                        Debug.Log("レベル間違ってます");
                        break;
                }
            }
            else if (GameMode == 2)
            {
                switch (currentLevel2)
                {
                    case 1:
                        if (transactionsNum == 10)
                        {
                            gameClear = true;
                            GameClear.SetActive(true);
                            reachLevel2 = currentLevel2;
                        }
                        break;
                    case 2:
                        if (transactionsNum == 13)
                        {
                            gameClear = true;
                            GameClear.SetActive(true);
                            reachLevel2 = currentLevel2;
                        }
                        break;
                    case 3:
                        if (transactionsNum == 16)
                        {
                            gameClear = true;
                            GameClear.SetActive(true);
                            reachLevel2 = currentLevel2;
                        }
                        break;
                    case 4:
                        if (transactionsNum == 20)
                        {
                            gameClear = true;
                            GameClear.SetActive(true);
                            reachLevel2 = currentLevel2;
                        }
                        break;
                    case 5:
                        if (transactionsNum == 24)
                        {
                            gameClear = true;
                            GameClear.SetActive(true);
                            reachLevel2 = currentLevel2;
                        }
                        break;
                    default:
                        Debug.Log("レベル間違ってます");
                        break;
                }
            }
            else
            {
                switch (currentLevel3)
                {
                    case 1:
                        if (transactionsNum == 15)
                        {
                            gameClear = true;
                            GameClear.SetActive(true);
                            reachLevel3 = currentLevel3;
                        }
                        break;
                    case 2:
                        if (transactionsNum == 19)
                        {
                            gameClear = true;
                            GameClear.SetActive(true);
                            reachLevel3 = currentLevel3;
                        }
                        break;
                    case 3:
                        if (transactionsNum == 24)
                        {
                            gameClear = true;
                            GameClear.SetActive(true);
                            reachLevel3 = currentLevel3;
                        }
                        break;
                    case 4:
                        if (transactionsNum == 29)
                        {
                            gameClear = true;
                            GameClear.SetActive(true);
                            reachLevel3 = currentLevel3;
                        }
                        break;
                    case 5:
                        if (transactionsNum == 33)
                        {
                            gameClear = true;
                            GameClear.SetActive(true);
                            reachLevel3 = currentLevel3;
                        }
                        break;
                    default:
                        Debug.Log("レベル間違ってます");
                        break;
                }
            }
            
        }
        
        if (HP <= 0)
        {
            BGMObject.SetActive(false);
            gameOver = true;
            GameOver.SetActive(true);
        }

        if (Input.GetMouseButtonDown(1) && UltCan == true)
        {
            Debug.Log("ultを使用します");
            UltCan = false;
            usingUlt = true;
            StartCoroutine(useUlt());
        }
    }

    private IEnumerator useUlt()
    {
        Time.timeScale = 0.1f;
        yield return new WaitForSeconds(0.1f);
        Time.timeScale = 1.0f;
        switch (UltType)
        {
            case 1:
                Time.timeScale = 0.25f;
                yield return new WaitForSeconds(1);
                Time.timeScale = 1.0f;
                break;
            case 2:
                HP = 3;
                break;
            case 3:
                Vanish = true;
                yield return new WaitForSeconds(1);
                Vanish = false;
                break;
        }
        yield break;
    }

    public void correct()
    {
        if (!Vanish)
        {
            _audio.PlayOneShot(_clip1);
        }
        transactionsNum++;
    }

    public void incorrect()
    {
        _audio.PlayOneShot(_clip2);
        HP--;
    }

    private void TimeOver()
    {
        timeOver = true;
    }
}
