using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscUI : MonoBehaviour
{
    [SerializeField] GameObject EscPanel;
    [SerializeField] AudioSource _audio;//BGM
    private bool wake = false;
    private bool once = true;
    // Start is called before the first frame update
    void Start()
    {
        EscPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            wake = !wake;
        }
        if (wake)
        {
            EscPanel.SetActive(true);
            Time.timeScale = 0f;
            _audio.Pause();
            once = true;
        }
        else
        {
            if (once)
            {
                Time.timeScale = 1.0f;
                _audio.UnPause();
                once = false;
            }
            EscPanel.SetActive(false);
        }
    }
}
