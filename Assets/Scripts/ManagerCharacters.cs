using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

public class ManagerCharacters : MonoBehaviour
{
    public static ManagerCharacters staticManagersCharacters;
    public PlayerLevel playerSeleccionado;
    public List<GameObject> weapons;
    public List<GameObject> players;

  

    private void Awake()
    {
        
        players.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        staticManagersCharacters = this;
        GiveWeapon();
        foreach (GameObject player in players)
        {
            player.GetComponent<Outline>().enabled = false;
        }
    }
    public void LevelUp(float amount)
    {
        if(playerSeleccionado != null)
        {
            playerSeleccionado.GainExp(amount);

        }
    }
    public void Seleccionar()
    {
        foreach (GameObject player in players)
        {
            player.GetComponent<Outline>().enabled = false;
        }
        playerSeleccionado.GetComponent<Outline>().enabled = true;
    }

    public void GiveWeapon()
    {
        foreach(GameObject player in players)
        {
            PlayerLevel playerLevel = player.GetComponent<PlayerLevel>();
            switch(playerLevel.jobs)
            {
                case PlayerLevel.Jobs.PALADIN:
                    Instantiate(weapons[0], playerLevel.arma.position, Quaternion.identity);
                    break;
                case PlayerLevel.Jobs.MAGO:
                    Instantiate(weapons[1], playerLevel.arma.position, Quaternion.identity);
                    break;
            }            
        }
    }
    
}
