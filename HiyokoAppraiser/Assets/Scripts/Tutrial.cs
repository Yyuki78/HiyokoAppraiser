using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutrial : MonoBehaviour
{
    [SerializeField] GameObject Text1;
    [SerializeField] GameObject Text2;
    [SerializeField] GameObject Text3;
    [SerializeField] GameObject Text4;
    //[SerializeField] GameObject Images;
    [SerializeField] GameObject Button1;
    [SerializeField] GameObject Button2;

    [SerializeField] GameObject BGImage;
    [SerializeField] GameObject SmallerImage;

    private int ClickNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        Text1.SetActive(true);
        Text2.SetActive(false);
        Text3.SetActive(false);
        Text4.SetActive(false);
        //Images.SetActive(false);
        Button1.SetActive(true);
        Button2.SetActive(false);
    }

    public void OnClickNext()
    {
        switch (ClickNum)
        {
            case 0:
                ClickNum++;
                Text1.SetActive(false);
                Text2.SetActive(true);
                break;
            case 1:
                ClickNum++;
                Text2.SetActive(false);
                Text3.SetActive(true);
                //Images.SetActive(true);
                break;
            case 2:
                ClickNum++;
                Text3.SetActive(false);
                Text4.SetActive(true);
                //Images.SetActive(false);
                Button1.SetActive(false);
                Button2.SetActive(true);
                break;
            case 3:
                ClickNum = 0;
                StartCoroutine(StartGame());
                break;
            default:
                Debug.Log("チュートリアルミス");
                break;
        }
    }

    private IEnumerator StartGame()
    {
        if (TitleManager.FirstTime)
        {
            TitleManager.FirstTime = false;
            SmallerImage.SetActive(true);
            BGImage.SetActive(true);
            yield return new WaitForSeconds(0.01f);
            Text4.SetActive(false);
            Text1.SetActive(true);
            Button1.SetActive(true);
            Button2.SetActive(false);
            yield return new WaitForSeconds(0.01f);
            for (int i = 0; i < 49; i++)
            {
                SmallerImage.transform.localScale -= new Vector3(1f, 1f, 0);
                yield return new WaitForSeconds(0.005f);
            }
            GameManager.FirstLevel = true;
            GameManager.GameMode = 1;
            GameManager.currentLevel = 0;
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            Text4.SetActive(false);
            Text1.SetActive(true);
            Button1.SetActive(true);
            Button2.SetActive(false);
            this.gameObject.SetActive(false);
        }
        yield break;
    }
}
