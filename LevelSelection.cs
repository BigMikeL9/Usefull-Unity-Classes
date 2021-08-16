using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
    

/// <summary>
/// This script controls Level Selection (Locking & Unlocking Levels)
/// </summary>
public class LevelSelection : MonoBehaviour
{
    // Configs
    [SerializeField] Button[] levelButtons;
    
    // Cache
    int currentSceneIndex;
    int nextSceneLoadIndex;
    string CURRENT_LEVEL_KEY = "currentLevel";

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        LevelSelect();
        WinCondition();
    }

    // Makes buttons interactable, depending on what level we are in.
    private void LevelSelect()
    {
        // set the key value for "levelAt" to be the build Index in which the level selection scene is in
        int currentLevel = PlayerPrefs.GetInt(CURRENT_LEVEL_KEY, 2);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 2 > currentLevel)
            {
                levelButtons[i].interactable = false;
            }
        }
    }
    
    private void WinCondition()
    {
        if (true) // Whatever happens in order to win a level?
        {
            if (currentSceneIndex == 10) // "10" refers to the last level build index in your build settings
            {
                Debug.Log("YOU WON THE GAAAAMEE!!!");
                // Show Win Screen or Canvas
            }
            else
            {
                // Move to next level
                LoadNextScene();
                
                // And update the CURRENT_LEVEL_KEY value in the playerprefs
                UpdateCurrentLevelPlayerPref();
            }
            
        }
    }


    private void LoadNextScene()
    {
        nextSceneLoadIndex = SceneManager.LoadScene(currentSceneIndex + 1);
    }
        
    
    // Updates the PlayerPrefs value, depending on what level we are at.
    private void UpdateCurrentLevelPlayerPref()
    {
        if (nextSceneLoadIndex > PlayerPrefs.GetInt(CURRENT_LEVEL_KEY))
        {
            PlayerPrefs.SetInt(CURRENT_LEVEL_KEY, nextSceneLoadIndex);
        }
    }
    
    // Resets PlayerPrefs to default value. Deletes all saved progress
    private void DeletePlayerPrefs()
    {
        if (true) // A Reset Game button is pressed or the player finishes the game
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
