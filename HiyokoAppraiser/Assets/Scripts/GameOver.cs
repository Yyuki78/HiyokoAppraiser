using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject DontTouchPanel;
    [SerializeField] private GameObject GameOverText;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private Image _image1;
    [SerializeField] private Image _image2;
    [SerializeField] private Sprite _hiyokoImage1;
    [SerializeField] private Sprite _hiyokoImage2;
    [SerializeField] TextMeshProUGUI _levelText;
    // Start is called before the first frame update
    void Start()
    {
        GameOverText.SetActive(false);
        GameOverPanel.SetActive(false);
        DontTouchPanel.SetActive(true);
        int rnd = Random.Range(1, 3);
        switch (rnd)
        {
            case 1:
                _image1.sprite = _hiyokoImage1;
                _image2.sprite = _hiyokoImage2;
                break;
            case 2:
                _image2.sprite = _hiyokoImage1;
                _image1.sprite = _hiyokoImage2;
                break;
            default:
                Debug.Log("ランダム生成ミス");
                break;
        }

        if (GameManager.GameMode == 1)
        {
            if (GameManager.reachLevel >= 2)
            {
                _levelText.text = "レベル" + GameManager.reachLevel.ToString() + "から";
            }
            else
            {
                _levelText.text = "レベル1から";
            }
        }
        else if (GameManager.GameMode == 2)
        {
            if (GameManager.reachLevel2 >= 2)
            {
                _levelText.text = "レベル" + GameManager.reachLevel2.ToString() + "から";
            }
            else
            {
                _levelText.text = "レベル1から";
            }
        }
        else
        {
            if (GameManager.reachLevel3 >= 2)
            {
                _levelText.text = "レベル" + GameManager.reachLevel3.ToString() + "から";
            }
            else
            {
                _levelText.text = "レベル1から";
            }
        }
        
        

        StartCoroutine(GameOverCoroutine());
    }

    private IEnumerator GameOverCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        GameOverText.SetActive(true);
        yield return new WaitForSeconds(4.5f);
        GameOverPanel.SetActive(true);
    }
}
