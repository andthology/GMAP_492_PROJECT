using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreControl : MonoBehaviour 
{
	public Text scoreText;
	//public Text winText;
	public Text timerText;

	public int score;
	public float timer;


	void Start()
	{
		timer = 0;

		score = 0;
		SetScoreText ();
		//winText.text = "";
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		timer = timer + Time.deltaTime;

        timerText.text = Mathf.RoundToInt(timer).ToString ();
	}


	public void IncreaseScore(int pointAmount)
	{
		score = score + pointAmount;

		SetScoreText ();
	}

	void SetScoreText()
	{
		scoreText.text = "Score: " + score.ToString ();

		/*if (count >= 12) 
		{
			winText.text = "You Win!";
		} */
	}
}
