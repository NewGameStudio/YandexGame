using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameLoop
{
    [RequireComponent(typeof(Collider))]
    public class PlayerLoseWhenCollide : MonoBehaviour
    {
        private GameObject _player;

        private void Start()
        {
            _player = Player.Instance.gameObject;
        }

        public void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject == _player)
                GameLoop.Instance.PlayerLosed();
        }
    }
}
