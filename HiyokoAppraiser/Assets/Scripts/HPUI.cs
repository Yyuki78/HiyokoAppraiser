using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPUI : MonoBehaviour
{
    [SerializeField] GameObject HP1;
    [SerializeField] GameObject HP2;
    [SerializeField] GameObject HP3;
    // Start is called before the first frame update
    void Start()
    {
        HP1.SetActive(false);
        HP2.SetActive(false);
        HP3.SetActive(false);
        if (GameManager.HP == 1)
        {
            HP1.SetActive(true);
        }
        else if(GameManager.HP == 2)
        {
            HP1.SetActive(true);
            HP2.SetActive(true);
        }
        else
        {
            HP1.SetActive(true);
            HP2.SetActive(true);
            HP3.SetActive(true);
        }
    }

    private void Update()
    {
        if (GameManager.HP == 1)
        {
            HP2.SetActive(false);
        }
        else if (GameManager.HP == 2)
        {
            HP3.SetActive(false);
        }
        else if(GameManager.HP == 3)
        {
            HP1.SetActive(true);
            HP2.SetActive(true);
            HP3.SetActive(true);
        }
        else
        {
            HP1.SetActive(false);
            HP2.SetActive(false);
            HP3.SetActive(false);
        }
    }
}
