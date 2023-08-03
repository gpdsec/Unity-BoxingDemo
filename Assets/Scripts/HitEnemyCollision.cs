using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HitEnemyCollision : MonoBehaviour
{
    public Image playerLife;
    public PlayerController playerControL;
    private float playerLifeReduce = 4;
    public Light lightDirectional;
    public Animator[] animators;
    public RestartScene restartScene;
    public AudioSources source;
    bool lifeBool = false;
    float playersLifeReduce;
    void Start()
    {
        //playerLife.fillAmount = 1;
    }
    void Update()
    {
        //GameOver();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("LifeReduce") && playerControL.hit == false && lifeBool == false)
        {
            playerLife.fillAmount -= Time.deltaTime * PlayerPrefs.GetFloat("ReducesPla");
            print(PlayerPrefs.GetFloat("ReducesPla"));
            AudioSource.PlayClipAtPoint(source.audioClips[1], Vector3.up);
            print("Player");
            EnemyLightSettings();
            lifeBool = true;
            StartCoroutine(LifeMan());
        }
        if (collision.gameObject.CompareTag("LifeReduce")! && lifeBool == false && playerControL.hit == false)
        {
            AudioSource.PlayClipAtPoint(source.audioClips[1], Vector3.up);
            lifeBool = true;
            StartCoroutine(LifeMan());
        }
    }
    IEnumerator LifeMan()
    {
        yield return new WaitForSeconds(2);
        lifeBool = false;
    }
    public void EnemyLightSettings()
    {
        StartCoroutine(EnemyLightColor());
    }
    IEnumerator EnemyLightColor()
    {
        lightDirectional.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        lightDirectional.color = Color.white;
    }
    public void GameOver()
    {
        if (playerLife.fillAmount == 0)
        {
            restartScene.restart.gameObject.SetActive(true);
        }
        if (playerLife.fillAmount == 0 && playerControL.state == false)
        {
            print(PlayerPrefs.GetInt("level"));
            animators[0].SetTrigger("Defeat");
            animators[1].SetTrigger("VictoryEnemy");
            playerControL.state = true;
            playerControL.gameOver = true;
        }
    }
}
