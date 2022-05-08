using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeChangeUI : MonoBehaviour
{
    [SerializeField] GameObject _selectImage;
    // Start is called before the first frame update
    void Start()
    {
        switch (GameManager.HiyokoSize)
        {
            case 1:
                _selectImage.transform.localPosition = new Vector3(-100, 100, 0);
                break;
            case 2:
                _selectImage.transform.localPosition = new Vector3(50, 100, 0);
                break;
            case 3:
                _selectImage.transform.localPosition = new Vector3(200, 100, 0);
                break;
            default:
                Debug.Log("サイズ設定ミス");
                break;
        }
    }

    public void OnClick1()
    {
        _selectImage.transform.localPosition = new Vector3(-100, 100, 0);
        GameManager.HiyokoSize = 1;
    }

    public void OnClick2()
    {
        _selectImage.transform.localPosition = new Vector3(50, 100, 0);
        GameManager.HiyokoSize = 2;
    }

    public void OnClick3()
    {
        _selectImage.transform.localPosition = new Vector3(200, 100, 0);
        GameManager.HiyokoSize = 3;
    }
}
