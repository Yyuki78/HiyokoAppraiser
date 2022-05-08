using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeModeUI : MonoBehaviour
{
    [SerializeField] int mode;

    [SerializeField] Image _image1;
    [SerializeField] Image _image2;
    [SerializeField] Image _image3;

    [SerializeField] Sprite _selectImage;
    [SerializeField] Sprite _notSelectImage;

    private void Start()
    {
        if (GameManager.GameMode == 1)
        {
            if (TitleManager.ClearEasy)
            {
                _image1.sprite = _notSelectImage;
                _image2.sprite = _selectImage;
                _image3.sprite = _notSelectImage;
            }
            else
            {
                _image1.sprite = _selectImage;
                _image2.sprite = _notSelectImage;
                _image3.sprite = _notSelectImage;
            }
        }
        else if(GameManager.GameMode == 2)
        {
            if (TitleManager.ClearNormal)
            {
                _image1.sprite = _notSelectImage;
                _image2.sprite = _notSelectImage;
                _image3.sprite = _selectImage;
            }
            else
            {
                _image1.sprite = _notSelectImage;
                _image2.sprite = _selectImage;
                _image3.sprite = _notSelectImage;
            }
        }
        else
        {
            _image1.sprite = _notSelectImage;
            _image2.sprite = _notSelectImage;
            _image3.sprite = _selectImage;
        }
    }

    public void OnClick()
    {
        switch (mode)
        {
            case 1:
                GameManager.GameMode = 1;
                _image1.sprite = _selectImage;
                _image2.sprite = _notSelectImage;
                _image3.sprite = _notSelectImage;
                break;
            case 2:
                GameManager.GameMode = 2;
                _image1.sprite = _notSelectImage;
                _image2.sprite = _selectImage;
                _image3.sprite = _notSelectImage;
                break;
            case 3:
                GameManager.GameMode = 3;
                _image1.sprite = _notSelectImage;
                _image2.sprite = _notSelectImage;
                _image3.sprite = _selectImage;
                break;
            default:
                Debug.Log("モード切替ミス");
                break;
        }
    }
}
