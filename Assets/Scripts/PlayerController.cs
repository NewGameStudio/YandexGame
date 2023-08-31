using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _horizontalSpeed;

    [SerializeField]
    private float _fallSpeed;

    [SerializeField]
    private float _liftSpeed;

    private void Update()
    {
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
            position += transform.up * _liftSpeed * Time.deltaTime;
        }
        else
        {
            position -= transform.up * _fallSpeed * Time.deltaTime;
        }
    }
}