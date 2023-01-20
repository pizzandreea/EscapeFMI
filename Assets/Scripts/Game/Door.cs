using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class Door : MonoBehaviour
    {
        private Inventory _inventory;
        public SpriteRenderer spriteRenderer;
        public Sprite doorOpenSprite;

        public bool doorOpen, waitingToOpen;
        public TextMeshProUGUI notificationText;
        public bool goToNextLevel;

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
                    gameObject.layer = 7;

                    if (goToNextLevel && (GameManager.Instance.inventory.ItemCount("Key") >= 1 || SceneManager.GetActiveScene().name != "Floor 0"))
                    {
                        if (GameManager.Instance.inventory.ItemCount("Scroll") < GetScrollsCount())
                        {
                            if (GameManager.Instance.inventory.ItemCount("Key") >= 1)
                            {
                                StartCoroutine(SendNotification("You should take the scroll before moving to the next level", 3));
                            }
                            else
                            {
                                Player.HandleDeath();
                            }
                        }
                        else 
                        {
                            Invoke(nameof(GoToNextLevel), 1.0f);
                        }
                    }
                    else if (goToNextLevel && GameManager.Instance.inventory.ItemCount("Key") < 1)
                    {
                        StartCoroutine(SendNotification("Make sure to take all the keys before moving to the next level", 3));
                    }
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
            else if (doorOpen)
            {
                if (goToNextLevel && GameManager.Instance.inventory.ItemCount("Key") >= 1)
                {
                    if (GameManager.Instance.inventory.ItemCount("Scroll") < GetScrollsCount())
                    {
                        StartCoroutine(SendNotification("You should take the scroll before moving to the next level", 3));
                    }
                    else 
                    {
                        Invoke(nameof(GoToNextLevel), 1.0f);
                    }
                }
                else if (goToNextLevel && GameManager.Instance.inventory.ItemCount("Key") < 1)
                {
                    StartCoroutine(SendNotification("Make sure to take all the keys before moving to the next level", 3));
                }
            }
        }

        private IEnumerator SendNotification(string text, int time)
        {
            notificationText.text = text;
            yield return new WaitForSeconds(time);
            notificationText.text = "";
        }

        private void GoToNextLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        private int GetScrollsCount()
        {
            var scrollsCount = 1;
                    
            if (SceneManager.GetActiveScene().name == "Floor 1")
            {
                scrollsCount = 2;
            } 
            else if (SceneManager.GetActiveScene().name == "Floor 2")
            {
                scrollsCount = 3;
            }
            
            return scrollsCount;
        }
    }
}