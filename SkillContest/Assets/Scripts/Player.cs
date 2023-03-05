using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
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
        set
        {
            durability = Mathf.Clamp(value, 0, max_durability);
            if (durability <= 0)
                Die();
        }
    }

    float max_fuel;
    float fuel;
    public float Fuel
    {
        get { return fuel; }
        set
        {
            fuel = Mathf.Clamp(value, 0, max_fuel);
            if (fuel <= 0)
                Die();
        }
    }
    float fuel_decrease;

    int repair_skill_repair;
    int repair_skill_use_number;
    float repair_skill_delay;
    bool can_use_repair_skill;

    void RepairSkill()
    {
        if (Input.GetKeyDown(KeyCode.J) && repair_skill_use_number > 0 && can_use_repair_skill == true)
            StartCoroutine(RealRepairSkill());
    }

    IEnumerator RealRepairSkill()
    {
        can_use_repair_skill = false;

        Durability += repair_skill_repair;
        repair_skill_use_number--;

        yield return new WaitForSeconds(repair_skill_delay);

        can_use_repair_skill = true;
    }

    int bomb_skill_damage;
    int bomb_skill_use_number;
    float bomb_skill_delay;
    bool can_use_bomb_skill;

    void BombSkill()
    {
        if (Input.GetKeyDown(KeyCode.K) && bomb_skill_use_number > 0 && can_use_bomb_skill == true)
            StartCoroutine(RealBombSkill());
    }

    IEnumerator RealBombSkill()
    {
        yield return null;
    }

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
        Attack();
        Fuel -= fuel_decrease;
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space) == false || can_attack == false)
            return;

        can_attack = false;

        Instantiate(bullet_prefab, transform.position, Quaternion.identity);

        StartCoroutine(AttackDelay());
    }

    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(attack_delay);

        can_attack = true;
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 dir = new Vector2(horizontal, vertical).normalized * move_speed;
        rb.velocity = dir;
    }

    void Die()
    {
        //Debug.Log("Die");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            Durability -= other.GetComponent<Bullet>().damage;
        }
    }
}