using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * In game asteroids. Also spawn smaller asteroid from here 
 */

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    GameObject smallerAsteroid;

    [SerializeField]
    int SmallerAsteroidSpawnCount = 2;

    IPoolable Poolable;

    ITakeDamage TakeDamage;

    private void OnEnable()
    {
        if(TakeDamage != null)
        {
            TakeDamage.ModifyHealth += HandleModifyHealth;
        }
    }

    private void OnDisable()
    {
        TakeDamage.ModifyHealth -= HandleModifyHealth;
    }

    private void Start()
    {
        Poolable = GetComponent<IPoolable>();

        TakeDamage = GetComponent<ITakeDamage>();

        TakeDamage.ModifyHealth += HandleModifyHealth;
    }

    void HandleModifyHealth(int NewHealth)
    {
        if(NewHealth <= 0)
        {
            EventsManager.Audio.PlayAsteroidBlastSFX?.Invoke();

            if (smallerAsteroid != null)
            {
                Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();

                for (int i = 0; i < SmallerAsteroidSpawnCount; i++)
                {
                    GameObject obj = PoolManager.Instance.GetFromPool(smallerAsteroid, transform.position, Quaternion.identity);
                    obj.GetComponent<Rigidbody2D>().velocity = rigidBody.velocity * Random.insideUnitCircle.normalized;
                }
            }

            Poolable.Pool();
        }
    }
}
