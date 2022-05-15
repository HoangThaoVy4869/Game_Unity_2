using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//1. Hien thi dem so cho nguoi choi
//2. Hien thi thong bao khi nguoi choi chet
public class UIManager : MonoBehaviour
{

    public Text scoreText;

    public GameObject gameOverPanel;

    public void SetScoreText(string txt)
	{
		if (scoreText)
		{
			scoreText.text = txt;
		}
	}
	public void ShowGameOverPanel(bool isShow)
	{
		if (gameOverPanel)
		{
			gameOverPanel.SetActive(isShow);
		}
	}
}
