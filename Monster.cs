using System.Collections.Generic;
using UnityEngine;

public class Monster : Unit
{
    public Transform home;
    private RangeCollider _rangeCollider;

    protected override void Start()
    {
        base.Start();
        home = GetComponentInParent<RangeCollider>().transform;
        _rangeCollider = GetComponentInParent<RangeCollider>();
    }

    private Coroutine _only;
    protected override void Update()
    {
        base.Update();
        //如果有玩家在范围内
        if (_rangeCollider.inRangePlayer.Count > 0)
        {
            //追逐第一个
            _only ??= StartCoroutine(WaitAttack(_rangeCollider.inRangePlayer[0]));
        }
        else
        {
            StopAllCoroutines();
            _only = null;
            destination = home.position;
        }
    }
}