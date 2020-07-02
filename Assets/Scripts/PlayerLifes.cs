using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifes : MonoBehaviour
{

    public int lives = 3;

    public float resetDelay = 1f;

  

    public GameObject gameOver;
    public GameObject youWon;
    
    
    
    // Start is called before the first frame update
    void Start()
    {

    }

    void CheckGameOver()
    {
        if (lives < 1)
        {
            gameOver.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
        }
    }
    

}
