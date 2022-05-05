using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiyokoRanch : MonoBehaviour
{
    [SerializeField]private int RanchNum;

    private GameObject GameManager;
    private GameManager _manager;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        _manager = GameManager.GetComponent<GameManager>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer != 8) return;
        var hi = collision.gameObject.GetComponent<HiyokoInformation>();
        var hm = collision.gameObject.GetComponent<HiyokoMove>();
        if (hi.Ranch == RanchNum)
        {
            _manager.correct();
            hm.correct();
        }
        else
        {
            _manager.incorrect();
            hm.incorrect();
        }
    }
}
