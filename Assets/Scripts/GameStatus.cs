using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameStatus : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int currentScore = 0;
    [SerializeField] int pointsPerBlockDestroyed = 100;
    [SerializeField] bool autoplay = false;
    [SerializeField] TextMeshProUGUI scoreText;
    
    void Awake() {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;   
        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
            DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
        scoreText.text = currentScore.ToString();
    }
    
    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
    }

    public void DestroyGameStatus()
    {
        Destroy(gameObject);
    }

    public bool IsAutoplayEnabled()
    {
        return autoplay;
    }
}
