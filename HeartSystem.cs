using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour
{
    // Configs
    [Header("Health System")] 
    [SerializeField] int playerHealth = 3;
    [SerializeField] int maxNumOfHealth = 3; // when this is equal to 3, I should have only 3 heart containers visible in my scene view
    [SerializeField] Image[] hearts;
    [SerializeField] Sprite fullHeart; // Add full sprite here
    [SerializeField] Sprite emptyHeart; // Add empty heart sprite here



    private void HeartsSystem()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < maxNumOfHealth) // controls how many hearts should be displayed in relation to
                                    // the max allowed health that the player can have
            {                       
                hearts[i].enabled = true;  
            }
            else
            {
                hearts[i].enabled = false; // This hides any extra hearts in the array that we have, that is more than maxNumOfHealth.
            }
            
            if (i < playerHealth) // controls which type of heart is displayed
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }

    // when pick up a heart powerup
    public void HealthUpdate()
    {
        if (playerHealth < maxNumOfHealth)
        {
            playerHealth++;
        }
        // Adds an extra full heart if player picks up a heart while is full health
        else if (playerHealth == maxNumOfHealth)
        {
            maxNumOfHealth++;
            playerHealth++;
        }
    }
}
