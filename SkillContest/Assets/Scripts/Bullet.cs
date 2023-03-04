using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;

    [SerializeField] float destroy_time;
    [SerializeField] float move_speed;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.velocity = Vector3.up * move_speed;

        Destroy(gameObject, destroy_time);
    }
}
