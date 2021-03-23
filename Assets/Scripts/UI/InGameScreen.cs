using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameScreen : ScreenBase
{

    public TextMeshProUGUI scoreText;

    public override void Show()
    {
        base.Show();    // gameobject.setActive(true);
        App.gameManager.playerInstance.onScoreChanged.AddListener(UpdateScore);
        UpdateScore();
    }

    public void ReturnToMenu()
    {
        App.gameManager.GoToMenu();
        Hide();
    }

    public void UpdateScore()
    {
        scoreText.text = App.gameManager.playerInstance.score.ToString();
    }
}
