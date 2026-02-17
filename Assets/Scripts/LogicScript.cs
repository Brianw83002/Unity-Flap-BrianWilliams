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

    private float difficultyScale = 0.05f; //1.05f = 5% difficulty increase




    void Awake()
    {
        // Set file path in persistent data path
        // Get the folder where the game executable is located
        string gameFolder = Directory.GetParent(Application.dataPath).FullName;

        highScoreFilePath = Path.Combine(gameFolder, "highscore.txt");


        // Build the full path to the high score file
        highScoreFilePath = Path.Combine(gameFolder, "highscore.txt");

        // Check if the file exists; if not, create it
        if (!File.Exists(highScoreFilePath))
        {
            Debug.Log("highscore File not found");

            // Create file with a default high score
            File.WriteAllText(highScoreFilePath, "0");
            Debug.Log("highscore.txt created");
        }

        LoadHighScore();
        Debug.Log("High score file path: " + highScoreFilePath);
    }


    [ContextMenu("score add 1")]
    public void addScore()
    {
        playerScore = playerScore + 1;
        scoreText.text = playerScore.ToString();

        //ADJUSTS SPAWN AND PIPE SPEED FOR DIFFICULTY
        pipeMoveSpeed = pipeMoveSpeed * (1.0f + difficultyScale);

        // 5% faster spawning (less time between spawns)
        spawnRate = spawnRate * (1.0f - difficultyScale);
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



// ------------------- High Score -------------------
    void CheckHighScore()
    {
        if (playerScore > highScore)
        {
            highScore = playerScore;
            SaveHighScore();
        }
    }

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
        else
        {
            Debug.LogError("Failed to save high score: ");
        }

        highScoreText.text = highScore.ToString();
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quitting Game");
    }


}
