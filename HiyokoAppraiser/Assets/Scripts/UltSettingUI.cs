using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UltSettingUI : MonoBehaviour
{
    [SerializeField] int bottonMode;

    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] GameObject _selectImage;
    // Start is called before the first frame update
    void Start()
    {
        switch (GameManager.UltType)
        {
            case 1:
                _text.text = "1秒間ゲーム速度が0.25倍になる";
                _selectImage.transform.localPosition = new Vector3(-100, 0, 0);
                break;
            case 2:
                _text.text = "HPが全回復する";
                _selectImage.transform.localPosition = new Vector3(50, 0, 0);
                break;
            case 3:
                _text.text = "仕分け前のひよこがランダムで数匹消える";
                _selectImage.transform.localPosition = new Vector3(200, 0, 0);
                break;
            default:
                Debug.Log("ウルト設定ミス");
                break;
        }
    }

    public void Onclick()
    {
        switch (bottonMode)
        {
            case 1:
                GameManager.UltType = 1;
                _text.text = "1秒間ゲーム速度が0.25倍になる";
                _selectImage.transform.localPosition = new Vector3(-100, 0, 0);
                break;
            case 2:
                GameManager.UltType = 2;
                _text.text = "HPが全回復する";
                _selectImage.transform.localPosition = new Vector3(50, 0, 0);
                break;
            case 3:
                GameManager.UltType = 3;
                _text.text = "仕分け前のひよこがランダムで数匹消える";
                _selectImage.transform.localPosition = new Vector3(200, 0, 0);
                break;
            default:
                break;
        }
    }
}
