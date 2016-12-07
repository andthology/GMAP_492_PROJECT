using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreControl : MonoBehaviour 
{
	public Text scoreText;
	//public Text winText;
	public Text timerText;
    public GameObject pauseImage;
    public GameObject resumeBut;
    public int wave;
    public int score;
	public float timer;

    private EnemySpawning spawning;


	void Start()
	{
        wave = 0;
		score = 0;
		//SetScoreText ();
        //winText.text = "";
        //Locating the gameObject holding the EnemySpawning script in the scene
        spawning = GetComponent<EnemySpawning>();

        StartNewRound();
    }

	// Update is called once per frame
	void FixedUpdate () 
	{
		timer = timer - Time.deltaTime;

        timerText.text = Mathf.RoundToInt(timer).ToString ();

        if (timer <= 0)
        {
            StartNewRound();
        }

        //if (Input.GetButtonDown("Pause"))
            //PauseGame();
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


    
    void StartNewRound()
    {
        wave++;

        spawning.ResetSpawn(wave);

        timer = 30f;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject e in enemies)
            Destroy (e);
    }



    void PauseGame()
    {
        //causes in-game time to always = 0. Stops all time-based things including FixedUpdate()
        Time.timeScale = 0f;

        //Enable the endRoundImage object
        pauseImage.SetActive(true);

        resumeBut.SetActive(true);
    }

    void ResumeGame()
    {
        pauseImage.SetActive(false);

        Time.timeScale = 1f;
    }
}
