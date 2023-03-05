using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float damage;

    [SerializeField] float min_scale;
    [SerializeField] float max_scale;

    [SerializeField] float min_move_speed;
    [SerializeField] float max_move_speed;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        float z_dir = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(0, 0, z_dir);

        float scale = Random.Range(min_scale, max_scale);
        transform.localScale = new Vector2(scale, scale);

        float move_speed = Random.Range(min_move_speed, max_move_speed);

        rb.velocity = transform.up * move_speed;
    }
}