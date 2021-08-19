using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Sprite[] livesImage;
    public Image displayLivesImage;
    int score;
    [SerializeField] Text scoreText;
    [SerializeField] GameObject gameOverScreen;

    public void UpdateLives(int currentLives)
    {
        displayLivesImage.sprite = livesImage[currentLives];
    }
    public void UpdateScore()
    {
        score++;
        scoreText.text = "Score : " + score;
    }
    public void GameOverScreenOn()
    {
        gameOverScreen.SetActive(true);
        //to show gameover screen
    }
    public void GameOverScreenOff()
    {
        //to hide gameover screen
        gameOverScreen.SetActive(false);

    }
}
