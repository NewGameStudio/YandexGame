using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Patterns
{
    public class ObjectsPool
    {
        private Stack<PoolableObject> _poolables;
        private IPoolableObjectsProvider _provider;

        public ObjectsPool(IPoolableObjectsProvider provider)
        {
            _poolables = new Stack<PoolableObject>();
            _provider = provider;
        }

        public PoolableObject GetInstance()
        {
            PoolableObject poolable;

            if (_poolables.Count > 0)
            {
                poolable = _poolables.Pop();
                poolable.Active();
            }
            else
            {
                poolable = _provider.CreateNew();
                poolable.SetPool(this);
            }

            return poolable;
        }

        public void AddToPool(PoolableObject poolable)
        {
            _poolables.Push(poolable);
        }
    }
}
