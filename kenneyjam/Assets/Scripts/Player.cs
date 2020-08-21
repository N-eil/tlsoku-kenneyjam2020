using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float speed = 1f;
	public Rigidbody2D rb;
	
	
	private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		movement.x = Input.GetAxis("Horizontal");
		movement.y = Input.GetAxis("Vertical");
				
		rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }
}
