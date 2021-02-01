using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * We don't want bullet damaging player 
 */

public class BulletDoDamage : SimpleDoDamage
{

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            base.OnTriggerEnter2D(collision);
        }
    }

}
