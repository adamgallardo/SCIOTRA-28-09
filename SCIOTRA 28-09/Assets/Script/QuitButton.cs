using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public GameObject tablero;
    // Start is called before the first frame update
    void Start()
    {
        tablero.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseWindow()
    {
        tablero.SetActive(false);
    }
}
