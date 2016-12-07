using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class button_startgame : MonoBehaviour {

	public Button startButton;
	void Start(){
		Button btn = startButton.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick(){
		UnityEngine.SceneManagement.SceneManager.LoadScene ("LongerHall");
	}
}
