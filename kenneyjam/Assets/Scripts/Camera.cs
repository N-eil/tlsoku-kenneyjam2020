using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform Player;

    void Start()
    {
    }

    void LateUpdate()
    {
        transform.position = new Vector3(Player.position.x, Player.position.y, -10f);
    }
}
