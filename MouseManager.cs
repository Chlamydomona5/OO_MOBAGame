using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public enum NoneClickType
{
    None,
    Barrier
}

public class MouseManager : Singleton<MouseManager>
{
    public LayerMask clickMask;
    public float wheelToSizeSpeed;
    
    [HideInInspector] public UnityEvent<Vector2,NoneClickType> mouseNoneEvent = new ();
    [HideInInspector] public UnityEvent<Unit> mouseUnitEvent = new ();
    [SerializeField] private TextMeshProUGUI infoText;
    private Unit _mouseOnUnit;
    private void Update()
    {
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var hits = Physics2D.RaycastAll(pos, Vector2.down, 0.5f, clickMask);
        RaycastHit2D hit = new ();
        foreach (var m in hits)
        {
            if (m.collider.GetComponent<Unit>())
            {
                hit = m;
            }
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            if (hit && hit.transform.GetComponent<Unit>())
            {
                mouseUnitEvent.Invoke(hit.transform.GetComponent<Unit>());
            }
            
            else if (hit&& (hit.transform.GetComponentInParent<Barrier>() || hit.transform.GetComponentInChildren<Barrier>()))
            {
                mouseNoneEvent.Invoke(pos, NoneClickType.Barrier);
            }
            else
            {
                mouseNoneEvent.Invoke(pos, NoneClickType.None);
            }
        }

        
        if (hit && hit.transform.GetComponent<Unit>())
        {
            _mouseOnUnit = hit.transform.GetComponent<Unit>();
        }

        if (_mouseOnUnit)
        {
            var info = _mouseOnUnit.unitInfo;
            infoText.text = $"Name:{info.unitName}\n Health: {_mouseOnUnit.CurrentHealth} / {info.health}\n\n\nSpeed:{info.moveSpeed}\nAttackSpeed:{info.attackSpeed}\nAttackDamage:{info.attackDamage}\nViewRangeL{info.viewRange}";
        }
        else
        {
            infoText.text = "";
        }
        
        Camera.main.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * wheelToSizeSpeed;
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, 5f, 20f);

    }
    
    
}