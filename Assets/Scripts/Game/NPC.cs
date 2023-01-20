using Game;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public Player player;
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public GameObject controlsPanel;
    public GameObject continueButton;
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
            controlsPanel.SetActive(false);
            dialoguePanel.SetActive(true);
            StartCoroutine(Typing());
            continueButton.SetActive(true);
        }
    }

    public void HandleLeaveProximity(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            RemoveText();
            continueButton.SetActive(false);
        }
    }

    public void DisplayControls()
    {
        dialogueText.text = "";
        index = 0;
        controlsPanel.SetActive(true);
        continueButton.SetActive(false);
    }

    public void CloseControlsPanel()
    {
        controlsPanel.SetActive(false);
        dialoguePanel.SetActive(true);
        StartCoroutine(Typing());
        continueButton.SetActive(true);
    }
    
    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
