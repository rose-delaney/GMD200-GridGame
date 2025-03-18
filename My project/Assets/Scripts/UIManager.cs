using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
   public int score = 0;
   public int health = 3;
   public GameObject scoreTextObj;
   public GameObject healthTextObj;

   public void LoseHealth()
   {
      health -= 1;
   }

   public void GainScore(int scoreGain)
   {
      score += scoreGain;
   }

   private void Update()
   {
      TextMeshProUGUI scoreTextTxt = scoreTextObj.GetComponent<TMP_Text>;
      TextMeshProUGUI healthTextTxt = healthTextObj.GetComponent<TMP_Text>;

      scoreTextTxt.text = score.ToString();
      healthTextTxt.text = health.ToString();
   }
}
