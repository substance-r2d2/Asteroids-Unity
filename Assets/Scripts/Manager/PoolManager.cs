using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Manage objet pools here
 * If requested GO is not avialble in pool then instantiate it instead
 * Use PoolId to maintain a dictionary
 */

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;

    Dictionary<string, Stack<IPoolable>> PooledGameObjects;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("MULTIPLE INSTANCES OF POOLMANAGER DETECTED "+gameObject.name);
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            PooledGameObjects = new Dictionary<string, Stack<IPoolable>>();
        }
    }

    public void AddToPool(IPoolable Poolable)
    {
        if(!PooledGameObjects.ContainsKey(Poolable.PoolId))
        {
            PooledGameObjects.Add(Poolable.PoolId, new Stack<IPoolable>());
        }

        PooledGameObjects[Poolable.PoolId].Push(Poolable);

        Poolable.PooledGObj.SetActive(false);

        Poolable.PooledGObj.transform.SetParent(transform);
    }

    public GameObject GetFromPool(IPoolable Poolable, Vector3 Position, Quaternion Rotation)
    {
        if (PooledGameObjects.ContainsKey(Poolable.PoolId))
        {
            if (PooledGameObjects[Poolable.PoolId].Count > 0)
            {
                GameObject PopedObj = PooledGameObjects[Poolable.PoolId].Pop().PooledGObj;
                PopedObj.transform.SetParent(null);
                PopedObj.transform.position = Position;
                PopedObj.transform.rotation = Rotation;
                PopedObj.SetActive(true);
                return PopedObj;
            }
        }


        GameObject Obj = Instantiate(Poolable.PooledGObj, Position, Rotation);
        return Obj;
    }

    public GameObject GetFromPool(GameObject Poolable, Vector3 Position, Quaternion Rotation)
    {
        IPoolable poolable = Poolable.GetComponent<IPoolable>();

        if (poolable != null)
        {
            if (PooledGameObjects.ContainsKey(poolable.PoolId))
            {
                if (PooledGameObjects[poolable.PoolId].Count > 0)
                {
                    GameObject PopedObj = PooledGameObjects[poolable.PoolId].Pop().PooledGObj;
                    PopedObj.transform.position = Position;
                    PopedObj.transform.rotation = Rotation;
                    PopedObj.SetActive(true);
                    return PopedObj;
                }
            }


            GameObject Obj = Instantiate(poolable.PooledGObj, Position, Rotation);
            return Obj;
        }

        return null;
    }

}
