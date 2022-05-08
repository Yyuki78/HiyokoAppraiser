using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButtons : MonoBehaviour
{
    [SerializeField] int mode;//ボタンの機能

    [SerializeField] GameObject ChangeImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnClick()
    {
        StartCoroutine(SceneChange());
    }

    private IEnumerator SceneChange()
    {
        ChangeImage.SetActive(true);
        ChangeImage.transform.localScale = new Vector3(0, 0, 0);
        for (int i = 0; i < 50; i++)
        {
            ChangeImage.transform.localScale += new Vector3(1f, 1f, 0);
            yield return new WaitForSeconds(0.003f);
        }
        switch (mode)
        {
            case 1:
                SceneManager.LoadScene("TitleScene");
                break;
            case 2:
                if (GameManager.GameMode == 1)
                {
                    GameManager.currentLevel -= 2;
                }
                else if (GameManager.GameMode == 2)
                {
                    GameManager.currentLevel2 -= 2;
                }
                else
                {
                    GameManager.currentLevel3 -= 2;
                }
                GameManager.FirstLevel = true;
                SceneManager.LoadScene("SampleScene");
                break;
            default:
                Debug.Log("ボタンミス");
                break;
        }
    }
}
