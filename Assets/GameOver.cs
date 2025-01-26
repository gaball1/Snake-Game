using UnityEngine;
using TMPro; 

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TextMeshProUGUI messageText; 

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }
    }

    public void ShowGameOver()
    {
        Time.timeScale = 0; 
        gameOverPanel.SetActive(true); 
        messageText.text = "Game Over!\n Press Space to restart the game"; 
        Debug.Log("Game Over!"); 
    }

    public void HideGameOver()
    {
        gameOverPanel.SetActive(false);
        Time.timeScale = 1; 
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit(); 
    }
}
