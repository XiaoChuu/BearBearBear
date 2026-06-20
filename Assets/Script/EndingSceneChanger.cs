using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingSceneChanger : MonoBehaviour
{
    void Update()
    {
        quitGame();
    }

    public void backToMenuScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    void quitGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
