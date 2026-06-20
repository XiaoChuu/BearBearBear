using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneChanger : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        quitGame();
    }

    public void nextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void quitGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
