using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float attack_delay;
    [SerializeField] protected float durability;
    public float Durability
    {
        get { return durability; }
        set 
        { 
            durability = value;
            if (durability <= 0)
                Die();
        }
    }

    [SerializeField] protected GameObject player;

    protected Rigidbody2D rb;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected abstract void Move();
    protected abstract IEnumerator Attack();
    protected abstract void Die();

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            Durability -= other.GetComponent<Bullet>().damage;
        }
    }
}