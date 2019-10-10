using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class Handle : MonoBehaviour 
{
    private bool _activate = false;
    public bool deactivable;
    public List<string> activatorTags;
    public UnityEvent onActivate;
    public UnityEvent onDeactivate;
    private bool _activatorOnIt;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (activatorTags.Contains(col.gameObject.tag) && !_activatorOnIt)
        {
            if (!_activate)
            {
                Activate();
            }
            else if (deactivable)
            {
                Deactivate();
            }
            if (GetComponent<Animator>() != null)
            {
                GetComponent<Animator>().SetBool("Activate", _activate);
            }
            _activatorOnIt = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (activatorTags.Contains(col.gameObject.tag))
        {
            _activatorOnIt = false;
        }
    }

    [ContextMenu("Activate")]
    public void Activate()
    {
        _activate = true;
        onActivate.Invoke();
    }

    [ContextMenu("Deactivate")]
    public void Deactivate()
    {
        _activate = false;
        onDeactivate.Invoke();
    }
}
