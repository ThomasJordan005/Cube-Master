using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI lifeText;
    [SerializeField] int currentScore = 0;
    [SerializeField] bool autoPlay;
    int life = 3;


    private void Awake()
    {
        int gameSatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameSatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText.text = ("Score: " + currentScore.ToString());
        lifeText.text = ("Lives: " + life.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore(int blockLeval)
    {
        currentScore += blockLeval;
        scoreText.text = ("Score: " + currentScore.ToString());
    }

    public void LoseALife()
    {
        life--;
        if (life <= 0)
        {
            life = 3;
            lifeText.text = ("Lives: " + life.ToString());
            SceneManager.LoadScene("Game Over");
        }
        else
        {
            lifeText.text = ("Lives: " + life.ToString());
            FindObjectOfType<Ball>().LockBall();
        }

    }

    public void GameReset()
    {
        Destroy(gameObject);
    }
    public bool IsAutoPlayEnabled()
    {
        return autoPlay;
    }
}
