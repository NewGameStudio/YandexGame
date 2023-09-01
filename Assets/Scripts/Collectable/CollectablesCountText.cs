using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Collectable
{
    [RequireComponent(typeof(Text))]
    public class CollectablesCountText : MonoBehaviour
    {
        [SerializeField]
        private CollectablesCounter _counter;

        private int _count;
        private Text _text;

        private void Start()
        {
            if (_counter == null)
            {
                enabled = false;
                throw new System.Exception("Collectables Counter not found");
            }

            _text = GetComponent<Text>(); 
        }

        private void Update()
        {
            if (_count == _counter.CollectedCount)
                return;

            _count = _counter.CollectedCount;
            _text.text = _count.ToString();
        }
    }
}
