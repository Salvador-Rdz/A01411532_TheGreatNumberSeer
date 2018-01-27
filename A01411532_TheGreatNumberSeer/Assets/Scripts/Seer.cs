using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Seer : MonoBehaviour {
    //Variables
    private int min;
    private int max;
    private int guess;
    private int attempts;
    //Links to labels
    public Text guessLabel;
    public Text attemptsLabel;
    public Text seerLabel;
    //Instantiated level manager.
    LevelManager levelManager;

    private void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        StartGame(levelManager.difficulty);
    }
    //receives the difficulty from the levelmanager modified in the main menu.
    public void StartGame(int difficulty)
    {
        //Sets the min/max and attempts depending on the chosen difficulty.
        switch(difficulty)
        {
            case 0:
                min = 1;
                max = 1001;
                attempts = 5;
                break;
            case 1:
                min = 1;
                max = 501;
                attempts = 5;
                break;
            case 2:
                min = 1;
                max = 101;
                attempts = 10;
                break;
            default:
                    print("This probably shouldn't have happened."); //Really shouldn't.
                break;
        }
        NextGuess();
        ShowGuess();
    }
    private void NextGuess()
    {
        guess = Random.Range(min,max);
        attempts--;
        //Flavor emojis
        if (attempts < 2)
        {
            seerLabel.text = " ಥ﹏ಥ ";
        }
        else if(attempts <4)
        {
           seerLabel.text = " ᕙ(⇀‸↼‶)ᕗ ";
        }
    }
    void ShowGuess()
    { 
        //Updates the attempts label.
        attemptsLabel.text = "Attempts: " + attempts;
        if (attempts >= 0)
        {
            guessLabel.text = "Is your number " + guess + "?";
        }
        else
        {
            levelManager.LoadLevel("Win");
        }
        
    }
    //Used to modify the search ranges depending on the choice.
    public void GuessHigher()
    {
        min = guess+1;
        NextGuess();
        ShowGuess();
    }
    public void GuessLower()
    {
        max = guess;
        NextGuess();
        ShowGuess();
    }
    //Moves you to the loss screen.
    public void CorrectGuess()
    {
        levelManager.LoadLevel("Lost");
    }
}
