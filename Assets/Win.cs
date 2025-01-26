using UnityEngine;
using TMPro; 

public class Win : MonoBehaviour
{
    public GameObject winPanel; 
    public TextMeshProUGUI messageText;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }
    }

    public void ShowWin()
    {
        Time.timeScale = 0; 
        winPanel.SetActive(true);
        messageText.text = "Congratulations ,, You Win! \nPress Space to restart the game"; 
    }

    public void HideWin()
    {
        winPanel.SetActive(false); 
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
