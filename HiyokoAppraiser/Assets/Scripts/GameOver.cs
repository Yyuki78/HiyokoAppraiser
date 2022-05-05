using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject GameOverText;
    [SerializeField] private GameObject GameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        GameOverText.SetActive(false);
        GameOverPanel.SetActive(false);
        StartCoroutine(GameOverCoroutine());
    }

    private IEnumerator GameOverCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        GameOverText.SetActive(true);
        yield return new WaitForSeconds(3f);
        GameOverPanel.SetActive(true);
    }
}
