using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform respawnPoint;


    public void RespawnPlayer()
    {
        transform.position = respawnPoint.position;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.zero;        
    }
    public void Update()
    {
        if (transform.position.y < -10)
        {
            RespawnPlayer();
        }
    }
}
