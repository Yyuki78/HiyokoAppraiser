using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TermsDisplay : MonoBehaviour
{
    private GameObject GameManager;
    private GameManager _manager;

    [SerializeField] GameObject TermsUI1;
    [SerializeField] GameObject TermsUI2;
    [SerializeField] GameObject TermsUI3;
    [SerializeField] GameObject TermsUI4;
    private TextMeshProUGUI _text1;
    private TextMeshProUGUI _text2;
    private TextMeshProUGUI _text3;
    private TextMeshProUGUI _text4;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        _manager = GameManager.GetComponent<GameManager>();

        _text1 = TermsUI1.GetComponent<TextMeshProUGUI>();
        _text2 = TermsUI2.GetComponent<TextMeshProUGUI>();
        _text3 = TermsUI3.GetComponent<TextMeshProUGUI>();
        _text4 = TermsUI4.GetComponent<TextMeshProUGUI>();

        switch (_manager.mode1)
        {
            case 1:
                _text1.text = "色が黄色\n";
                _text2.text = "色が黄色\n";
                _text3.text = "色が白色\n";
                _text4.text = "色が白色\n";
                break;
            case 2:
                _text1.text = "帽子がある\n";
                _text2.text = "帽子がある\n";
                _text3.text = "帽子がない\n";
                _text4.text = "帽子がない\n";
                break;
            case 3:
                _text1.text = "掴んだ際音が出る\n";
                _text2.text = "掴んだ際音が出る\n";
                _text3.text = "掴んだ際音が出ない\n";
                _text4.text = "掴んだ際音が出ない\n";
                break;
            default:
                Debug.Log("Text表示に失敗");
                break;
        }

        switch (_manager.mode2)
        {
            case 1:
                _text1.text += "数字が偶数";
                _text2.text += "数字が奇数";
                _text3.text += "数字が偶数";
                _text4.text += "数字が奇数";
                break;
            case 2:
                _text1.text += "数字が素数";
                _text2.text += "数字が合成数";
                _text3.text += "数字が素数";
                _text4.text += "数字が合成数";
                break;
            case 3:
                _text1.text += "数字が50以上";
                _text2.text += "数字が50未満";
                _text3.text += "数字が50以上";
                _text4.text += "数字が50未満";
                break;
            default:
                Debug.Log("Text表示に失敗");
                break;
        }
    }
}
