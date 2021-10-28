using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace Platformer.UI
{
    public class DiagramController : MonoBehaviour
    {
        [SerializeField] public Button ContinueButton;

        // Start is called before the first frame update
        void Start()
        {
            ContinueButton.onClick.AddListener(ShowDiagram);
            ContinueButton.Select();

        }

        // Update is called once per frame
        public void ShowDiagram()
        {
            Time.timeScale = 1;
            this.gameObject.SetActive(false);

        }
    }
}