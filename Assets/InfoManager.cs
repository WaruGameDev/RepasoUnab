using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoManager : MonoBehaviour
{
    public Text info;
    private void Start()
    {
        StartCoroutine(ShowInfo());
    }
    public IEnumerator ShowInfo()
    {
        while(true)
        {
            info.text = CantidadDePlayers().ToString();
            yield return new WaitForSeconds(0.5f);

        }
        
    }
    public int CantidadDePlayers()
    {
        return ManagerCharacters.staticManagersCharacters.players.Count;
    }
}
