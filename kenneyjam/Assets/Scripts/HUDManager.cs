using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    
    public List<Image> displayedRunes;
    // Start is called before the first frame update
    void Start()
    {
        
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
    
    public void RemoveLife()
    {
        
    }
    
    public void RemoveRune()
    {
        transform.Find("Rune1").gameObject.GetComponent<Image>().enabled = false;
    }
}
