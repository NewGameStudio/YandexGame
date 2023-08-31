using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectsPool
{
    public class ObjectsPool
    {
        private Stack<IPoolableObject> _poolables;
        private IPoolableObjectsProvider _provider;

        public ObjectsPool(IPoolableObjectsProvider provider)
        {
            _poolables = new Stack<IPoolableObject>();
            _provider = provider;
        }

        public IPoolableObject Instantiate()
        {
            if (_poolables.Count > 0)
                return _poolables.Pop();

            IPoolableObject poolable = _provider.Create();

            poolable.Initialize(this);

            return poolable;
        }

        public void AddToPool(IPoolableObject poolable)
        {
            _poolables.Push(poolable);
        }
    }
}
