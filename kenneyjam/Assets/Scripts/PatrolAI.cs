using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAI : MonoBehaviour
{
    public List<EnemyWaypoint> Waypoints;

    private AIPath _aiPath;
    private AIDestinationSetter _aiDestinationSetter;
    private int _waypointIndex;

    void Start()
    {
        _aiPath = GetComponent<AIPath>();
        _aiDestinationSetter = GetComponent<AIDestinationSetter>();
        if (Waypoints.Count > 0)
            _aiDestinationSetter.target = Waypoints[0].transform;
    }

    void Update()
    {
        if (_aiPath.reachedEndOfPath)
        {
            _waypointIndex = (_waypointIndex + 1) % Waypoints.Count;
            _aiDestinationSetter.target = Waypoints[_waypointIndex].transform;
        }
    }
}
