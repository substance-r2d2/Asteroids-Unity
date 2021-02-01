using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Simple implementation of IWeapon
 */

public class SimpleWeapon : MonoBehaviour, IWeapon
{
    [SerializeField]
    GameObject Prefab;

    [SerializeField]
    float Cooldown = 0.2f;

    [SerializeField]
    float BulletSpeed = 100.0f;

    float NextFireTime = 0.0f;

    public bool CanFire()
    {
        return Time.time > NextFireTime;
    }

    public void FireWeapon(Transform InstigatorTransform)
    {
        if (CanFire())
        {
            EventsManager.Audio.PlayShootSFX?.Invoke();

            GameObject bullet = PoolManager.Instance.GetFromPool(Prefab.GetComponent<IPoolable>(), transform.position, Quaternion.Euler(InstigatorTransform.eulerAngles));
            bullet.GetComponent<Rigidbody2D>().velocity = InstigatorTransform.up * BulletSpeed;

            NextFireTime = Time.time + Cooldown;
        }
    }

}
