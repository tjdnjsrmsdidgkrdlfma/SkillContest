using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : Enemy //y - 5.5 ~ 0
{
    [SerializeField] float min_move_speed;
    [SerializeField] float max_move_speed;
    [SerializeField] float move_to_destination_time;

    [SerializeField] GameObject space_ship_bullet_prefab;

    [SerializeField] Vector2 destination = new Vector2();

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        StartCoroutine(Attack());
        StartCoroutine(MoveToDestination(destination, move_to_destination_time));
    }

    IEnumerator MoveToDestination(Vector2 destination, float time_to_move)
    {
        float time = 0;

        Vector2 source = transform.position;

        while(time < 1)
        {
            time += Time.deltaTime / time_to_move;

            transform.position = Vector2.Lerp(source, destination, time);

            yield return null;
        }

        transform.position = destination;

        Move();
    }

    protected override void Move()
    {
        float random_move_speed = Random.Range(min_move_speed, max_move_speed);
        rb.velocity = Vector2.down * random_move_speed;
    }

    protected override IEnumerator Attack()
    {
        while(true)
        {
            Instantiate(space_ship_bullet_prefab, transform.position, Quaternion.identity);

            yield return new WaitForSeconds(attack_delay);
        }
    }

    protected override void Die()
    {
        throw new System.NotImplementedException();
    }
}
