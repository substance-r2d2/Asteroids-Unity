using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Spawns asteroid with gap of calculated random wait time
 */

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject Prefab;

    [SerializeField]
    float SpawnVelocity;

    [SerializeField]
    float MinWaitTime;

    [SerializeField]
    float MaxWaitTime;

    CircleCollider2D CircleCollider;

    void Start()
    {
        CircleCollider = GetComponent<CircleCollider2D>();
    }

    private void OnEnable()
    {
        EventsManager.GameEvents.GameOver += HandleGameOver;
        EventsManager.GameEvents.GameStart += HandleGameStart;
    }

    private void OnDisable()
    {
        EventsManager.GameEvents.GameOver -= HandleGameOver;
        EventsManager.GameEvents.GameStart -= HandleGameStart;
    }

    void HandleGameStart()
    {
        StartCoroutine("SpawnAsteroids");
    }

    void HandleGameOver()
    {
        StopCoroutine("SpawnAsteroids");
    }

    //Calculate random postion on the spawn ring and then apply velocity
    IEnumerator SpawnAsteroids()
    {
        while(true)
        {
            var vec = Random.insideUnitCircle.normalized * CircleCollider.radius;
            GameObject obj = PoolManager.Instance.GetFromPool(Prefab, new Vector3(vec.x, vec.y, transform.position.z), Quaternion.identity);

            yield return null;

            Vector3 centerVec = (transform.position -  obj.transform.position).normalized;
            obj.GetComponent<Rigidbody2D>().velocity = centerVec * SpawnVelocity;

            yield return new WaitForSeconds(Random.Range(MinWaitTime, MaxWaitTime));
        }
    }
}
