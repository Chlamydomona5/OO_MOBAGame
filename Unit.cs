using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public Vector2 destination;
    public UnitInfo unitInfo;

    [SerializeField] private float currentHealth;
    public float CurrentHealth
    {
        get => currentHealth;
        set
        {
            currentHealth = Mathf.Clamp(value, 0, unitInfo.health);
            if (currentHealth == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    protected virtual void Start()
    {
        destination = transform.position;
        currentHealth = unitInfo.health;
    }

    protected virtual void Update()
    {
        //还没有抵达目的地
        if(((Vector2)transform.position - destination).magnitude > 0.5f)
            GetComponent<Rigidbody2D>().velocity =  ((destination - (Vector2) transform.position).normalized * unitInfo.moveSpeed);
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    protected IEnumerator WaitAttack(Unit unit)
    {
        Debug.Log("StartWaitAttack");
        while (unit && (unit.transform.position - transform.position).magnitude > unitInfo.attackRange)
        {
            destination = unit.transform.position;
            yield return null;
        }
        destination = transform.position;
        StartCoroutine(Attack(unit));
    }
    
    protected IEnumerator Attack(Unit unit)
    {
        Debug.Log("AttackStart");
        while (unit && (unit.transform.position - transform.position).magnitude < unitInfo.attackRange)
        {
            yield return new WaitForSeconds(1 / unitInfo.attackSpeed);
            unit.CurrentHealth -= unitInfo.attackDamage;
        }

        StartCoroutine(WaitAttack(unit));
        Debug.Log("AttackQuit");
    }
}
