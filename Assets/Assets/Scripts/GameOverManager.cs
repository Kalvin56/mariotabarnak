using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void ReplayGame()
    {
        // Chargez la scène actuelle pour rejouer
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameObject gameOver = GameObject.Find("GameOver");
        gameOver.SetActive(false);
        Time.timeScale = 1f;
    }

    public void StopGame()
    {
        // Quittez l'application (fonctionne uniquement dans le build final)
        Application.Quit();
    }
}
