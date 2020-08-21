using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DisplayOnlyInEditor : MonoBehaviour
{
    void Start()
    {
        if (Application.isPlaying)
        {
            var renderer = GetComponent<Renderer>();
            var color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, 0);
            renderer.material.color = color;
        }
    }
}
