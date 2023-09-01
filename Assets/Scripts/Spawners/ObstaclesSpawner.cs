using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Patterns;
using Collectable;
using ObjectsActions;
using GameLoop;

namespace Spawners
{
    public class ObstaclesSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject _obstaclePrefab;

        [SerializeField]
        private CollectablesCounter _collectablesCounter;

        [SerializeField]
        private float _minSpawnDistance;

        [SerializeField]
        private float _maxSpawnDistance;

        [SerializeField]
        private float _minHeight;

        [SerializeField]
        private float _maxHeight;

        [SerializeField]
        private float _minObstaclesSpeed;

        [SerializeField]
        private float _maxObstaclesSpeed;

        [SerializeField]
        private float _minObstaclesMoveDistance;

        [SerializeField]
        private float _maxObstaclesMoveDistance;

        [SerializeField]
        private int _minObstaclesCount = 1;

        [SerializeField]
        private int _maxObstaclesCount = 6;

        [SerializeField]
        private float _distanceBetweenObstacles = 0.5f;

        private Transform _player;
        private ObjectsPool _pool;
        private float _lastSpawnPositionX;


        private void Start()
        {
            _player = Player.Instance.transform;

            _pool = new ObjectsPool(new ObstaclesProvider(this));

            GameLoop.GameLoop.Instance.OnGameStarted += OnGameStarted;
        }

        private void Update()
        {
            if (_player.transform.position.x > _lastSpawnPositionX)
                SpawnObstacle();
        }


        private void OnGameStarted()
        {
            _lastSpawnPositionX = 0;
            SpawnObstacle();
        }

        private void SpawnObstacle()
        {
            int count = _collectablesCounter.CollectedCount / 2;
            count = Mathf.Clamp(count, _minObstaclesCount, _maxObstaclesCount);

            float offset = Random.Range(_minSpawnDistance, _maxSpawnDistance);
            float spawnOrigin = _lastSpawnPositionX + offset;

            for (int i = 0; i < count; i++)
            {
                GameObject go = _pool.GetInstance().gameObject;

                Vector3 spawnPosition = new Vector3(
                    spawnOrigin + _distanceBetweenObstacles * i,
                    Random.Range(_minHeight, _maxHeight));

                go.transform.position = spawnPosition;

                _lastSpawnPositionX = spawnPosition.x;
            }
        }


        private class ObstaclesProvider : IPoolableObjectsProvider
        {
            public ObstaclesSpawner _spawner;

            public ObstaclesProvider(ObstaclesSpawner spawner)
            {
                _spawner = spawner;
            }

            public PoolableObject CreateNew()
            {
                GameObject go = Instantiate(_spawner._obstaclePrefab.gameObject);

                MoveVertical moveVertical = go.GetComponentInChildren<MoveVertical>();

                moveVertical.Speed = Random.Range(_spawner._minObstaclesSpeed, _spawner._maxObstaclesSpeed);
                moveVertical.Distance = Random.Range(_spawner._minObstaclesMoveDistance, _spawner._maxObstaclesMoveDistance);

                return go.GetComponent<PoolableObject>();
            }
        }
    }
}