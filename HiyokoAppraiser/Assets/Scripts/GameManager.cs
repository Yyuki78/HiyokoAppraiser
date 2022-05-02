using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int currentLevel;
    public static int reachLevel;

    public int mode1, mode2;
    //1.色2.帽子3.音
    //1.偶数2.素数3.以上

    // Start is called before the first frame update
    void Awake()
    {
        currentLevel += 1;
        mode1 = Random.Range(1, 4);
        mode2 = Random.Range(1, 4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
