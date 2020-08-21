using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneLocation : MonoBehaviour
{
    public bool placed = false;
    
    private const float RUNE_SCALE = 0.6f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void PlaceRune(Sprite rune)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = rune;
        transform.localScale = new Vector3(RUNE_SCALE, RUNE_SCALE, 1);
    }
}
