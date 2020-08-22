using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool opened = false;
    
    private BoxCollider2D _collider;
    private Transform _spriteTransform;
    private SpriteRenderer _spriteRenderer;
    
    private Vector3 _openDoorPosition;
    void Start()
    {

        _collider = GetComponent<BoxCollider2D>();
        _spriteTransform = gameObject.transform.GetChild(0);
        _spriteRenderer = _spriteTransform.gameObject.GetComponent<SpriteRenderer>();
        _openDoorPosition = new Vector3(0,0.55f,0);
        
        if (opened)
        {
            opened = !opened;
            ToggleDoor();
        }
    }

    public void ToggleDoor()
    {
        opened = !opened;
        Debug.Log((opened ? "Opened" : "Closed") + " door " + this);
        _collider.isTrigger = opened;
        Debug.Log(Constants.BLOCKERS_LAYER);
        if (opened)
        {
            gameObject.layer = Constants.DEFAULT_LAYER;
            _spriteTransform.localPosition = _openDoorPosition;
            _spriteRenderer.sortingLayerName = "Floor";
        }
        else
        {
            gameObject.layer = Constants.BLOCKERS_LAYER;
            _spriteTransform.localPosition = Vector3.zero;
            _spriteRenderer.sortingLayerName = "Blockers";

        }
        // recalculate pathfinding graph
        AstarPath.active.Scan();
    }
}
