using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//the player starts off with 10 points of health
//chasers deal 5 points of damage: 2 hit kills
//turrets deal 2 points of damage: 5 hit kills
public class Health : MonoBehaviour
{
    public PlayerRespawn playerRespawn;
    public Transform checkpoint;
    public GameObject playerShield;

    public int maxHealth = 10;
    public int healthAmount;

    public HealthBar healthBar;
    

    void Start()
    {
        healthAmount = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (healthAmount <= 0)  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("TakeDamage");
        if(!playerShield.activeSelf)
        {
            healthAmount -= damage;

            healthBar.SetHealth(healthAmount);
        }
    } 

    public void Heal(int healPoints)
    {
        healthAmount += healPoints;
        healthAmount = Mathf.Clamp(healthAmount, 0, 10);

        healthBar.SetHealth(healthAmount);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider != null && hit.collider.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(5);
        }
    }
}
