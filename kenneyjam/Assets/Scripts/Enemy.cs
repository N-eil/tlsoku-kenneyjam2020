using Assets.Scripts;
using Pathfinding;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform _targetPlayer;
    private AIDestinationSetter _aiDestinationSetter;
    private AIPath _aiPath;

    [Range(0, 360)]
    public float ViewAngle = 65;

    private void Start()
    {
        _aiDestinationSetter = GetComponent<AIDestinationSetter>();
        _aiPath = GetComponent<AIPath>();
    }

    private void FixedUpdate()
    {
        if (CanPlayerBeSeen())
        {
            _aiDestinationSetter.target = _targetPlayer;
        }

        transform.right = _aiPath.desiredVelocity;
    }

    private bool CanPlayerBeSeen()
    {
        return _targetPlayer && IsPlayerInFieldOfView() && !IsPlayerHiddenByObstacles();
    }

    private bool IsPlayerInFieldOfView()
    {
        Vector2 directionToPlayer = _targetPlayer.position - transform.position;
        Debug.DrawLine(transform.position, _targetPlayer.position, Color.magenta);

        Debug.Log("Direction: " + directionToPlayer);
        Debug.Log("Player: " + _targetPlayer.position);
        Debug.Log("Self: " + transform.right);

        float angle = Vector3.Angle(transform.right, directionToPlayer);
        Debug.Log("angle " + angle);
        return angle < ViewAngle;
    }

    private bool IsPlayerHiddenByObstacles()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, _targetPlayer.position);
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, _targetPlayer.position - transform.position, distanceToPlayer);
        Debug.DrawRay(transform.position, _targetPlayer.position - transform.position, Color.black);

        foreach (RaycastHit2D hit in hits)
        {
            // enemies can see through other enemies
            if (hit.transform.tag == Constants.ENEMY_TAG)
                continue;

            if (hit.transform.tag != Constants.PLAYER_TAG)
                return true;
        }
        return false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Constants.PLAYER_TAG)
            _targetPlayer = collision.gameObject.transform;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Constants.PLAYER_TAG)
            _targetPlayer = null;
    }
}
