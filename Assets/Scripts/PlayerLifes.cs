using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLifes : MonoBehaviour
{

    public int lives = 3;

    public float resetDelay = 1f;

  

    public GameObject gameOver;
    public GameObject youWon;
    
    void CheckGameOver()
    {
        if (lives < 1)
        {
            gameOver.SetActive(true);
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

    }

}
