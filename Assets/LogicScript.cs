using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;

    public int highScore;
    public Text highScoreText;
    string highScoreFilePath;

    public GameObject gameOverScreen;

    //PipeSettings 
    public float pipeMoveSpeed = 8.0f;
    public float spawnRate = 6.0f; //timer counts to spawn rate, then spawns. (Lower number means faster spawn)





    void Awake()
    {
        // Set file path in persistent data path
        highScoreFilePath = Application.persistentDataPath + "/highscore.txt";
        LoadHighScore();
    }


    [ContextMenu("score add 1")]
    public void addScore()
    {
        playerScore = playerScore + 1;
        scoreText.text = playerScore.ToString();


        pipeMoveSpeed = pipeMoveSpeed + 0.5f;
        if(spawnRate > 2.0)
        {
            spawnRate = spawnRate - 0.5f;
        }
        

    }

    public void restartGame()
    {
        SceneManager.LoadSceneAsync("Game");
    }
    
    public void gameOver()
    {
        CheckHighScore();
        highScoreText.text = highScore.ToString();
        gameOverScreen.SetActive(true);
    }


    void CheckHighScore()
    {
        if (playerScore > highScore)
        {
            highScore = playerScore;
            SaveHighScore();
        }
    }

    // ------------------- High Score -------------------
    void SaveHighScore()
    {
        try
        {
            File.WriteAllText(highScoreFilePath, highScore.ToString());
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to save high score: " + e.Message);
        }
    }




    void LoadHighScore()
    {
        if (File.Exists(highScoreFilePath))
        {
            string data = File.ReadAllText(highScoreFilePath);
            int.TryParse(data, out highScore);
        }

        highScoreText.text = highScore.ToString();
    }

}
