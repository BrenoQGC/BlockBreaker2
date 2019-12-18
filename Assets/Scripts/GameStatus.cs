using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour

{
    //Config parameters
    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlock = 53;
    [SerializeField] TextMeshProUGUI scoreText=null;

    //State variable
    [SerializeField] int currentScore;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            DetroyStatus();
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void DetroyStatus()
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlock;
        scoreText.text = currentScore.ToString();
    }
}
