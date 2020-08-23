using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public List<RuneLocation> runeLocations;
    public HUDManager hudManager;
    public int levelNumber;
    private bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(runeLocations);
        active = true;
        Assets.Scripts.PersistentVariables.currentLevel = levelNumber;
    }

    // Update is called once per frame
    void Update()
    {
        if (!active) return;

        List<RuneLocation> toRemove = new List<RuneLocation>();
        foreach (RuneLocation location in runeLocations)
        {
            if(location.placed)
            {
                Debug.Log("Removing rune locations");
                toRemove.Add(location);
            }
        }
        foreach (RuneLocation location in toRemove)
        {
            runeLocations.Remove(location);
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
        SceneManager.LoadScene("GameOver");
        
    }
    
    public void PlayerDied()
    {
        if (active)
            TriggerLoss("You ran out of HP");
    }
}