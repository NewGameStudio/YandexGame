using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameLoop
{
    [RequireComponent(typeof(Text))]
    public class HideTextWhenPlay : MonoBehaviour
    {
        private Text _text;

        private void Awake()
        {
            _text = GetComponent<Text>(); 
        }

        private void Start()
        {
            GameLoop.Instance.OnGameStarted += OnGameStarted;
            GameLoop.Instance.OnGameLosed += OnGameLosed;
        }

        private void OnGameStarted()
        {
            _text.enabled = false;
        }

        private void OnGameLosed()
        {
            _text.enabled = true;
        }
    }
}
