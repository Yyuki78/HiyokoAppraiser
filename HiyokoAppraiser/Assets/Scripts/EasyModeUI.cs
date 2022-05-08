using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EasyModeUI : MonoBehaviour
{
    //レベルごとにテキストを表示する

    [SerializeField] TextMeshProUGUI _text;

    private GameObject GameManagerr;
    private GameManager _manager;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.GameMode != 1)
        {
            this.gameObject.SetActive(false);
        }
        if (this.gameObject.activeSelf == false) return;
        GameManagerr = GameObject.FindGameObjectWithTag("GameManager");
        _manager = GameManagerr.GetComponent<GameManager>();

        Invoke(nameof(text), 4f);
    }

    private void Update()
    {
        if (_manager.gameClear)
        {
            this.gameObject.SetActive(false);
        }
    }

    void text()
    {
        switch (GameManager.currentLevel)
        {
            case 1:
                _text.text = "ひよこを掴んで\n草のエリアに移動させましょう";
                break;
            case 2:
                _text.text = "ひよこを掴んで\n草のエリアに移動させましょう";
                break;
            case 3:
                _text.text = "条件は様々な種類があります";
                break;
            case 4:
                _text.text = "音は掴んでいる間出続けます";
                break;
            case 5:
                _text.text = "合成数とは\n素数以外の数のことです";
                break;
            default:
                break;
        }
    }
}
