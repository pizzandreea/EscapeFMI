using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

namespace Game
{

    public class PauseMenu : MonoBehaviour
    {
        public GameObject pauseMenu;
        public bool isPaused;

        public void Start()
        {
            pauseMenu.SetActive(false);
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPaused)
                {
                    Game.Floating.Range = 0.0f;
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                }
            }
        }

        public void PauseGame()
        {
            Game.Floating.Range = 0.0f;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }

        public void ResumeGame()
        {
            Game.Floating.Range = 0.00007f;
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
        }
    }
}