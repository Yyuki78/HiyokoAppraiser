using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameContinueButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.GameMode == 1)
        {
            if (GameManager.reachLevel <= 2)
            {
                this.gameObject.SetActive(false);
            }
            else
            {
                _text.text = "Lv" + GameManager.reachLevel.ToString() + "からスタート";
            }
        }
        else if (GameManager.GameMode == 2)
        {
            if (GameManager.reachLevel2 <= 2)
            {
                this.gameObject.SetActive(false);
            }
            else
            {
                _text.text = "Lv" + GameManager.reachLevel2.ToString() + "からスタート";
            }
        }
        else
        {
            if (GameManager.reachLevel3 <= 2)
            {
                this.gameObject.SetActive(false);
            }
            else
            {
                _text.text = "Lv" + GameManager.reachLevel3.ToString() + "からスタート";
            }
        }
    }
}
