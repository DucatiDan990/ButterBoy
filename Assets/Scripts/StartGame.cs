using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    public KeyCode Start;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(Start))
        {
            SceneManager.LoadScene("Level 1");
        }
    }
}
