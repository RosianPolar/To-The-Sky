using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private float healthAmount = 100;
    public Image healthBar;

    public Health(int health)
    {
        this.healthAmount = health;
    }
    

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100;
        
        if (healthAmount <= 0)
        {
            healthAmount = 0;
        }
    } 

    public void Heal(float healPoints)
    {
        healthAmount += healPoints;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount / 100; 
    } 
}
