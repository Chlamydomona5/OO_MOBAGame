using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<Player>())
        {
            other.GetComponent<Player>().CurrentHealth += 0.1f;
        }
    }
    
}
