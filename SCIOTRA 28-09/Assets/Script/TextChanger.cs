using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextChanger : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI namePlace, locationPlace;
    private Material originalMaterial;  
    void Start()
    {
        originalMaterial = namePlace.material;               
        SetTransparency(0.0f);
    }

    public void UpdateText(string newName, string newLocation)
    {
        namePlace.text = newName;
        locationPlace.text = newLocation;

        namePlace.material = originalMaterial;

        SetTransparency(1.0f);
    }

    private void SetTransparency(float alpha)
    {
        Color color = namePlace.color;
        color.a = alpha;
        namePlace.color = color;
        locationPlace.color = color;
    }
}
