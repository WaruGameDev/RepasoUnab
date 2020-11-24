using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    public Item item;
    public int amount = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("DetectorMoneda"))
        {
            transform.DOMove(other.transform.position, 0.5f);
        }
        if(other.CompareTag("Player"))
        {
            GameManager.sGameManager.AddCoin(amount);
            InventoryManager.sInventoryManager.AddItem(item);
            Destroy(gameObject);
        }
    }    
    

}
