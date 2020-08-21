﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<RuneLocation> runeLocations;
    private bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(runeLocations);
        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!active) return;
        
        foreach (RuneLocation location in runeLocations)
        {
            if(location.placed)
            {
                Debug.Log("Removing rune locations");
                runeLocations.Remove(location);
            }
        }
        if (runeLocations.Count == 0)
        {
            TriggerWin();
        }
        
        
    }
    
    void TriggerWin()
    {
        Debug.Log("You win!");
        active = false;
    }
    
    void TriggerLoss(string message)
    {
        Debug.Log("You lose!  " + message);
        active = false;
        
    }
    
    public void PlayerDied()
    {
        TriggerLoss("You ran out of HP");
    }
}