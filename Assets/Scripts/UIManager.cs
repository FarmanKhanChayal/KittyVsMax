using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject LevelCompletePanel;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI scoreText;
    public float scorePoint;
    public TextMeshProUGUI levelCompleteScoreText;


    private float score;
    
    
    void Start()
    {
        Instance = this;
        LevelCompletePanel.transform.localScale = Vector3.zero;

        DOTween.defaultEaseType = Ease.Linear;


       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnLevelComplte(string text)
    {
        LevelCompletePanel.SetActive(true);

        GetComponent<StarsHandler>().StarAchived();

        levelText.text = text;


        DOTween.Sequence()
            .Append(LevelCompletePanel.transform.DOScale(1.2f, 1))
            .Append(LevelCompletePanel.transform.DOScale(1, 0.2f));
            levelCompleteScoreText.text = scoreText.text;

        Max.Instace.speed = 0;
        Max.Instace.jumpForce = 0;

    }

    public void IncreaseScore()
    {
        
        score += scorePoint;
        scoreText.text = score.ToString();
    }



    public void OnMenuClick()
    {
        SceneManager.LoadScene(0);
    }

    public void OnReplayClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnNextLevelClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
