using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public static ScoreManager instance = null;
    public Text m_scoreText;
    public int m_score = 0;

    public Text bestScoreText;

    void Awake ()
    {
        if( instance == null )
        {
            instance = this;
        }
        else if( instance != this )
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

	// Use this for initialization
	void Start () {
        bestScoreText.text = "Best Score : " + BestScoreManager.bestScore;

        StartCoroutine(UpdateScore());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator UpdateScore()
    {
        TextManager tm = FindObjectOfType<TextManager>();
        while (!tm.isOver)
        {
            AddScore(1);
            yield return new WaitForSeconds(1);
        }
    }

    public void AddScore(int score)
    {
        m_score = m_score + score;          // 점수를 더합니다.
        m_scoreText.text = m_score.ToString();   // 점수를 표시해 줍니다.
    }
}
