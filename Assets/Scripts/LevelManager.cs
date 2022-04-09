using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void LevelGenarator()
    {
        int scene = PlayerPrefs.GetInt("level");
        if (scene > 1)
        {
            SceneManager.LoadScene(scene);
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }
    public void ShopMan()
    {
        SceneManager.LoadScene("Market");
    }
    public void ShopToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
