using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuScreen : ScreenBase
{

    public TextMeshProUGUI highScoreText;

    public override void Show()
    {
        base.Show();
        highScoreText.text = PlayerPrefs.GetInt("highScore", 0).ToString();
    }

    public void StartGame()
    {
        App.gameManager.StartGame();
        Hide();
    }
}
