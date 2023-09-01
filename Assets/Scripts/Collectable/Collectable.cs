using System;
using System.Collections.Generic;
using UnityEngine;
using Patterns;

namespace Collectable
{
    [RequireComponent(typeof(PoolableObject))]
    public class Collectable : MonoBehaviour
    {
        public static Action OnCollected;

        [SerializeField]
        private float _collectDistance = 0.2f;

        private GameObject _player;
        private PoolableObject _poolable;

        private void Start()
        {
            _player = Player.Instance.gameObject;
            _poolable = GetComponent<PoolableObject>();
        }

        private void Update()
        {
            float distance = Vector3.Distance(transform.position, _player.transform.position);

            if (distance < _collectDistance)
            {
                OnCollected?.Invoke();

                _poolable.PushToPool();
            }
        }
    }
}