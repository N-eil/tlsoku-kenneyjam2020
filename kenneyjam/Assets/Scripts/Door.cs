using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool opened = false;
    public bool horizontal;
    public float pushDistance = 0f;
    
    private BoxCollider2D _collider;
    private Transform _spriteTransform;
    private SpriteRenderer _spriteRenderer;
    
    private Vector3 _closedDoorPosition;
    void Start()
    {

        _collider = GetComponent<BoxCollider2D>();
        _spriteTransform = gameObject.transform.GetChild(0);
        _spriteRenderer = _spriteTransform.gameObject.GetComponent<SpriteRenderer>();
        if (horizontal)
        {
            _closedDoorPosition = new Vector3(0.55f,0,0);
            pushDistance = ((RectTransform)_spriteTransform).rect.width / 2;
        }
        else
        {
            _closedDoorPosition = new Vector3(0,0.55f,0);
            pushDistance = ((RectTransform)_spriteTransform).rect.height / 2;
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
            _spriteTransform.localPosition = _closedDoorPosition;
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
