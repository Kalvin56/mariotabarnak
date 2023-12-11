using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public Chronometer chrono;

    public GameObject ath;

    public GameObject gameOver;

    private bool gameEnded;



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        InvokeRepeating("UpdatePlayerHp", 0f, 2f);
        gameEnded = false;
        ath.SetActive(true);
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdatePlayerHp(){
        currentHealth--;
        healthBar.SetHealth(currentHealth);
        if (currentHealth < 1 && !gameEnded)
        {
            EndGame();
        }
    }

    public void HealPlayer(int healingAmount)
    {
        currentHealth = Mathf.Min(currentHealth + healingAmount, maxHealth);
        healthBar.SetHealth(currentHealth);
    }

    public void EndGame()
    {
        gameEnded = true;
        var finalTime = chrono.timeText.text;
        SimpleDB.addScore(null, finalTime);
        ath.SetActive(false);
        gameOver.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }
}
