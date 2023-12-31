using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField]
    private float _horizontalSpeed;

    [SerializeField]
    private float _maxVerticalSpeed;

    [SerializeField]
    private float _verticalAcceleration;

    private float _verticalSpeed;
    private bool _move;


    private void Awake()
    {
        if (Instance != null)
        {
            enabled = false;
            throw new System.Exception("Player already exists");
        }

        Instance = this;
    }

    private void Update()
    {
        if (!_move)
            return;

        Vector3 position = transform.position;

        MoveHorizontal(ref position);
        MoveVertical(ref position);

        transform.position = position;
    }

    private void MoveHorizontal(ref Vector3 position)
    {
        position += transform.right * _horizontalSpeed * Time.deltaTime;
    }

    private void MoveVertical(ref Vector3 position)
    {
        if (Input.GetMouseButton(0))
        {
            _verticalSpeed += _verticalAcceleration;
        }
        else
        {
            _verticalSpeed -= _verticalAcceleration;
        }

        _verticalSpeed = Mathf.Clamp(_verticalSpeed, -_maxVerticalSpeed, _maxVerticalSpeed);

        position += transform.up * _verticalSpeed * Time.deltaTime;
    }


    public void StopMoving()
    {
        _verticalSpeed = 0;
        _move = false;
    }

    public void StartMoving()
    {
        _move = true;
    }
}
