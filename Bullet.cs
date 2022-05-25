using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage = 10;

    private void Start()
    {
        Invoke("DesSelf", 2f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>())
        {
            other.GetComponent<Player>().CurrentHealth -= 10;
            DesSelf();
        }
    }

    private void DesSelf()
    {
        Destroy(gameObject);
    }
}
