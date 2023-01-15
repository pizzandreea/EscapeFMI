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
 
    public void HandleEnterProximity(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            dialoguePanel.SetActive(true);
        }
    }

    public void HandleLeaveProximity(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            dialoguePanel.SetActive(false);
        }
    }
}
