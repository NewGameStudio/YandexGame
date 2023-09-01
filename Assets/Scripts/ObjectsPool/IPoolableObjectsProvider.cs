using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Patterns
{
    public interface IPoolableObjectsProvider
    {
        PoolableObject CreateNew();
    }
}
