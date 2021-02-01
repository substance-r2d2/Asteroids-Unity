using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Simple implementation of IPoolable
 */

public class SimplePoolable : MonoBehaviour, IPoolable
{
    [SerializeField]
    string PoolName;

    public GameObject PooledGObj { get { return this.gameObject; } }

    public string PoolId { get { return PoolName; } } 

    public void Pool()
    {
        PoolManager.Instance.AddToPool(this);
    }
}
