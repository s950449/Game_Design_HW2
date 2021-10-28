using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace Platformer.UI
{
    public class StartMenuUIController : MonoBehaviour
    {
        [SerializeField] public Button StartButton;
        public bool isStarted = false;
        // Start is called before the first frame update
        void Start()
        {
            isStarted = false;
            StartButton.onClick.AddListener(StartGame);
            StartButton.Select();

        }

        // Update is called once per frame
        public void StartGame()
        {
            isStarted = true;
            Time.timeScale = 1;
            this.gameObject.SetActive(false);
            
        }
    }
}