using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameSettingUI : MonoBehaviour
{
    [SerializeField] GameObject TutrilaPanel;
    [SerializeField] GameObject CreditPanel;
    [SerializeField] GameObject TutrialButton;

    // Start is called before the first frame update
    void Start()
    {
        if (TitleManager.FirstTime)
        {
            TutrialButton.SetActive(false);
        }
        TutrilaPanel.SetActive(false);
        CreditPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickQuit()
    {
        this.gameObject.SetActive(false);
    }

    public void OnClickTutrial()
    {
        TutrilaPanel.SetActive(true);
    }

    public void OnClickCredit()
    {
        CreditPanel.SetActive(true);
    }

    public void OnClickQuitCredit()
    {
        CreditPanel.SetActive(false);
    }
}
