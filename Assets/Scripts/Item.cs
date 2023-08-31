using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private Transform _player;

    [SerializeField]
    private float _activeDistance;

    [SerializeField]
    private float _speed;

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, _player.transform.position);

        if (distance < _activeDistance)
        {
            transform.position = Vector3.Lerp(transform.position, _player.transform.position, 
                _speed * Time.deltaTime);
        }
    }
}
