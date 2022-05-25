using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new monster", menuName = "unit/monster info", order = 0)]
public class MonsterInfo : UnitInfo
{
    public float xp;
    public float coin;
    public float hateRange;
}
