using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Patterns;
using GameLoop;

namespace ObjectsActions
{
    [RequireComponent(typeof(PoolableObject))]
    public class PushToPoolWhenLose : MonoBehaviour
    {
        private PoolableObject _poolable;

        private void Awake()
        {
            _poolable = GetComponent<PoolableObject>();
        }

        private void Start()
        {
            GameLoop.GameLoop.Instance.OnGameLosed += OnPlayerLose;
        }

        private void OnPlayerLose()
        {
            _poolable.PushToPool();
        }
    }
}
