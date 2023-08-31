using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectsPool
{
    public interface IPoolableObjectsProvider 
    {
        IPoolableObject Create();
    }
}
