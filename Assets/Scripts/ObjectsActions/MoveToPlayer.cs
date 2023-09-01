using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectsActions
{
    public class MoveToPlayer : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 3f;

        [SerializeField]
        private float _activeDistance = 3f;

        private Transform _player;

        private void Start()
        {
            _player = Player.Instance.transform;
        }

        private void Update()
        {
            Vector3 position = transform.position;
            Vector3 playerPosition = _player.transform.position;

            float distance = Vector3.Distance(playerPosition, position);

            if (distance < _activeDistance)
            {
                position = Vector3.Lerp(position, playerPosition, _speed * Time.deltaTime);
                transform.position = position;
            }
        }
    }
}