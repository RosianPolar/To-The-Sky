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
    public int healthAmount;
    public Image healthBar;
    public Transform checkpoint;
    public GameObject playerShield;


    void Start()
    {
        // create checkpoint control object
        checkpoint = GameObject.FindGameObjectWithTag("CheckPoint").transform;
    }

    private void Update()
    {
        if (healthAmount <= 0) SceneManager.LoadScene("EnemyTesting");
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("TakeDamage");
        if(!playerShield.activeSelf){
             healthAmount -= damage;
            healthBar.fillAmount = healthAmount / 10;
        }

    } 

    public void Heal(int healPoints)
    {
        healthAmount += healPoints;
        healthAmount = Mathf.Clamp(healthAmount, 0, 10);

        healthBar.fillAmount = healthAmount / 10; 
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider != null && hit.collider.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(5);
        }
    }
}
