using TMPro;
using UnityEngine;

public class HighScoreTextManager : MonoBehaviour
{
    public GameObject highScoreText;
    public GameObject scoreText;
    public UIManager userInterface;

    private void Update()
    {
        TextMeshProUGUI scoreTextTxt = (TextMeshProUGUI)scoreText.GetComponent<TMP_Text>();
        TextMeshProUGUI highScoreTextTxt = (TextMeshProUGUI)highScoreText.GetComponent<TMP_Text>();

        scoreTextTxt.text = ("Score: " + (userInterface.score.ToString()));
        highScoreTextTxt.text = ("High score: " + (userInterface.highScore.ToString()));
    }
}
