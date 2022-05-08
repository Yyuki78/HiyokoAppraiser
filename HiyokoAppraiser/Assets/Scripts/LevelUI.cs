using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] TextMeshProUGUI _modeText;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.GameMode == 1)
        {
            _text.text = "レベル" + GameManager.currentLevel.ToString();
            _modeText.text = "イージー";
        }
        else if (GameManager.GameMode == 2)
        {
            _text.text = "レベル" + GameManager.currentLevel2.ToString();
            _modeText.text = "ノーマル";
        }
        else
        {
            _text.text = "レベル" + GameManager.currentLevel3.ToString();
            _modeText.text = "ハード";
        }
    }
}
