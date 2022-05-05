using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStartUI : MonoBehaviour
{
    //ゲーム開始時のUI表示
    private int level;
    private GameObject GameManagerr;
    private GameManager _manager;

    [SerializeField] private TextMeshProUGUI _start;
    [SerializeField] private TextMeshProUGUI _terms;

    // Start is called before the first frame update
    void Start()
    {
        level = GameManager.currentLevel;
        GameManagerr = GameObject.FindGameObjectWithTag("GameManager");
        _manager = GameManagerr.GetComponent<GameManager>();

        switch (_manager.mode1)
        {
            case 1:
                _terms.text = "黄色か白色か\n";
                break;
            case 2:
                _terms.text = "帽子があるかないか\n";
                break;
            case 3:
                _terms.text = "掴んだ際に音が鳴るか\n";
                break;
            default:
                Debug.Log("開始文の設定1に失敗");
                break;
        }

        _terms.text += "+\n";

        switch (_manager.mode2)
        {
            case 1:
                _terms.text += "数字が偶数か奇数か";
                break;
            case 2:
                _terms.text += "数字が素数か合成数か";
                break;
            case 3:
                _terms.text += "数字が50以上か未満か";
                break;
            default:
                Debug.Log("開始文の設定2に失敗");
                break;
        }

        Invoke(nameof(SetActive), 3f);
    }

    private void SetActive()
    {
        this.gameObject.SetActive(false);
    }
}
