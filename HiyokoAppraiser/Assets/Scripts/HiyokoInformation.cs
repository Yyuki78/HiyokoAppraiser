using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HiyokoInformation : MonoBehaviour
{
    private GameObject GameManager;
    private GameManager _manager;

    private HiyokoMove _move;

    [SerializeField] GameObject Hat;
    [SerializeField] TextMeshPro _numText;

    private int attribute1;
    private int attribute2;
    private int rnd1;
    private int rnd2;

    private int Number = 0;
    public int Ranch = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        _manager = GameManager.GetComponent<GameManager>();
        _move = GetComponent<HiyokoMove>();
        _numText = GetComponentInChildren<TextMeshPro>();

        attribute1 = Random.Range(1, 3);
        rnd1 = Random.Range(1, 3);
        rnd2 = Random.Range(1, 3);
        Number = Random.Range(1, 100);
        _numText.text = Number.ToString();

        switch (_manager.mode1)
        {
            case 1:
                if (attribute1 == 1)
                {
                    _move.White = false;
                }
                else
                {
                    _move.White = true;
                }
                if (rnd1 == 1)
                {
                    Hat.SetActive(true);
                }
                else
                {
                    Hat.SetActive(false);
                }
                if (rnd2 == 1)
                {
                    _move.Sound = true;
                }
                else
                {
                    _move.Sound = false;
                }
                break;
            case 2:
                if (rnd1 == 1)
                {
                    _move.White = true;
                }
                else
                {
                    _move.White = false;
                }
                if (attribute1 == 1)
                {
                    Hat.SetActive(true);
                }
                else
                {
                    Hat.SetActive(false);
                }
                if (rnd2 == 1)
                {
                    _move.Sound = true;
                }
                else
                {
                    _move.Sound = false;
                }
                break;
            case 3:
                if (rnd1 == 1)
                {
                    _move.White = true;
                }
                else
                {
                    _move.White = false;
                }
                if (rnd2 == 1)
                {
                    Hat.SetActive(true);
                }
                else
                {
                    Hat.SetActive(false);
                }
                if (attribute1 == 1)
                {
                    _move.Sound = true;
                }
                else
                {
                    _move.Sound = false;
                }
                break;
            default:
                Debug.Log("mode1設定に失敗");
                break;
        }
        switch (_manager.mode2)
        {
            case 1:
                if (Number % 2 == 0)
                {
                    attribute2 = 1;
                }
                else
                {
                    attribute2 = 2;
                }
                break;
            case 2:
                if (Number == 2)
                {
                    attribute2 = 1;
                    break;
                }
                for (int i = 2; i < Number; ++i)
                {
                    if (Number % i == 0)
                    {
                        attribute2 = 2;
                        break;
                    }
                    attribute2 = 1;
                }
                break;
            case 3:
                if (Number >= 50)
                {
                    attribute2 = 1;
                }
                else
                {
                    attribute2 = 2;
                }
                break;
            default:
                Debug.Log("mode2設定に失敗");
                break;
        }

        //判定用
        if (attribute1 == 1)
        {
            if (attribute2 == 1)
            {
                Ranch = 1;
            }
            else
            {
                Ranch = 2;
            }
        }
        else
        {
            if (attribute2 == 1)
            {
                Ranch = 3;
            }
            else
            {
                Ranch = 4;
            }
        }
    }
}
