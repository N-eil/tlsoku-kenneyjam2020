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
		// Movement along both axes
		movement.x = Input.GetAxis("Horizontal");
		movement.y = Input.GetAxis("Vertical");
		rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    
	
		// Perform action (open doors?  place runes?  push stuff?)
		if (Input.GetButton("Action"))
		{
			Debug.Log("Action button pressed");
			PerformAction();
		}
	}
	
	private void PerformAction()
	{
		// Interact with doors
		if (false /* check for nearby doors */)
		{
			
		}
		
		// Place runes
		if (false /* when in a rune placement spot */)
		{
			
		}
	}
}
