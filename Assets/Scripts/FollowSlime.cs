using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSlime : MonsterController
{

    public float jumpVelocity;

    public Rigidbody2D rb2D;

    public override void Attack(Vector3 playerPos)
    {
        if (!playerNearby) { return; }

        rb2D.velocity = (playerPos - transform.position) * jumpVelocity;

        StartCoroutine(AttackWait());

    }
}
