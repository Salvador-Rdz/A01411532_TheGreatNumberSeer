using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    [HideInInspector]
    public int difficulty;
    public static LevelManager levelManager;

    void Awake()
    {
        //Initializing the Singleton Design Pattern for the Audio Manager
        if (levelManager == null)
        {
            DontDestroyOnLoad(gameObject);
            levelManager = this;
        }
        else if (levelManager != this) Destroy(gameObject);
    }
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
    public void EndGame()
    {
        Application.Quit();
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    //Sets the difficulty of the level, called when moving to the game.
    public void chooseDifficulty(int diff)
    {
        LevelManager.levelManager.difficulty = diff;
    }
}
