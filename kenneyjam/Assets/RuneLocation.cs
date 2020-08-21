using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneLocation : MonoBehaviour
{
    public bool placed = false;
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
        
    }
}
