using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 3;

    public void TakeDamage(int amount)
    {
        health -= amount;
        GameManager.sGameManager.UpdateHearts();
        if(health <= 0)
        {
            Debug.Log("i am ded");
        }
    }
}
