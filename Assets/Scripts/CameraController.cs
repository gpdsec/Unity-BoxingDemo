using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position + new Vector3(5, 1, -2), 1);
        transform.rotation = player.transform.rotation;
    }
}
