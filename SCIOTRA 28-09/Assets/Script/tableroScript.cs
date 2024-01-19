using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class tableroScript : MonoBehaviour
{
    public TextMeshProUGUI nombre;
    public TextMeshProUGUI calle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Valores(string name, string street)
    {
        Debug.Log("nombre "+name);
        Debug.Log("calle " + street);
        nombre.text = "nombre "+name;
        calle.text = "calle "+street;
    }
}
