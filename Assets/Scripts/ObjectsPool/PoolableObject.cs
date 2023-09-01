using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Patterns
{
    public class PoolableObject : MonoBehaviour
    {
        private ObjectsPool _pool;

        public void SetPool(ObjectsPool pool)
        {
            _pool = pool;
        }

        public void PushToPool()
        {
            _pool.Push(this);
        }

        public virtual void Active()
        {
            gameObject.SetActive(true);
        }

        public virtual void Deactive()
        {
            gameObject.SetActive(false);
        }
    }
}
