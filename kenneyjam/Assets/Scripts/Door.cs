using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool opened = false;
    public bool horizontal;
    
    private BoxCollider2D _collider;
    void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
    }

    public void ToggleDoor()
    {
        opened = !opened;
        Debug.Log((opened ? "Opened" : "Closed") + " door " + this);
        _collider.isTrigger = opened;
        if (opened)
            gameObject.layer = Constants.DEFAULT_LAYER;
        else
            gameObject.layer = Constants.BLOCKERS_LAYER;

        // recalculate pathfinding graph
        AstarPath.active.Scan();
    }
}
