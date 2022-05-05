using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HiyokoMove : MonoBehaviour
{
    private enum State
    {
        Normal,
        Pick,
        Put,
        Die,
        Finish
    }
    State state;

    Rigidbody2D _rigidbody;
    SpriteRenderer _spriteRenderer;
    [SerializeField] Gradient _gradient;

    //子オブジェクト
    [SerializeField] GameObject Hat;
    [SerializeField] GameObject Number;

    private float speed = 1.0f;

    public Sprite _Yellow1;
    public Sprite _Yellow2;
    [SerializeField] Sprite _White1;
    [SerializeField] Sprite _White2;
    private float turnSpeed = 0.4f;//画像の切り替え速度
    public bool White = false;//HiyokoInformationで変更
    public bool Sound = false;

    private Vector3 rememberVelocity;
    private bool timeOver = false;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        float rnd = Random.Range(-2.0f, 2f);
        _spriteRenderer = GetComponent<SpriteRenderer>();

        if (transform.position.y > 2)
        {
            _rigidbody.velocity = new Vector3(rnd * speed, -speed, 0f);
        }
        else if (transform.position.y < -2)
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
        StartCoroutine(LifeOver());

        state = State.Normal;
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
        LifeTime();
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
        }
        else if (state == State.Pick)
        {
            _rigidbody.velocity = new Vector3(0, 0, 0);

        }
        else if (state == State.Put)
        {

        }
    }

    void LifeTime()
    {
        if (timeOver == false) return;
        if (state != State.Normal) return;
        incorrect();
    }

    //歩行アニメーション
    private IEnumerator WalkAnimation()
    {
        //yield break;
        yield return new WaitForSeconds(0.01f);
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

    //掴んだ時のアニメーション
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
        if (state == State.Finish || state == State.Die) return;
        print($"オブジェクト {name} がクリックされたよ！");
        state = State.Pick;
        Hat.gameObject.layer = 9;
        Number.gameObject.layer = 9;
        this.gameObject.layer = 9;
        StartCoroutine(PickAnimtion());
    }

    // クリックのみで終わったときに呼び出されるメソッド
    public void OnPointClickEnd()
    {
        if (state == State.Finish || state == State.Die) return;
        state = State.Normal;
        Hat.gameObject.layer = 0;
        Number.gameObject.layer = 0;
        this.gameObject.layer = 0;
        StopCoroutine(PickAnimtion());
    }

    // ドラッグされたときに呼び出されるメソッド
    public void OnPointDrug()
    {
        if (state == State.Finish || state == State.Die) return;
        state = State.Pick;
        Hat.gameObject.layer = 9;
        this.gameObject.layer = 9;
        Number.gameObject.layer = 9;
        Vector3 position = Input.mousePosition;
        position.z = 1f;
        Vector3 screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);
        this.transform.position = screenToWorldPointPosition;
    }

    // ドロップされたときに呼び出されるメソッド
    public void OnPointDrop()
    {
        if (state == State.Finish || state == State.Die) return;
        state = State.Put;
        Hat.gameObject.layer = 0;
        Number.gameObject.layer = 0;
        this.gameObject.layer = 8;//CheckLayerに変更
        _rigidbody.velocity = rememberVelocity;
        StartCoroutine(checkTime());
    }

    //判定がされなかった際にNormalに戻す
    private IEnumerator checkTime()
    {
        yield return new WaitForSeconds(1f);
        if (state == State.Finish || state == State.Die) yield break;
        state = State.Normal;
    }

    //判定成功時に呼ばれる
    public void correct()
    {
        if (state == State.Finish || state == State.Die) return;
        state = State.Finish;
        this.gameObject.layer = 0;
        Debug.Log("正解!!!");
    }

    //判定失敗時に呼ばれる
    public void incorrect()
    {
        if (state == State.Finish || state == State.Die) return;
        state = State.Die;
        this.gameObject.layer = 0;
        _rigidbody.velocity = new Vector3(0, 0, 0);
        StopCoroutine(DieEffect());
        StartCoroutine(DieEffect());
        Debug.Log("不正解");
    }

    //死亡時の演出
    private IEnumerator DieEffect()
    {
        if (state != State.Die) yield break;
        for (int i = 0; i < 100; i++)
        {
            var timeRate = Mathf.Min(1f, (i % 100) / 100.0f);
            _spriteRenderer.color = _gradient.Evaluate(timeRate);
            if (i % 30 < 15)
            {
                transform.localScale += new Vector3(0.035f, 0.035f, 0f);
            }
            else
            {
                transform.localScale -= new Vector3(0.03f, 0.03f, 0f);
            }
            yield return new WaitForSeconds(0.01f);
        }
        if (_spriteRenderer.flipX == false)
        {
            for (int i = 0; i < 90; i++)
            {
                this.transform.Rotate(0, 0, 1);
                transform.localScale -= new Vector3(0.02f, 0.02f, 0f);
                if (transform.localScale.x < 0) break;
                yield return new WaitForSeconds(0.02f);
            }
        }
        else
        {
            for (int i = 0; i < 90; i++)
            {
                this.transform.Rotate(0, 0, -1);
                transform.localScale -= new Vector3(0.02f, 0.02f, 0f);
                if (transform.localScale.x < 0) break;
                yield return new WaitForSeconds(0.02f);
            }
        }

        GameManager.transactionsNum++;

        Destroy(this.gameObject);
        yield break;
    }

    //生まれてからの制限時間
    private IEnumerator LifeOver()
    {
        yield return new WaitForSeconds(8f);
        StartCoroutine(overTime());
        if (state != State.Normal) yield break;
        for (int i = 0; i < 100; i++)
        {
            if (i % 30 < 15)
            {
                transform.localScale += new Vector3(0.03f, 0.03f, 0f);
            }
            else
            {
                transform.localScale -= new Vector3(0.03f, 0.03f, 0f);
            }
            yield return new WaitForSeconds(0.02f);
        }
        transform.localScale = new Vector3(1f, 1f, 1f);
        timeOver = true;
        yield break;
    }
    private IEnumerator overTime()
    {
        if (state == State.Finish) yield break;
        yield return new WaitForSeconds(4f);
        if (state == State.Finish) yield break;
        timeOver = true;
    }
}