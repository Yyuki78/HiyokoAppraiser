using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int currentLevel;//現在のレベル
    public static int reachLevel;//到達したレベル(次回開始はここから)

    public static int HP;//残存HP
    public static int UltNum;//必殺技の種類

    public int mode1, mode2;
    //1.色2.帽子3.音
    //1.偶数2.素数3.以上

    public int score = 0;

    public static int transactionsNum;

    public bool gameClear = false;
    public bool gameOver = false;
    [SerializeField] GameObject GameClear;
    [SerializeField] GameObject GameOver;

    // Start is called before the first frame update
    void Awake()
    {
        currentLevel += 1;
        HP = 3;
        mode1 = Random.Range(1, 4);
        mode2 = Random.Range(1, 4);
        transactionsNum = 0;
        GameClear.SetActive(false);
        GameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentLevel)
        {
            case 1:
                if (transactionsNum == 12)
                {
                    gameClear = true;
                    GameClear.SetActive(true);
                }
                break;
            case 2:
                if (transactionsNum == 16)
                {
                    gameClear = true;
                    GameClear.SetActive(true);
                }
                break;
            case 3:
                if (transactionsNum == 24)
                {
                    gameClear = true;
                    GameClear.SetActive(true);
                }
                break;
            case 4:
                if (transactionsNum == 28)
                {
                    gameClear = true;
                    GameClear.SetActive(true);
                }
                break;
            case 5:
                if (transactionsNum == 33)
                {
                    gameClear = true;
                    GameClear.SetActive(true);
                }
                break;
            default:
                Debug.Log("レベル間違ってます");
                break;
        }
        if (HP <= 0)
        {
            gameOver = true;
            GameOver.SetActive(true);
        }
    }

    public void correct()
    {
        transactionsNum++;
    }

    public void incorrect()
    {
        HP--;
    }
}
