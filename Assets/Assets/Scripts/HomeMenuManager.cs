using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeMenuManager : MonoBehaviour
{
    public void StartGame() 
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ShowLeaderBoard()
    {
        SceneManager.LoadScene("LeaderBoardScene");
    }

    public void StopGame()
    {
        // Quittez l'application (fonctionne uniquement dans le build final)
        Application.Quit();
    }
}
