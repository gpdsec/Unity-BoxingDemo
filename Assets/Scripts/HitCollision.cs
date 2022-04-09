using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HitCollision : MonoBehaviour
{
    //public Image enemyLife;
    public PlayerController playerControL;
    //public AudioSources audioSources;
    //public ParticleSystemManager particle;
    public float enemyLifeReduce;
    public Light directionalLight;
    public RestartScene restartScenePlayer;
    public GameOver game;
    //public bool enemyState = false;
    //public Animator[] animators;
    public Text point;
    bool coinAdd = false;
    bool enemyLifeBool = false;
    int coin = 0;
    void Start()
    {
        coinAdd = false;
        game.enemyLife.fillAmount = 1;
        point.text = "Coins: " + PlayerPrefs.GetInt("Coins");
    }
    void Update()
    {
        //GameOverEnemy();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyLifeReduce") && game.playerControL.hit == true && enemyLifeBool == false)
        {
            game.enemyLife.fillAmount -= Time.deltaTime * enemyLifeReduce;
            AudioSource.PlayClipAtPoint(game.audioSources.audioClips[1], Vector3.up);
            print("Enemy");
            LightSettings();
            SaveSkor();
            enemyLifeBool = true;
            StartCoroutine(EnemyLifeMan());
        }
        if (collision.gameObject.CompareTag("EnemyLifeReduce")! && enemyLifeBool == false && playerControL.hit == true)
        {
            AudioSource.PlayClipAtPoint(game.audioSources.audioClips[1], Vector3.up);
            enemyLifeBool = true;
            StartCoroutine(EnemyLifeMan());
        }
    }
    IEnumerator EnemyLifeMan()
    {
        yield return new WaitForSeconds(2);
        enemyLifeBool = false;
    }
    public void LightSettings()
    {
        StartCoroutine(LightColor());
    }
    IEnumerator LightColor()
    {
        directionalLight.color = Color.green;
        yield return new WaitForSeconds(0.3f);
        directionalLight.color = Color.white;
    }
    public void SaveSkor()
    {
        if (game.enemyLife.fillAmount == 0 && coinAdd == false)
        {
            coin = PlayerPrefs.GetInt("Coins", coin);
            coin += 30;
            PlayerPrefs.SetInt("Coins", coin);
            point.text = "Coins: " + PlayerPrefs.GetInt("Coins", coin);
            coinAdd = true;
        }
    }
}
