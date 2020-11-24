using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
[System.Serializable]
public class Dialogue
{
    public string nameCharacter;
    public string dialogue;
    public Sprite portrait;
}

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager sDialogueManager;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Image portrait;

    public RectTransform panelDialogue;
    public RectTransform final;
    public float speedAnimation = 0.5f;
    private Vector3 posInicial;    

    private void Awake()
    {
        sDialogueManager = this;
        posInicial = panelDialogue.position;
    }

    public void ShowDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.nameCharacter;
        dialogueText.text = dialogue.dialogue;
        portrait.sprite = dialogue.portrait;
    }
    public void MovePanel(bool show)
    {
        if(show)
        {
            panelDialogue.DOMoveY(final.position.y, speedAnimation);
        }
        else
        {
            panelDialogue.DOMoveY(posInicial.y, speedAnimation);
        }
    }    

}
