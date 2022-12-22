using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class Score : MonoBehaviour
{
    public int score = 0;
    public int highscore = 0;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI Hightext;
    public TextMeshProUGUI Inputtext;

    void Start()
    {
        Hightext.text = ("H.Score: " + PlayerPrefs.GetInt("highscore"));
        highscore = PlayerPrefs.GetInt("highscore", 0);
 
        if (PlayerPrefs.HasKey("score"))
        {
            Scene ActiveScreen = SceneManager.GetActiveScene();
            if (ActiveScreen.buildIndex == 0)
            {

                PlayerPrefs.DeleteKey("score");
                score = 0;
            }
            else
                score = PlayerPrefs.GetInt("score");
        }
    }

    void Update()
    {
        scoreText.text = ("Score: " + score);
    }
}
