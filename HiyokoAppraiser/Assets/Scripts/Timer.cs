using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private bool StartCoundDown = false;
    private TextMeshProUGUI _timer;

    private float limit = 40;
    // Start is called before the first frame update
    void Start()
    {
        _timer = GetComponent<TextMeshProUGUI>();
        Invoke(nameof(StartCD), 3f);
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
