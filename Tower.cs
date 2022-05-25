using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Unit
{
    private List<Player> _playersInRange;
    [SerializeField] private GameObject bullet;

    protected override void Start()
    {
        base.Start();
        _playersInRange = GetComponentInChildren<RangeCollider>().inRangePlayer;
        StartCoroutine(Shoot());
    }

    protected override void Update()
    {
        base.Update();
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            while (_playersInRange.Count == 0) yield return null;

            var rb = Instantiate(bullet, transform.position + Vector3.up * 2, Quaternion.identity).GetComponent<Rigidbody2D>();
            rb.velocity = (_playersInRange[0].transform.position - rb.transform.position).normalized * 25;
            
            yield return new WaitForSeconds(1 / unitInfo.attackSpeed);
        }
    }
}
