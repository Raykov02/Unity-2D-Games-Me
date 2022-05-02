using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitBut : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void quit()
    {
        Application.Quit();
        Debug.Log("gamequit");
    }
    public void play()
    {
        SceneManager.LoadScene("GamePlay");
    }
    
}
