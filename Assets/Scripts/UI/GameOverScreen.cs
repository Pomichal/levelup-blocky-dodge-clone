using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScreen : ScreenBase
{

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI newHighScoreText;
    public TextMeshProUGUI highScoreText;

    public override void Show()
    {
        base.Show();
        int highScore = PlayerPrefs.GetInt("highScore");
        scoreText.text = App.gameManager.lastScore.ToString();
        highScoreText.text = highScore.ToString();

        if(highScore == App.gameManager.lastScore)
        {
            newHighScoreText.text = "New high score!";
        }
        else
        {
            newHighScoreText.text = "High score:";
        }
    }

    public void PlayAgain()
    {
        App.gameManager.StartGame();
        Hide();
    }

    public void ReturnToMenu()
    {
        App.gameManager.GoToMenu();
        Hide();
    }
}
