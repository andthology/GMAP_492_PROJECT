using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class button_exitgame : MonoBehaviour {

	public Button exitButton;

    void Start()
    {
        Button btn = exitButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Application.Quit();
    }

}
