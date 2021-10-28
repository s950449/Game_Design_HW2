using Platformer.Mechanics;
using Platformer.UI;
using UnityEngine;
using UnityEngine.UI;
namespace Platformer.UI
{
    /// <summary>
    /// The MetaGameController is responsible for switching control between the high level
    /// contexts of the application, eg the Main Menu and Gameplay systems.
    /// </summary>
    public class MetaGameController : MonoBehaviour
    {
        /// <summary>
        /// The main UI object which used for the menu.
        /// </summary>
        public MainUIController mainMenu;
        public GameUIController GameOverMenu;
        public StartMenuUIController startMenu;
        public DiagramController alienDiagram;
        private float elapsedTime = 0.0f;
        [SerializeField] private AudioClip notify;
        [SerializeField] private AudioClip endGame;
        [SerializeField] private Text _points;
        [SerializeField] private Text _time;
        [SerializeField] private Text _findAlien;
        /// <summary>
        /// A list of canvas objects which are used during gameplay (when the main ui is turned off)
        /// </summary>
        public Canvas[] gamePlayCanvasii;

        /// <summary>
        /// The game controller.
        /// </summary>
        public GameController gameController;

        bool showMainCanvas = false;
        public bool isGameOver = false;
        bool started = false;
        private bool inDiagram = false;
        void OnEnable()
        {
            _ToggleMainMenu(showMainCanvas);
        }

        /// <summary>
        /// Turn the main menu on or off.
        /// </summary>
        /// <param name="show"></param>
        public void ToggleMainMenu(bool show)
        {
            if (this.showMainCanvas != show)
            {
                _ToggleMainMenu(show);
            }
        }

        void _ToggleMainMenu(bool show)
        {
            if (show)
            {
                Time.timeScale = 0;
                mainMenu.gameObject.SetActive(true);
                foreach (var i in gamePlayCanvasii) i.gameObject.SetActive(false);
            }
            else
            {
                Time.timeScale = 1;
                mainMenu.gameObject.SetActive(false);
                foreach (var i in gamePlayCanvasii) i.gameObject.SetActive(true);
            }
            this.showMainCanvas = show;
        }
        private void Start()
        {
            _findAlien.text = "No";
            Time.timeScale = 0;
            startMenu.gameObject.SetActive(true);
            GameOverMenu.endGame = endGame;
        }
        void Update()
        {
            elapsedTime += Time.deltaTime;
            started = startMenu.isStarted;
            isGameOver = gameController.model.player.gameOver;
            inDiagram = alienDiagram.gameObject.activeSelf;
            if (gameController.model.player.aliensay)
            {
                inDiagram = true;
                gameController.model.player.audioSource.PlayOneShot(notify);
                Time.timeScale = 0;
                gameController.model.player.aliensay = false;
                alienDiagram.gameObject.SetActive(true);
            }
            if (Input.GetButtonDown("Menu")&&!isGameOver&&started&&!inDiagram)
            {
                ToggleMainMenu(show: !showMainCanvas);
            }
            int timeInt = (int)elapsedTime;
            _time.text = timeInt.ToString();
            _points.text = gameController.model.player.score.ToString();
            if (gameController.model.player.canwin)
            {
                _findAlien.text = "Yes";
            }
            if (gameController.model.player.gameOver)
            {
                isGameOver = true;
                Time.timeScale = 0;
                elapsedTime = 0;
                GameOverMenu.gameObject.SetActive(true);
            }
        }

    }
}
