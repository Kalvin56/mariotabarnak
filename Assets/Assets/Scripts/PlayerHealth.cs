using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        InvokeRepeating("UpdatePlayerHp", 0f, 2f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdatePlayerHp(){
        currentHealth--;
        healthBar.SetHealth(currentHealth);
    }
}
