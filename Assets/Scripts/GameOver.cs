using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOver : MonoBehaviour
{
    public Image enemyLife;
    public bool enemyState = false;
    public Animator[] animators;
    public PlayerController playerControL;
    public ParticleSystemManager particle;
    public AudioSources audioSources;
    void Start()
    {
        
    }
    void Update()
    {
        GameOverEnemy();
    }
    public void GameOverEnemy()
    {
        if (enemyLife.fillAmount == 0 && enemyState == false)
        {
            animators[0].SetTrigger("Victory");
            animators[1].SetTrigger("DefeatEnemy");
            enemyState = true;
            playerControL.gameOver = true;
            ParticleConfeti();
            AudioPlay();
            StartCoroutine(SceneManage());
        }
    }
    IEnumerator SceneManage()
    {
        yield return new WaitForSeconds(6.5f);
        int levelThree = PlayerPrefs.GetInt("level");
        if (levelThree == 4)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("level") + 1);
        }
        enemyState = false;
    }
    public void ParticleConfeti()
    {
        particle.confeti[0].Play();
        particle.confeti[1].Play();
        particle.confeti[2].Play();
        particle.confeti[3].Play();
    }
    public void AudioPlay()
    {
        AudioSource.PlayClipAtPoint(audioSources.audioClips[0], Vector3.up);
    }
}
