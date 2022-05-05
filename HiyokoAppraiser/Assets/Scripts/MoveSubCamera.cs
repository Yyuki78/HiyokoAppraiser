using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSubCamera : MonoBehaviour
{
    private Camera _camera;

    private float speed = 1.0f;
    private Vector3 position;
    private Vector3 screenToWorldPointPosition;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        position = Input.mousePosition;
        position.z = -0.5f;
        screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);
        _camera.transform.position = screenToWorldPointPosition;
        //_camera.transform.localPosition -= new Vector3(moveX, moveY, 0.0f);
    }
}
