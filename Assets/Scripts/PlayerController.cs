using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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
    public Vector3 moveDirection;
    public Transform target;
    float x, y, z;
    void Start()
    {
        playerStamina.fillAmount = pos;
        PlayerPrefs.SetInt("level", SceneManager.GetActiveScene().buildIndex);
    }
    void Update()
    {
        // Move();
        // Hook();
        // Block();
        // Limit();
        // StaminaIncrease();
        //x = 0.203f;
        //y = 1.25f;
        //z = 0.423f;
        //x = 0.032f;
        //y = 1.194f;
        //z = 0.418f;
        x = 0.2441f;
        y = 1.2576f;
        z = 0.4681f;
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection = new Vector3(x, y, z);
            //target.Translate(Vector3.forward + moveDirection, Space.Self);
            target.position = moveDirection;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            target.position = new Vector3(0.1434626f, 1.213162f, 0.189629f);
        }



    }
    public void Forward()
    {
        if (Input.GetKey(KeyCode.UpArrow))
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
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetTrigger("HookRight");
            HitBool(true);
            //StartCoroutine(Hit());
            //PlayerStamina();
        }
    }
    public void HookLeft()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetTrigger("HookLeft");
            HitBool(true);
            //StartCoroutine(Hit());
            //PlayerStamina();
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
        // transform.LookAt(enemy.transform.position, Vector3.up);
    }
    public void StaminaIncrease()
    {
        if (movePlayer == false && gameOver == false)
        {
            playerStamina.fillAmount += Time.deltaTime / playerStaminaIncrease;
        }
    }
}
