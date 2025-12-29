using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    public int MaxHealth;
    public Image[] Hearts;
    public GameObject DiePanel;
    public Collider HealthZone; 
    public int EnemiesToKillForWin = 5;

    private int _currentHealth;
    private int _enemiesKilled = 0;

    void Start()
    {
        _currentHealth = MaxHealth;
        UpdateHearts();
        DiePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
            TakeDamage(1); 
    }

    void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        UpdateHearts();

        if (_currentHealth <= 0)
            GameOver();
    }

    void UpdateHearts()
    {
        for (int i = 0; i < Hearts.Length; i++)
            Hearts[i].enabled = (i < _currentHealth);
    }

    public void IncrementEnemiesKilled()
    {
        _enemiesKilled++;
        if (_enemiesKilled >= EnemiesToKillForWin)
            GameOver();
    }

    void GameOver()
    {
        DiePanel.SetActive(true);
        Time.timeScale = 0f;
    }
}