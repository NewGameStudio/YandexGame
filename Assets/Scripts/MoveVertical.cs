using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVertical : MonoBehaviour
{
    public float Distance
    {
        get
        {
            return _distance;
        }

        set
        {
            _distance = Mathf.Max(0.1f, value);
        }
    }
    public float Speed
    {
        get
        {
            return _speed;
        }

        set
        {
            _speed = Mathf.Max(0, value);
        }
    }

    [SerializeField]
    private float _distance;

    [SerializeField]
    private float _speed;

    private void Update()
    {
        Vector3 localPosition = transform.localPosition;

        localPosition.y = Mathf.Sin(Time.time * _speed) * _distance;

        transform.localPosition = localPosition;
    }
}
