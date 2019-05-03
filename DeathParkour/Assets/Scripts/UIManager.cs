using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public bool isTitleScreen;
    public GameObject pausePanel;
    public GameObject inGamePanel;
    public GameManager GM;

    [Header("In Game UI")]
    public TextMeshProUGUI timerText;
    public Image healthBar;
    public GameObject winText;
    public GameObject winButton;

    void Start()
    {
        
    }

    //The F2 is rounding up the timer to 2 decimal points.
    void Update()
    {
        if(!isTitleScreen)
        {
            timerText.text = GM.timer.ToString("F2");

            healthBar.fillAmount = GM.health / 100f;
        }
    }

    //Loading level, used on the Title screen buttons and the return to title screen button in the game pause menu.
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    //Close the application completely when the Quit button is pressed
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Pause(bool pause)
    {
        
        if(pausePanel != null)
        {
            pausePanel.SetActive(pause);
            inGamePanel.SetActive(!pause);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.CompareTag("Win"))
    //    {
    //        Debug.Log("You Win");
    //    }
    //}
}
