using Assets.Scripts;
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

    private Transform[] _visionCircles = new Transform[2];

    private AudioManager _audioManager;
	private Vector2 movement;
    private Door nearbyDoor;
    private RuneLocation nearbyRuneLocation;
    private int _selectedRuneIndex = 0;
    
    private int invulnFrameTotal = 75;
    private int invulnFrameCount = 0;
    private int _maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        _audioManager = GetComponent<AudioManager>();
        Transform spriteChild = transform.GetChild(0);
        _visionCircles[0] = spriteChild.GetChild(0);
        _visionCircles[1] = spriteChild.GetChild(1);   
/*
        runeInventory.Add(Instantiate(availableRunes[0]));
        runeInventory.Add(Instantiate(availableRunes[0]));
        runeInventory.Add(Instantiate(availableRunes[0]));
        runeInventory.Add(Instantiate(availableRunes[1]));
        runeInventory.Add(Instantiate(availableRunes[2]));
*/        
        levelManager.hudManager.FillRunes(runeInventory);

        Debug.Log(runeInventory.Count);
        
        foreach (Rune rune in runeInventory)
        {
            if (rune is HealthRune)
                health++;
            else if (rune is VisionRune)
            {
                Vector3 v = _visionCircles[0].transform.localScale;
                _visionCircles[0].transform.localScale = new Vector3(v.x + Constants.VISION_RUNE_INCREASE, v.y + Constants.VISION_RUNE_INCREASE, v.z);
                v = _visionCircles[1].transform.localScale;
                _visionCircles[1].transform.localScale = new Vector3(v.x + Constants.VISION_RUNE_INCREASE, v.y + Constants.VISION_RUNE_INCREASE, v.z);
            }
        }
        
        _maxHealth = health;
        levelManager.hudManager.SetLives(health);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Action"))
        {
            PerformAction();
        }
        
        if (Input.GetButtonDown("CycleLeft"))
        {
            SelectRune((_selectedRuneIndex - 1 + runeInventory.Count)  % runeInventory.Count);
        }
        
        if (Input.GetButtonDown("CycleRight"))
        {
            SelectRune((_selectedRuneIndex + 1 + runeInventory.Count)  % runeInventory.Count);
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
        
        if (invulnFrameCount != 0)
        {
            invulnFrameCount--;
        }
        
        if (health <= 0)
        {
            levelManager.PlayerDied();
        }
	}
    
    void OnCollisionStay2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (invulnFrameCount == 0 && enemy)
        {
            health -= 1;
            invulnFrameCount = invulnFrameTotal;
            levelManager.hudManager.SetLives(health);
            _audioManager.PlayDamageSound();
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
                nearbyRuneLocation.PlaceRune(runeInventory[_selectedRuneIndex].Sprite);
                if (runeInventory[_selectedRuneIndex] is HealthRune)
                {
                    _maxHealth -= 1;
                    if (health > _maxHealth)
                    {
                        health = _maxHealth;
                        levelManager.hudManager.SetLives(health);
                    }
                }
                else if (runeInventory[_selectedRuneIndex] is VisionRune)
                {
                    Vector3 v = _visionCircles[0].transform.localScale;
                    _visionCircles[0].transform.localScale = new Vector3(v.x - Constants.VISION_RUNE_INCREASE, v.y - Constants.VISION_RUNE_INCREASE, v.z);
                    v = _visionCircles[1].transform.localScale;
                    _visionCircles[1].transform.localScale = new Vector3(v.x - Constants.VISION_RUNE_INCREASE, v.y - Constants.VISION_RUNE_INCREASE, v.z);
                }
                nearbyRuneLocation.placed = true;
                runeInventory.RemoveAt(_selectedRuneIndex);
                if (_selectedRuneIndex >= runeInventory.Count)
                {
                    _selectedRuneIndex = runeInventory.Count -1;
                }
                levelManager.hudManager.RemoveRune();

                _audioManager.PlayRunePlacementSound();
            }
        }
	}
    
    void SelectRune(int index)
    {
        _selectedRuneIndex = index;
        levelManager.hudManager.SelectRune(index);
    }
    
}
