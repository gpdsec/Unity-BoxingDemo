using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public Animator animator;
    public PlayerController playerController;
    public Image staminaEnemy;
    public float enemyStaminaValue;
    public float enemyStaminaIncrease;
    public bool enemyMove = false;
    float enemyLimitPos = 2.5f;
    public float distanceEnemy;
    public AudioSources audios;
    void Start()
    {
        staminaEnemy.fillAmount = 1;
        InvokeRepeating("HitEnemyRandom", 1, 2);
    }
    void Update()
    {
        distanceEnemy = Vector3.Distance(transform.position, player.transform.position);
        EnemyStaminaIncrease();
        BlockEnemy();
        EnemyMove();
        EnemyLook();
        LimitEnemy();
    }
    public void HitEnemyRandom()
    {
        if (distanceEnemy < 1.05f && distanceEnemy > 0.95f && playerController.gameOver == false)
        {
            if (playerController.hit == false && enemyMove == false)
            {
                int options = Random.Range(1, 3);
                switch (options)
                {
                    case 1:
                        animator.SetTrigger("HookRightEnemy");
                        staminaEnemy.fillAmount -= enemyStaminaValue;
                        break;
                    case 2:
                        animator.SetTrigger("HookLeftEnemy");
                        staminaEnemy.fillAmount -= enemyStaminaValue;
                        break;
                    default:
                        break;
                }
            }
        }
    }
    public void EnemyMove()
    {
        if (distanceEnemy < 3 && distanceEnemy > 1.2f && playerController.gameOver == false)
        {
            GetComponent<NavMeshAgent>().destination = player.transform.position;
            Animators("ForwardEnemy", true);
            Animators("BackEnemy", false);
            EnemyMoving(true);
        }
        else if (distanceEnemy < 1.05f && distanceEnemy > 0.95f && playerController.gameOver == false)
        {
            GetComponent<NavMeshAgent>().destination = transform.position;
            Animators("ForwardEnemy", false);
            Animators("BackEnemy", false);
            EnemyMoving(false);
        }
        if (distanceEnemy < 0.95f && playerController.gameOver == false)
        {
            transform.Translate(Vector3.back * Time.deltaTime);
            Animators("ForwardEnemy", false);
            Animators("BackEnemy", true);
            EnemyMoving(true);
        }
    }
    public void Animators(string animation, bool animationBool)
    {
        animator.SetBool(animation, animationBool);
    }
    public void BlockEnemy()
    {
        if (playerController.hit == true && playerController.gameOver == false)
        {
            animator.SetBool("BlockEnemy", true);
        }
        if (playerController.hit == false && playerController.gameOver == false)
        {
            animator.SetBool("BlockEnemy", false);
        }
    }
    public void EnemyLook()
    {
        transform.LookAt(player.transform.position, Vector3.up);
    }
    public void EnemyStaminaIncrease()
    {
        if (enemyMove == false && playerController.gameOver == false)
        {
            staminaEnemy.fillAmount += Time.deltaTime / enemyStaminaIncrease;
        }
    }
    public void EnemyMoving(bool EnemyMove)
    {
        enemyMove = EnemyMove;
    }
    public void LimitEnemy()
    {
        float posX = Mathf.Clamp(transform.position.x, -enemyLimitPos, enemyLimitPos);
        float posZ = Mathf.Clamp(transform.position.z, -enemyLimitPos, enemyLimitPos);
        transform.position = new Vector3(posX, 0, posZ);
    }
}
