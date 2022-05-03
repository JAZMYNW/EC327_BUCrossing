using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManagment : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    int score = 0;
    int highscore = 0;

    public static ScoreManagment instance;

    private void Awake() {
      instance = this;
    }

    void Start()
    {

          highscore = PlayerPrefs.GetInt("highscore",0);
          scoreText.text = "SCORE: " + score.ToString();
          highScoreText.text = "HIGHSCORE: "+ highscore.ToString();
    }


    public void AddPoint(){
      score++;
      scoreText.text = "SCORE: " + score.ToString();
      if(highscore < score){
      PlayerPrefs.SetInt("highscore",score);
    }
    }

    public void RemovePoint(){
      score--;
      scoreText.text = "SCORE: " + score.ToString();
    }
}
