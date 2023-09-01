using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameLoop;

namespace Collectable
{
    public class CollectablesCounter : MonoBehaviour
    {
        public int CollectedCount { get; private set; }

        private void Start()
        {
            Collectable.OnCollected += OnItemCollected;
            GameLoop.GameLoop.Instance.OnGameStarted += OnGameStarted;
            GameLoop.GameLoop.Instance.OnGameLosed += OnPlayerLosed;
        }

        public void OnItemCollected()
        {
            CollectedCount++;
        }

        public void OnGameStarted()
        {
            CollectedCount = 0;   
        }

        public void OnPlayerLosed()
        {
            CollectedCount = 0;
        }
    }
}
