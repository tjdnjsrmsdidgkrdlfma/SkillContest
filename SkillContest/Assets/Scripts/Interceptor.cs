using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interceptor : Enemy
{
    [SerializeField] float min_move_speed;
    [SerializeField] float max_move_speed;
    [SerializeField] float random_attack_angle;

    [SerializeField] GameObject interceptor_bullet_prefab;

    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        Move();
        StartCoroutine(Attack());
    }

    protected override void Move()
    {
        float random_move_speed = Random.Range(min_move_speed, max_move_speed);
        rb.velocity = transform.up * random_move_speed;
    }

    protected override IEnumerator Attack()
    {
        float random_attack_angle_value;
        float angle;

        while (true)
        {
             angle = Mathf.Atan2(player.transform.position.y - transform.position.y,
                                 player.transform.position.x - transform.position.x)
                   * Mathf.Rad2Deg;

            random_attack_angle_value = Random.Range(-random_attack_angle, random_attack_angle);
            angle += random_attack_angle_value;

            Instantiate(interceptor_bullet_prefab, transform.position, Quaternion.Euler(new Vector3(0, 0, angle - 90)));

            yield return new WaitForSeconds(attack_delay);
        }
    }

    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        float angle = Mathf.Atan2(player.transform.position.y - transform.position.y,
                                  player.transform.position.x - transform.position.x)
                    * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }

    protected override void Die()
    {
        Debug.Log("Die");
    }
}