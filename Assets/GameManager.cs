using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager sGameManager;
    public int monedas;
    public TextMeshProUGUI monedasUI;

    private void Awake()
    {
        sGameManager = this;
    }

    private void Start()
    {
        UpdateUI();
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
}
