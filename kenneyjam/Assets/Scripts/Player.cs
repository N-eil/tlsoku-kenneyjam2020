﻿using Assets.Scripts;
using Assets.Scripts.Runes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float speed = 25f;
	public Rigidbody2D rb;
    public int health = 1;
	public List<Rune> availableRunes;
    public List<Rune> runeInventory;
    public LevelManager levelManager;
    
	private Vector2 movement;
    private Door nearbyDoor;
    private RuneLocation nearbyRuneLocation;
    // Start is called before the first frame update
    void Start()
    {
        runeInventory.Add(Instantiate(availableRunes[0]));
        runeInventory.Add(Instantiate(availableRunes[0]));
        runeInventory.Add(Instantiate(availableRunes[0]));
        levelManager.hudManager.FillRunes(runeInventory);

        foreach (Rune rune in runeInventory)
        {
            if (rune is HealthRune)
                health++;
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Action"))
        {
            PerformAction();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		// Movement along both axes
		movement.x = Input.GetAxis("Horizontal");
		movement.y = Input.GetAxis("Vertical");
        float speedModifier = 1;
        foreach(Rune rune in runeInventory)
        {
            if (rune is SpeedRune)
                speedModifier *= 1.2f;
        }

		rb.velocity =  movement * speed * Time.deltaTime * speedModifier;
        if (rb.velocity != Vector2.zero)
        {
            transform.right = rb.velocity;
        }
        
        if (health <= 0)
        {
            levelManager.PlayerDied();
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
        
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy)
        {
            health -= 1;
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
            
            if (!nearbyDoor.opened)
            {
                float pushDistance = 0f;
                if (nearbyDoor.horizontal)
                {
                    pushDistance = (((RectTransform)nearbyDoor.transform).rect.width / 2 + ((RectTransform)transform).rect.width / 2);
                    if (transform.position.x < nearbyDoor.transform.position.x)  pushDistance *= -1;
                    transform.position = new Vector3(transform.position.x + pushDistance , transform.position.y, transform.position.z);
                }
                else
                {
                    pushDistance = (((RectTransform)nearbyDoor.transform).rect.height / 2 + ((RectTransform)transform).rect.height / 2);
                    if (transform.position.y < nearbyDoor.transform.position.y)  pushDistance *= -1;
                    transform.position = new Vector3(transform.position.x, transform.position.y + pushDistance, transform.position.z);
                }
            }
		}
		
		// Place runes
		if (nearbyRuneLocation)
		{
            if (!nearbyRuneLocation.placed)
            {
                nearbyRuneLocation.PlaceRune(runeInventory[0].Sprite);
                if (runeInventory[0] is HealthRune && health > 1)
                    health = 1;
                nearbyRuneLocation.placed = true;
                runeInventory.RemoveAt(0);
                levelManager.hudManager.RemoveRune();
            }
        }
	}
    
    
}
