using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Patterns;
using GameLoop;

namespace Spawners
{
    public class ItemsSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject _itemPrefab;

        [SerializeField]
        private float _minSpawnDistance;

        [SerializeField]
        private float _maxSpawnDistance;

        [SerializeField]
        private float _minHeight;

        [SerializeField]
        private float _maxHeight;

        private Transform _player;
        private ObjectsPool _pool;
        private float _lastSpawnPositionX;

        private void Start()
        {
            _player = Player.Instance.transform;

            _pool = new ObjectsPool(new ItemsProvider(this));

            GameLoop.GameLoop.Instance.OnGameStarted += OnGameStarted;
        }

        private void Update()
        {
            if (_player.transform.position.x > _lastSpawnPositionX)
                SpawnItem();
        }


        private void OnGameStarted()
        {
            _lastSpawnPositionX = 0;
            SpawnItem();
        }

        private void SpawnItem()
        {
            GameObject go = _pool.GetInstance().gameObject;

            float offset = Random.Range(_minSpawnDistance, _maxSpawnDistance);

            Vector3 position = new Vector3(
                _player.transform.position.x + offset, 
                Random.Range(_minHeight, _maxHeight));

            go.transform.position = position;

            _lastSpawnPositionX = position.x;
        }


        private class ItemsProvider : IPoolableObjectsProvider
        {
            public ItemsSpawner _controller;

            public ItemsProvider(ItemsSpawner controller)
            {
                _controller = controller;
            }

            public PoolableObject CreateNew()
            {
                GameObject go = Instantiate(_controller._itemPrefab);

                return go.GetComponent<PoolableObject>();
            }
        }
    }
}