using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenMapScene()
    {
        SceneManager.LoadScene("Map");
    }
    public void BackMainMenu()
    {
        SceneManager.LoadScene("Main");
    }
    public void OpenCamera()
    {
        SceneManager.LoadScene("camera");
    }
}
