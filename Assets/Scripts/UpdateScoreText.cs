using UnityEngine.UI;
using UnityEngine;

public class UpdateScoreText : MonoBehaviour {

    public Text currScore, highScore;
    public GameObject panel;

    private void Update()
    {
        if (GameControl.gameOver && !panel.activeSelf)
        {
            panel.SetActive(true);
        }
    }

    // Use this for initialization
    void Start () {
        GameControl.changeScoreEvent += UpdateText;
        UpdateText();
    }
	
	// Update is called once per frame
	void UpdateText () {

        if (currScore == null)
        {
            currScore = GameObject.Find("ScoreText").GetComponent<Text>();
        }

        if (highScore == null)
        {
            highScore = GameObject.Find("HighScoreText").GetComponent<Text>();
        }
        currScore.text = "Score: " + GameControl.totalScore;
        highScore.text = "High: " + GameControl.highScore;
	}
}
