using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Patterns;

namespace ObjectsActions
{
    [RequireComponent(typeof(PoolableObject))]
    public class PushToPoolWhenFar : MonoBehaviour
    {
        [SerializeField]
        private float _destroyDistance = 4f;

        private Transform _player;
        private PoolableObject _poolable;

        private void Start()
        {
            _player = Player.Instance.transform;
            _poolable = GetComponent<PoolableObject>();
        }

        private void LateUpdate()
        {
            Vector3 position = transform.position;
            Vector3 playerPosition = _player.transform.position;

            float distance = playerPosition.x - position.x;

            if (distance < _destroyDistance)
                return;

            _poolable.PushToPool();
        }
    }
}