using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using ScriptableObjectArchitecture;
using Syrinj;
using UnityEngine.UI;

public class Done_GameController : MonoBehaviour
{
    /*public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;*/
    public Vector3 spawnValues;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;

    private bool gameOver;
    private bool restart;
    private int score;
    [Provides] public GameManagerSO gmso;

    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(gmso.startWait);
        while (true)
        {
            for (int i = 0; i < gmso.hazardCount; i++)
            {
                GameObject hazard = gmso.hazards[Random.Range(0, gmso.hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, 
                    spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(gmso.spawnWait);
            }
            yield return new WaitForSeconds(gmso.waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'R' for Restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}