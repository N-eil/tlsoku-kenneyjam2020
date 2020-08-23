using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    
    public List<Image> displayedRunes;
    public List<Outline> displayedOutlines;
    public List<Image> displayedLives;
    public Image blankRune;
    
    private int _activeRuneIndex = 0;
    public GameObject _winPanel;
    // Start is called before the first frame update
    void Start()
    {
        SelectRune(_activeRuneIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void FillRunes(List<Assets.Scripts.Rune> runes)
    {
        Debug.Log(runes);
        Debug.Log("you have this many runes " + runes.Count);
        int index = 0;
        foreach (Assets.Scripts.Rune rune in runes)
        {
            displayedRunes[index].sprite = rune.Sprite;
            index++;
        }
    }
    
    public void SetLives(int remaining)
    {
        for (int i = 0; i < displayedLives.Count - remaining; i++)
        {
            displayedLives[i].enabled = false;
        }
    }
    
    public void RemoveRune()
    {
        displayedRunes[_activeRuneIndex].sprite = blankRune.sprite;
        displayedRunes.RemoveAt(_activeRuneIndex);
        
        displayedOutlines[_activeRuneIndex].enabled = false;
        displayedOutlines.RemoveAt(_activeRuneIndex);
        if (displayedRunes.Count != 0 && _activeRuneIndex >= displayedRunes.Count)
        {
            _activeRuneIndex = displayedRunes.Count - 1;
            SelectRune(_activeRuneIndex);
        }
    }    
    
    public void SelectRune(int index)
    {
        displayedOutlines[_activeRuneIndex].enabled = false;
        _activeRuneIndex = index;
        displayedOutlines[_activeRuneIndex].enabled = true;
    }
    
    public void DisplayWin()
    {
        _winPanel.SetActive(true);
    }
}
