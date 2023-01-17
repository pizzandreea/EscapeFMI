﻿using System.Collections;
using TMPro;
using UnityEngine;

namespace Game
{
    public class Door : MonoBehaviour
    {
        private Inventory _inventory;
        public SpriteRenderer spriteRenderer;
        public Sprite doorOpenSprite;

        public bool doorOpen, waitingToOpen;
        public TextMeshProUGUI notificationText;

        [SerializeField]
        private AudioSource openDoor;
        
        public void Start()
        {
            _inventory = GameManager.Instance.inventory;
        }

        private void Update()
        {
            if (waitingToOpen)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    openDoor.Play();
                    waitingToOpen = false;
                    doorOpen = true;
                    spriteRenderer.sprite = doorOpenSprite;
   
                    _inventory.UseItem("Key");
                }
            }
            else if (doorOpen)
            {
                spriteRenderer.sprite = doorOpenSprite;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") && !doorOpen)
            {
                if (_inventory.HasItem("Key"))
                {
                    waitingToOpen = true;
                    StartCoroutine(SendNotification("Press E to open the door", 3));
                }
                else
                {
                    StartCoroutine(SendNotification("You need a key to unlock the door", 3));
                }
            }
        }

        private IEnumerator SendNotification(string text, int time)
        {
            notificationText.text = text;
            yield return new WaitForSeconds(time);
            notificationText.text = "";
        }
    }
}