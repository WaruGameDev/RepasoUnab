using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager sGameManager;
    public List<GameObject> hearts;
    public Health healthPlayer;
    public int monedas;
    public TextMeshProUGUI monedasUI;

    private void Awake()
    {
        
        sGameManager = this;
    }

    private void Start()
    {
        UpdateUI();
        UpdateHearts();
    }

    public void UpdateUI()
    {
        monedasUI.text = monedas.ToString();
    }
    public void AddCoin(int amount)
    {
        monedas += amount;
        UpdateUI();
    }
    public void UpdateHearts()
    {
        foreach (GameObject heart in hearts)
        {
            heart.SetActive(false);
        }
        for (int i = 0; i < healthPlayer.health; i++)
        {
            hearts[i].SetActive(true);
        }
    }
}
