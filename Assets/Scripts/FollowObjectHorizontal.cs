using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObjectHorizontal : MonoBehaviour
{
    [SerializeField]
    private Transform _ancor;

    private float _offsetX;

    private void Start()
    {
        _offsetX = transform.position.x - _ancor.transform.position.x;
    }

    private void LateUpdate()
    {
        Vector3 position = transform.position;

        position.x = _ancor.transform.position.x + _offsetX;
        
        transform.position = position;
    }
}
