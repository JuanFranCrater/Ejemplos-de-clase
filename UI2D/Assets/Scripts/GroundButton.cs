using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;

public class GroundButton : MonoBehaviour 
{
    public Sprite onImg;
    public Sprite offImg;
    public List<string> activatorsTags;
    public UnityEvent onActivate;
    public UnityEvent onDesactivate;
    private List<GameObject> _objectsInContact;

    void Start()
    {
        _objectsInContact = new List<GameObject>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (activatorsTags.Contains(col.tag))
        {
            if (_objectsInContact.Count == 0)
            {
                TurnButton(true);
            }
            _objectsInContact.Add(col.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (_objectsInContact.Contains(col.gameObject))
        {
            _objectsInContact.Remove(col.gameObject);
            if (_objectsInContact.Count == 0)
            {
                TurnButton(false);
            }
        }
    }

    public void TurnButton(bool on)
    {
        GetComponent<SpriteRenderer>().sprite = on ? onImg : offImg;
        if (on)
        {
            onActivate.Invoke();
        }
        else
        {
            onDesactivate.Invoke();
        }
    }
}
