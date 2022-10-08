using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats
{
    //reference to the player
    private GameObject playerRef = GameObject.FindGameObjectWithTag("Player");

    //health variables
    private const float maxHealth = 100;
    private float currentHealth;
    private float armor;

    //extra-lives
    public int maxLives;
    public int livesRemaining;

    //take damage
    void takeDamage(float damageAmount)
    {
        currentHealth -= currentHealth - damageAmount; 
    }
    //heal
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }
    // Update is called once per frame
    void Update()
    {
        //if the player's health falls below 0
        //respawn them at their spawn point
        //and deduct one life
        if(currentHealth <= 0)
        {
            
        }
    }

    
}
