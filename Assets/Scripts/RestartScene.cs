using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartScene : MonoBehaviour
{
    public Button restart;
    public PlayerController playerControL;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        playerControL.state = false;
    }
    public void Menu()
    {
        SceneManager.LoadScene(1);
        if (playerControL.state == true)
        {
            playerControL.state = false;
        }
        if (playerControL.state == false)
        {
            playerControL.state = false;
        }
    }
}
