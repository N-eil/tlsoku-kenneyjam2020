using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool opened = false;
    private BoxCollider2D _collider;
    void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleDoor()
    {
        opened = !opened;
        Debug.Log((opened ? "Opened" : "Closed") + " door " + this);
        //_collider.enabled = !opened;
        _collider.isTrigger = opened;
    }
}
