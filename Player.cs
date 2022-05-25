using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : Unit
{
    private Camera _playerCam;
    [SerializeField] private TextMeshProUGUI infoText;
    public bool isCamFollow = true;

    protected override void Start()
    {
        base.Start();
        _playerCam = Camera.main;
        MouseManager.Instance.mouseNoneEvent.AddListener(ClickMove);
        MouseManager.Instance.mouseUnitEvent.AddListener(ClickAttack);
    }

    protected override void Update()
    {
        base.Update();
        CameraFollow();
        infoText.text = $"Name:{unitInfo.unitName}\n Health: {CurrentHealth} / {unitInfo.health}\n\n\nSpeed:{unitInfo.moveSpeed}\nAttackSpeed:{unitInfo.attackSpeed}\nAttackDamage:{unitInfo.attackDamage}\nViewRangeL{unitInfo.viewRange}";
    }

    private void ClickMove(Vector2 pos, NoneClickType none)
    {
        StopAllCoroutines();
        if(none != NoneClickType.None) return;
        if (Input.GetMouseButtonDown(1))
        {
            destination = pos;
        }
    }
    
    private void CameraFollow()
    {
        if (isCamFollow)
        {
            var tempTrans = _playerCam.transform;
            tempTrans.position = ((Vector3) (Vector2) transform.position + tempTrans.position.z * Vector3.forward);
        }
    }

    private Coroutine _tempAttack;
    private void ClickAttack(Unit unit)
    {
        StopAllCoroutines();
        if (Input.GetMouseButtonDown(1))
        {
            destination = unit.transform.position;
            if ((unit.transform.position - transform.position).magnitude < unitInfo.attackRange)
            {
                destination = transform.position;
                _tempAttack = StartCoroutine(Attack(unit));
            }
            else
            {
                StartCoroutine(WaitAttack(unit));
                /*if(_tempAttack != null) StopCoroutine(_tempAttack);
                Debug.Log("AttackStop");*/
            }
        }
    }
}
