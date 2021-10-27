using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace Platformer.UI
{
    public class GameUIController : MonoBehaviour
    {
        [SerializeField] public Button RetryButton;
        [SerializeField] public Button QuitButton;
        private bool gameOver = false;
        private bool retry = false;
        // Start is called before the first frame update
        void Start()
        {
            QuitButton.onClick.AddListener(QuitGame);
            RetryButton.onClick.AddListener(Retry);
            RetryButton.Select();
        }

        // Update is called once per frame

        private void QuitGame()
        {
            Application.Quit();
        }
        private void Retry()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Main");
           
        }
    }
}