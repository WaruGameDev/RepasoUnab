using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DialogueTalk : MonoBehaviour
{
    public List<Dialogue> dialogos;
    private GameObject player;
    public bool isPlayer;
    public int index;
    public bool movingWhileTalking;
    public Animator animNPC;
    public Item itemApedir;



    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            player = other.gameObject;
            isPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = null;
            isPlayer = false;
        }
    }
    public void Update()
    {
        if(player != null)
        {
            if(player.transform.position.x < transform.position.x)
            {
                transform.DORotate(new Vector3(0, 180, 0), 0.5f);
            }
            else
            {
                transform.DORotate(new Vector3(0, 0, 0), 0.5f);
            }
        }
        if(isPlayer && Input.GetKeyDown(KeyCode.F))
        {
            ShowTalk();
        }
    }
    public void ShowTalk()
    {
        if(index == 0)
        {
            animNPC.SetBool("Talking", true);
            DialogueManager.sDialogueManager.MovePanel(true);
            if(!movingWhileTalking)
            {
                player.GetComponent<PlayerPlatformController>().enabled = false;
            }
        }
        if(index <dialogos.Count)
        {
            DialogueManager.sDialogueManager.ShowDialogue(dialogos[index]);
        }
        if(index == dialogos.Count)
        {
            DialogueManager.sDialogueManager.MovePanel(false);
            index = 0;
            animNPC.SetBool("Talking", false);
            InventoryManager.sInventoryManager.RemoveItem(itemApedir, 1);
            if (!movingWhileTalking)
            {
                player.GetComponent<PlayerPlatformController>().enabled = true;
            }
        }
        else
        {
            index++;

        }

    }
}
