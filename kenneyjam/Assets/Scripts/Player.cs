using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float speed = 25f;
	public Rigidbody2D rb;
    
    
	public List<Sprite> runeInventory;

	private Vector2 movement;
    private Door nearbyDoor;
    private RuneLocation nearbyRuneLocation;
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
		if (Input.GetButtonDown("Action"))
		{
			Debug.Log("Action button pressed");
			PerformAction();
		}
	}
	
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collided with trigger");
        //Door collision
        Door collidedDoor = collision.gameObject.GetComponent<Door>();
        if (collidedDoor)
        {
            nearbyDoor = collidedDoor;
        }
    }
    
    void OnCollisionExit2D(Collision2D collision)
    {

        //Door collision
        Door collidedDoor = collision.gameObject.GetComponent<Door>();
        if (collidedDoor && collidedDoor == nearbyDoor)
        {
            nearbyDoor = null;
        }   
    }
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("collided with trigger");
        //Rune placement collision
        RuneLocation collidedRuneLocation = collider.gameObject.GetComponent<RuneLocation>();
        if (collidedRuneLocation)
        {
            nearbyRuneLocation = collidedRuneLocation;
        }
        Door door = collider.gameObject.GetComponent<Door>();
        if (door)
        {
            nearbyDoor = door;
        }
    }
    
    void OnTriggerExit2D(Collider2D collider)
    {     
        //Rune placement collision
        RuneLocation collidedRuneLocation = collider.gameObject.GetComponent<RuneLocation>();
        if (collidedRuneLocation && collidedRuneLocation == nearbyRuneLocation)
        {
            nearbyRuneLocation = null;
        }
        Door door = collider.gameObject.GetComponent<Door>();
        if (door && door == nearbyDoor)
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
		if (nearbyRuneLocation)
		{
            if (!nearbyRuneLocation.placed)
            {
                nearbyRuneLocation.PlaceRune(runeInventory[0]);
                nearbyRuneLocation.placed = true;
                runeInventory.RemoveAt(0);
            }
        }
	}
    
    
}
