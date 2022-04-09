using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public GameObject enemy;
    public Image playerStamina;
    public bool hit = false;
    public bool block = false;
    public bool movePlayer = false;
    public float playerStaminaValue;
    public float playerStaminaIncrease;
    public EnemyController enemyController;
    float limitPos = 2.5f;
    float speed = 0.5f;
    float wait = 1.7f;
    float pos = 1, posZero = 0;
    public bool gameOver = false;
    float posLimit = 0.95f;
    public bool state = false;
    public AudioSources audios;
    float rotY = 23;
    void Start()
    {
        playerStamina.fillAmount = pos;
        PlayerPrefs.SetInt("level", SceneManager.GetActiveScene().buildIndex);
    }
    void Update()
    {
        Move();
        Hook();
        Block();
        Limit();
        StaminaIncrease();
    }
    public void Forward()
    {
        if (Input.GetKey(KeyCode.UpArrow) && gameOver == false && enemyController.distanceEnemy > posLimit)
        {
            animator.SetBool("Forward", true);
            Moving(posZero, posZero, pos);
            MovePlayer(true);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            animator.SetBool("Forward", false);
            MovePlayer(false);
        }
    }
    public void Backward()
    {
        if (Input.GetKey(KeyCode.DownArrow) && gameOver == false)
        {
            animator.SetBool("Backward", true);
            Moving(posZero, posZero, -pos);
            MovePlayer(true);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            animator.SetBool("Backward", false);
            MovePlayer(false);
        }
    }
    public void Right()
    {
        if (Input.GetKey(KeyCode.RightArrow) && gameOver == false)
        {
            animator.SetBool("Right", true);
            Moving(pos, posZero, posZero);
            MovePlayer(true);
            transform.Rotate(0, -rotY * Time.deltaTime, 0);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetBool("Right", false);
            MovePlayer(false);
            transform.Rotate(0, 0, 0);
        }
    }
    public void Left()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && gameOver == false)
        {
            animator.SetBool("Left", true);
            Moving(-pos, posZero, posZero);
            MovePlayer(true);
            transform.Rotate(0, rotY * Time.deltaTime, 0);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetBool("Left", false);
            MovePlayer(false);
            transform.Rotate(0, 0, 0);
        }
    }
    public void Block()
    {
        if (Input.GetKey(KeyCode.Space) && gameOver == false)
        {
            animator.SetBool("Block", true);
            BlockBool(true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("Block", false);
            BlockBool(false);
        }
    }
    public void HookRight()
    {
        if (Input.GetKeyDown(KeyCode.D) && hit == false && gameOver == false)
        {
            animator.SetTrigger("HookRight");
            HitBool(true);
            StartCoroutine(Hit());
            PlayerStamina();
        }
    }
    public void HookLeft()
    {
        if (Input.GetKeyDown(KeyCode.A) && hit == false && gameOver == false)
        {
            animator.SetTrigger("HookLeft");
            HitBool(true);
            StartCoroutine(Hit());
            PlayerStamina();
        }
    }
    IEnumerator Hit()
    {
        yield return new WaitForSeconds(wait);
        hit = false;
    }
    public void PlayerStamina()
    {
        playerStamina.fillAmount -= playerStaminaValue;
    }
    public void HitBool(bool Hit)
    {
        hit = Hit;
    }
    public void BlockBool(bool Block)
    {
        block = Block;
    }
    public void MovePlayer(bool MovePlayer)
    {
        movePlayer = MovePlayer;
    }
    public void Moving(float moveX, float moveY, float moveZ)
    {
        transform.Translate(new Vector3(moveX, moveY , moveZ) * Time.deltaTime * speed);
    }
    public void Move()
    {
        Forward();
        Backward();
        Right();
        Left();
    }
    public void Hook()
    {
        HookRight();
        HookLeft();
    }
    public void Limit()
    {
        float posX = Mathf.Clamp(transform.position.x, -limitPos, limitPos);
        float posZ = Mathf.Clamp(transform.position.z, -limitPos, limitPos);
        transform.position = new Vector3(posX, 0, posZ);
    }
    public void Look()
    {
        transform.LookAt(enemy.transform.position, Vector3.up);
    }
    public void StaminaIncrease()
    {
        if (movePlayer == false && gameOver == false)
        {
            playerStamina.fillAmount += Time.deltaTime / playerStaminaIncrease;
        }
    }
}
