using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public int score = 0;
    public int health = 3;
    public int highScore;
    public GameObject scoreTextObj;
    public GameObject healthTextObj;

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void LoseHealth()
    {
        health -= 1;
        if (health == 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    public void GainScore(int scoreGain)
    {
        score += scoreGain;
    }

    private void Update()
    {
        TextMeshProUGUI scoreTextTxt = (TextMeshProUGUI)scoreTextObj.GetComponent<TMP_Text>();
        TextMeshProUGUI healthTextTxt = (TextMeshProUGUI)healthTextObj.GetComponent<TMP_Text>();

        scoreTextTxt.text = score.ToString();
        healthTextTxt.text = health.ToString();

        if (score > highScore)
        {
            highScore = score;
        }
    }
}
