using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeCollider : MonoBehaviour
{
    public List<Player> inRangePlayer = new List<Player>();
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>())
        {
            inRangePlayer.Add(other.GetComponent<Player>());
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Player>() && inRangePlayer.Contains(other.GetComponent<Player>()))
        {
            inRangePlayer.Remove(other.GetComponent<Player>());
        }
    }
}
