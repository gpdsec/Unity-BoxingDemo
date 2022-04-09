using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkorSave : MonoBehaviour
{
    public Text skor, shield, coinBuy;
    float shieldPlayer = 100;
    float reduc = 30;
    int coinSave = 20;
    bool save = false;
    void Start()
    {
        shield.text = "Shield: " + PlayerPrefs.GetFloat("shieldss", shieldPlayer);
        skor.text = "" + PlayerPrefs.GetInt("Coins");
        coinSave = PlayerPrefs.GetInt("Buying", coinSave);
        coinBuy.text = "" + PlayerPrefs.GetInt("Buying", coinSave);
        PlayerPrefs.SetFloat("Buying", coinSave);
    }
    private void Awake()
    {
        reduc = PlayerPrefs.GetFloat("ReducesPla", reduc);
        PlayerPrefs.SetFloat("ReducesPla", reduc);
    }
    void Update()
    {

    }
    public void ShieldSave()
    {
        Save();
        save = false;
    }
    public void Save()
    {
        int coinBuying = int.Parse(coinBuy.text);
        if (int.Parse(skor.text) > coinBuying && save == false)
        {
            int b = int.Parse(skor.text) - coinBuying;
            skor.text = "" + b;
            coinSave = PlayerPrefs.GetInt("Buying", coinSave);
            coinSave += 10;
            PlayerPrefs.SetInt("Buying", coinSave);
            coinBuy.text = "" + PlayerPrefs.GetInt("Buying", coinSave);
            shieldPlayer = PlayerPrefs.GetFloat("shieldss", shieldPlayer);
            shieldPlayer += 10;
            PlayerPrefs.SetFloat("shieldss", shieldPlayer);
            shield.text = "Shield:" + PlayerPrefs.GetFloat("shieldss", shieldPlayer);
            reduc = PlayerPrefs.GetFloat("ReducesPla", reduc);
            reduc -= 0.5f;
            PlayerPrefs.SetFloat("ReducesPla", reduc);
            PlayerPrefs.SetInt("Coins", b);
            save = true;
        }
    }

}
