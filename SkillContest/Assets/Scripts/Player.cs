using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject bullet_prefab;

    [SerializeField] float move_speed;

    [SerializeField] float attack_delay;
    bool can_attack;

    float max_durability;
    float durability;
    public float Durability
    {
        get { return durability; }
        set { durability = value; }
    }

    float max_fuel;
    float fuel;
    float fuel_decrease_per_second;

    int repair_skill_repair;
    int repair_skill_use_number;
    bool can_use_repair_skill;

    int bomb_skill_damage;
    int bomb_skill_use_number;
    bool can_use_bomb_skill;

    Rigidbody2D rb;

    void Awake()
    {
        VariableInit();
    }

    void VariableInit()
    {
        can_attack = true;

        can_use_repair_skill = true;

        can_use_bomb_skill = true;

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Attack();
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 dir = new Vector2(horizontal, vertical).normalized;
        rb.velocity = dir * move_speed;
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space) == false || can_attack == false)
            return;

        can_attack = false; Debug.Log("A");

        Instantiate(bullet_prefab, transform.position, Quaternion.identity);

        StartCoroutine(AttackDelay());
    }

    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(attack_delay);

        can_attack = true;
    }
}
