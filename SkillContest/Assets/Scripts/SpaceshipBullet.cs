using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipBullet : Bullet
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
        rb.velocity = Vector3.down * move_speed;
    }
}
