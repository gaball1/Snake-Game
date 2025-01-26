using UnityEngine;
using TMPro; 
public class Timer : MonoBehaviour
{
    public float timeRemaining = 20; 
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;
    public GameOver gameOver; 

    private void Start()
    {
       
        if (Time.timeScale > 0)
        {
            timerIsRunning = true;
        }
        gameOver.HideGameOver(); 
    }

    void Update()
    {
        if (timerIsRunning)
        {
            timeRemaining -= Time.deltaTime; 

            if (timeRemaining < 1)
            {
               
                GameOver();
            }
            DisplayTime(timeRemaining); 
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay <= 0)
        {
            timeText.text = "00:00";
        }
        else
        {
            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60); 
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds); 
        }
    }

    void GameOver()
    {
        timerIsRunning = false; 
        gameOver.ShowGameOver();
    }
}
