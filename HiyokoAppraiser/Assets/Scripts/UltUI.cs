using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UltUI : MonoBehaviour
{
    [SerializeField] GameObject notOKimage;
    [SerializeField] TextMeshProUGUI _Ultext;//UltUIText

    [SerializeField] GameObject UltBG;
    [SerializeField] GameObject UltImage;
    [SerializeField] TextMeshProUGUI _text;//UltText
    [SerializeField] TextMeshProUGUI _text2;//UltText
    [SerializeField] GameObject timer;//UltTimerText GameObj
    [SerializeField] TextMeshProUGUI _timerText;//UltTimerText

    private float limit = 0f;
    private bool time = false;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.UltCan)
        {
            notOKimage.SetActive(false);
            _Ultext.text = "必殺技\n使用可能";
        }
        else
        {
            notOKimage.SetActive(true);
            _Ultext.text = "必殺技\n使用不可";
        }
        UltBG.SetActive(false);
        UltImage.SetActive(false);
        timer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.usingUlt == true)
        {
            GameManager.usingUlt = false;
            StartCoroutine(useUlt());
        }

        if (time)
        {
            /*
            timer.SetActive(true);
            switch (GameManager.UltType)
            {
                case 1:
                    limit = 4f;
                    break;
                case 2:
                    time = false;
                    this.gameObject.SetActive(false);
                    break;
                case 3:
                    limit = 3f;
                    break;
            }
            _timerText.text = limit.ToString("0.00");
            limit -= Time.deltaTime;
            if (limit <= 0)
            {
                time = false;
                this.gameObject.SetActive(false);
            }*/
        }
    }

    private IEnumerator useUlt()
    {
        UltBG.SetActive(true);
        switch (GameManager.UltType)
        {
            case 1:
                _text.text = "ディレイ";
                _text2.text = "ゲーム速度が遅くなる";
                break;
            case 2:
                _text.text = "ヒール";
                _text2.text = "HPを全回復する";
                break;
            case 3:
                _text.text = "バニッシュ";
                _text2.text = "ひよこが数匹消える";
                break;
        }
        UltImage.transform.localPosition = new Vector3(1052f, -106f, 0);
        UltImage.SetActive(true);
        for (int i = 0; i < 20; i++)
        {
            UltImage.transform.localPosition -= new Vector3(50f, 0, 0);
            yield return new WaitForSeconds(0.001f);
        }
        yield return new WaitForSeconds(0.08f);
        for (int i = 0; i < 20; i++)
        {
            UltImage.transform.localPosition -= new Vector3(50f, 0, 0);
            yield return new WaitForSeconds(0.001f);
        }
        UltImage.SetActive(false);
        UltBG.SetActive(false);
        time = true;
        yield return new WaitForSeconds(0.1f);
        notOKimage.SetActive(true);
        _Ultext.text = "必殺技\n使用不可";
        
        yield break;
    }
}
