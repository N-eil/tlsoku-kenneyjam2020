using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float speed = 25f;
	public Rigidbody2D rb;
	
	
	private Vector2 movement;
    private Door nearbyDoor;
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
		//rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
		rb.velocity =  movement * speed * Time.deltaTime;
	
		// Perform action (open doors?  place runes?  push stuff?)
		if (Input.GetButton("Action"))
		{
			Debug.Log("Action button pressed");
			PerformAction();
		}
	}
	
    void OnCollisionEnter2D(Collision2D collision)
    {
//        Debug.Log("collision");
//        Debug.Log(collision.gameObject);
        
        //Door collision
        Door collidedDoor = collision.gameObject.GetComponent<Door>();
        if (collidedDoor)
        {
            nearbyDoor = collidedDoor;
        }
    }
    
    void OnCollisionExit2D(Collision2D collision)
    {
//        Debug.Log("no more collision");
//        Debug.Log(collision.gameObject);
        
        //Door collision
        Door collidedDoor = collision.gameObject.GetComponent<Door>();
        if (collidedDoor && collidedDoor == nearbyDoor)
        {
            nearbyDoor = null;
        }   
    }
    
	private void PerformAction()
	{
		// Interact with doors
		if (nearbyDoor)
		{
			nearbyDoor.ToggleDoor();
		}
		
		// Place runes
		if (false /* when in a rune placement spot */)
		{
			
		}
	}
}
