using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HiyokoMove : MonoBehaviour
{
    private enum State{
        Normal,
        Pick,
        Put,
        Die,
        Finish
    }
    State state;

    Rigidbody2D _rigidbody;
    SpriteRenderer _spriteRenderer;

    private float speed = 1.0f;

    public Sprite _Yellow1;
    public Sprite _Yellow2;
    [SerializeField] Sprite _White1;
    [SerializeField] Sprite _White2;
    private float turnSpeed = 0.4f;//画像の切り替え速度
    public bool White = false;//HiyokoInformationで変更
    public bool Sound = false;

    private Vector3 rememberVelocity;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        float rnd = Random.Range(-2.0f, 2f);
        _spriteRenderer = GetComponent<SpriteRenderer>();

        if (transform.position.y > 2)
        {
            _rigidbody.velocity = new Vector3(rnd * speed, -speed, 0f);
        }else if(transform.position.y < -2)
        {
            _rigidbody.velocity = new Vector3(rnd * speed, speed, 0f);
        }
        else
        {
            if (transform.position.x > 2)
            {
                _rigidbody.velocity = new Vector3(-speed, rnd * speed, 0f);
            }
            else
            {
                _rigidbody.velocity = new Vector3(speed, rnd * speed, 0f);
            }
        }
        rememberVelocity = _rigidbody.velocity;

        StartCoroutine(WalkAnimation());
        state = State.Normal;
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }

    void Moving()
    {
        if (state == State.Normal || state == State.Finish)
        {
            if (_rigidbody.velocity.x > 0)
            {
                _spriteRenderer.flipX = true;
            }
            else
            {
                _spriteRenderer.flipX = false;
            }
        }else if (state == State.Pick)
        {
            _rigidbody.velocity = new Vector3(0, 0, 0);

        }else if (state == State.Put)
        {

        }
    }

    private IEnumerator WalkAnimation()
    {
        //yield break;
        if (White == false)
        {
            while (true)
            {
                if (State.Normal == state || state == State.Finish)
                {
                    turnSpeed = 0.4f;
                }
                else
                {
                    //yield break;
                    turnSpeed = 0.2f;
                }
                _spriteRenderer.sprite = _Yellow1;
                yield return new WaitForSeconds(turnSpeed);
                _spriteRenderer.sprite = _Yellow2;
                yield return new WaitForSeconds(turnSpeed);
            }
        }
        else
        {
            while (true)
            {
                if (State.Normal == state || state == State.Finish)
                {
                    turnSpeed = 0.4f;
                }
                else
                {
                    turnSpeed = 0.2f;
                }
                _spriteRenderer.sprite = _White1;
                yield return new WaitForSeconds(turnSpeed);
                _spriteRenderer.sprite = _White2;
                yield return new WaitForSeconds(turnSpeed);
            }
        }
    }

    private IEnumerator PickAnimtion()
    {
        transform.localScale = new Vector3(1.3f, 1.3f, 1f);
        while (true)
        {
            if (state != State.Pick)
            {
                this.transform.localRotation = new Quaternion(0, 0, 0, 0);
                transform.localScale = new Vector3(1f, 1f, 1f);
                yield break;
            }
            for (int i = 0; i < 12; i++)
            {
                if (i < 3)
                {
                    this.transform.Rotate(0, 0, 5);
                    yield return new WaitForSeconds(0.015f);
                }
                else if (3 <= i && i < 9)
                {
                    this.transform.Rotate(0, 0, -5);
                    yield return new WaitForSeconds(0.015f);
                }
                else
                {
                    this.transform.Rotate(0, 0, 5);
                    yield return new WaitForSeconds(0.015f);
                }
            }
        }
    }

    // クリックされたときに呼び出されるメソッド
    public void OnPointClick()
    {
        print($"オブジェクト {name} がクリックされたよ！");
        state = State.Pick;
        StartCoroutine(PickAnimtion());
    }

    // ドラッグされたときに呼び出されるメソッド
    public void OnPointDrug()
    {
        state = State.Pick;
        Vector3 position = Input.mousePosition;
        position.z = 1f;
        Vector3 screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);
        this.transform.position = screenToWorldPointPosition;
    }

    // ドロップされたときに呼び出されるメソッド
    public void OnPointDrop()
    {
        state = State.Put;
        this.gameObject.layer = 8;//CheckLayerに変更
        _rigidbody.velocity = rememberVelocity;
        StartCoroutine(WalkAnimation());
    }
}
