using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameLoop
{
    public class GameLoop : MonoBehaviour
    {
        public static GameLoop Instance { get; private set; }

        public event Action OnGameStarted;
        public event Action OnGameLosed;

        private bool _gameStarted;

        private void Awake()
        {
            if (Instance != null)
            {
                enabled = false;
                throw new Exception("GameLoop instance alreay existed in scene");
            }

            Instance = this;
        }

        private void Update()
        {
            if (!_gameStarted)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    OnGameStarted?.Invoke();

                    _gameStarted = true;
                }
            }
        }


        public void PlayerLosed()
        {
            OnGameLosed?.Invoke();

            _gameStarted = false;
        }
    }
}
