using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerLevel : MonoBehaviour
{
    public enum Jobs
    {
        PALADIN,
        MAGO
    }
    public Jobs jobs;
    public Transform arma;

    //int, float, string y bool
    public int level = 1;
    public float exp;
    public float expToNextLevel = 10;
    public float str = 1;
    public float def = 1;
    public float agi = 1;


    [Header("UI")]
    public Text levelText;
    public Image expBar;

    private void OnMouseDown()
    {
        ManagerCharacters.staticManagersCharacters.playerSeleccionado = this;
        ManagerCharacters.staticManagersCharacters.Seleccionar();        
    }


    private void Start()
    {
        DisplayLevel();
    }
    public void GainExp(float expGained)
    {
        exp += expGained;
        
        if (exp >= expToNextLevel)
        {
            LevelUpPlayer();
            DisplayExp(0);
        }
        else
        {
            DisplayExp(0.5f);
        }
    }
    public void LevelUpPlayer()
    {
        level++;
        exp -= expToNextLevel;
        expToNextLevel *= 1.5f;
        DisplayLevel();
        LevelUpStats();
        
    }
    public void DisplayLevel()
    {
        levelText.text = "Lv. " + level + "\n" + "str " + (int)str + " def " + (int)def + " agi " + (int)agi;

    }
    public void DisplayExp(float time)
    {
        expBar.DOFillAmount(ProgressBar(), time);
    }
    public void LevelUpStats()
    {
        switch(jobs)
        {
            case Jobs.PALADIN:
                str *= 2;
                def *= 1.5f;
                agi *= 1.3f;
                break;
            case Jobs.MAGO:
                str *= 1.2f;
                def *= 1.1f;
                agi *= 1.8f;
                break;
        }
    }
    float ProgressBar()
    {
        return exp / expToNextLevel;
    }

}
