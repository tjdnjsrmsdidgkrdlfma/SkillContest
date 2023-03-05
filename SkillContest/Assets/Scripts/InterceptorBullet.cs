using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterceptorBullet : Bullet
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Move()
    {
        rb.velocity = transform.up * move_speed;
    }
}
