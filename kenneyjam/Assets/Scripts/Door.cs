using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool opened = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleDoor()
    {
        opened = !opened;
        Debug.Log((opened ? "Opened" : "Closed") + " door " + this);

    }
}
