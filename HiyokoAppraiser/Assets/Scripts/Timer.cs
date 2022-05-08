using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private bool StartCoundDown = false;
    private TextMeshProUGUI _timer;

    private float limit = 43;
    // Start is called before the first frame update
    void Start()
    {
        _timer = GetComponent<TextMeshProUGUI>();
        if (GameManager.GameMode == 1)
        {
            limit = 10;
        }
        else if (GameManager.GameMode == 2)
        {
            limit = 43;
        }
        else
        {
            limit = 43;
        }
        Invoke(nameof(StartCD), 4f);
    }

    // Update is called once per frame
    void Update()
    {
        _timer.text = limit.ToString("00.0");
        if (StartCoundDown == true && limit > 0)
        {
            limit -= Time.deltaTime;
        }
    }

    private void StartCD()
    {
        StartCoundDown = true;
    }
}
