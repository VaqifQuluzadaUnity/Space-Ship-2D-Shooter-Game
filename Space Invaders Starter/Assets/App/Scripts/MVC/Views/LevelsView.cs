using UnityEngine;
using UnityEngine.SceneManagement;

namespace GalaxyDefenders.MVC
{
    public class LevelsView : MonoBehaviour
    {
        [Header("Controller reference")]
        [SerializeField] private LevelsController controller;

        [Header("View references")]
        [SerializeField] private GameObject levelsView;
        [SerializeField] private GameObject menuView;

        public void Back()
        {
            levelsView.SetActive(false);
            controller.Back();
            menuView.SetActive(true);
        }

        public void Level1Button()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Main");
            controller.Level1Button();
        }

        public void Level2Button()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Level 2");
            controller.Level2Button();
        }

        public void Level3Button()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Level 3");
            controller.Level3Button();
        }

        public void Level4Button()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Level 4");
            controller.Level4Button();
        }

        public void Level5Button()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Level 5");
            controller.Level1Button();
        }

        public void Level6Button()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Level 6");
            controller.Level1Button();
        }

        public void Level7Button()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Level 7");
            controller.Level1Button();
        }

        public void Level8Button()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Level 8");
            controller.Level1Button();
        }

        public void Level9Button()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Level 9");
            controller.Level1Button();
        }

        public void Level10Button()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Level 10");
            controller.Level10Button();
        }

        public void Level11Button()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Level 11");
            controller.Level11Button();
        }
    }
}
