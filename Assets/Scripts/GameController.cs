using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 1. Tao ra enemy o vi tri ngau nhien tren man hinh
// 2. Tang diem so cua nguoi choi khi ban chet ke thu (enemy)
// 3. Ktra tro choi ket thuc hay chua 
public class GameController : MonoBehaviour
{
    public GameObject enemy;

    public float spawnTime; // Thoi gian tao enemy

    float m_spawnTime;

    int m_score;

    bool m_isGameOver;

    UIManager m_ui;
    // Start is called before the first frame update
    void Start()
    {
        m_spawnTime = 0;
        m_ui = FindObjectOfType<UIManager>();
        m_ui.SetScoreText("Score: " + m_score);
    }

    // Update is called once per frame
    void Update()
    {
		if (m_isGameOver)
		{
            m_spawnTime = 0;
            m_ui.ShowGameOverPanel(true);
            return;
		}

        m_spawnTime -= Time.deltaTime;
        if(m_spawnTime <= 0)
		{
            SpawnEnemy();

            m_spawnTime = spawnTime;
		}
    }
    public void SpawnEnemy()
	{
        float randXpos = Random.Range(-7f, 7f);

        Vector2 spawnPos = new Vector2(randXpos, 7);

		if (enemy)
		{
            Instantiate(enemy, spawnPos, Quaternion.identity);
		}
	}
    public void Replay()
	{
        SceneManager.LoadScene("SampleScene");
	}
    public void SetScore (int value)
	{
        m_score = value;
	}
    public int GetScore()
	{
        return m_score;
	}
    public void ScoreIncrement()
	{
		if (m_isGameOver)
		{
            return;
		}
        m_score++;
        m_ui.SetScoreText("Score: " + m_score);
	}
    public void SetGameOver (bool state)
	{
        m_isGameOver = state;
	}
    public bool IsGameOver()
	{
        return m_isGameOver;
	}
}
