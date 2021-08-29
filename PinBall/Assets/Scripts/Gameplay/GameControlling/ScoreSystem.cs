using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField]
    private Text txtScore;
    [SerializeField]
    private Text txtHighScore;
    
    private int _score;
    public int Score
    {
        get { return _score; }
        set { 
            _score = value;
            txtScore.text = $"Score: {value}";
            if (value > HighScore)
            {
                HighScore = value;
            }
        }
    }

    private int _highScore;

    public int HighScore
    {
        get { return _highScore; }
        set {
            _highScore = value;
            txtHighScore.text = $"High Score: {value}";
            PlayerPrefs.SetInt("hs", value);
            PlayerPrefs.Save();
        }
    }

    private void Start()
    {
        HighScore = PlayerPrefs.GetInt("hs");
        Score = 0;
    }
}
