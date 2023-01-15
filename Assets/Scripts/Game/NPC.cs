using Game;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public Player player;
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index = 0;

    public float wordSpeed;

    private void Start()
    {
        dialogueText.text = "";
    }
    
    public void RemoveText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            RemoveText();
        }
    }
    public void HandleEnterProximity(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            dialoguePanel.SetActive(true);
            StartCoroutine(Typing());
        }
    }

    public void HandleLeaveProximity(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            RemoveText();
        }
    }
}
