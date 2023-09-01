using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLoop
{
    [RequireComponent(typeof(Player), typeof(TrailRenderer))]
    public class PlayerGameLoop : MonoBehaviour
    {
        private Player _controller;
        private TrailRenderer _trailRenderer;

        private void Awake()
        {
            _controller = GetComponent<Player>();
            _trailRenderer = GetComponent<TrailRenderer>();
        }

        private void Start()
        {
            GameLoop.Instance.OnGameStarted += OnGameStarted;
            GameLoop.Instance.OnGameLosed += OnGameLosed;
        }

        private void OnGameStarted()
        {
            _controller.StartMoving();
        }

        private void OnGameLosed()
        {
            _controller.StopMoving();
            _controller.transform.position = new Vector3(-4.45f, 0, 0);
            _trailRenderer.Clear();
        }
    }
}
