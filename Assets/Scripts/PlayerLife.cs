using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{

    public int lives = 3;
    public int Toast = 14;
    public float resetDelay = 0.4f;
    public Text LivesText;


    public GameObject gameOver;
    public GameObject youWon;

    void CheckGameOver()
    {
        if (lives == 0)
        {
            gameOver.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
        }
    }

    public void wingame()
    {
        if (Toast == 0)
        {
            youWon.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
        }
    }

    void Reset()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start Screen");
    }

    public void LoseLife()
    {
        lives -= 1;
        LivesText.text = "Lives: " + lives;
        CheckGameOver();
    }

    void Update()
    {
            
    }
}