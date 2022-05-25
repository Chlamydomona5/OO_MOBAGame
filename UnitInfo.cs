using UnityEngine;

[CreateAssetMenu(fileName = "new info", menuName = "unit/unit info", order = 0)]
public abstract class UnitInfo : ScriptableObject
{
    public string unitName;
    public Sprite image;

    public float viewRange;
    public float attackDamage;
    public float attackRange;
    public float moveSpeed;
    public float attackSpeed;
    public float health;
}
