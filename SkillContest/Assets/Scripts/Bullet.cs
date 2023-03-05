using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public float damage;

    [SerializeField] protected float destroy_time;
    [SerializeField] protected float move_speed;

    protected Rigidbody2D rb;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start()
    {
        Destroy();
        Move();
    }

    protected void Destroy()
    {
        Destroy(gameObject, destroy_time);
    }

    protected abstract void Move();
}
