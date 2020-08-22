using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation : MonoBehaviour
{
    public AIPath AIPath;
    private Vector2 _direction;

    private void Update()
    {
        FaceVelocity();
    }

    private void FaceVelocity()
    {
        _direction = AIPath.desiredVelocity;
        if (_direction != Vector2.zero)
        {
            transform.right = _direction;
        }
    }
}
