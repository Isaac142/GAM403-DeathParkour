using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public float timer = 0f;
    public int health = 100;
    public bool isPaused = false;
    public UIManager UI;

    void Start()
    {
        
    }

    void Update()
    {

        if (!isPaused && timer >= 0)
        {
            timer += Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            UI.Pause(isPaused);
        }
        
    }
}
