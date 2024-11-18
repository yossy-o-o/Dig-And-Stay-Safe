using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using System.Drawing;


//Score‚Ìˆ—
public class ScoreSystem : MonoBehaviour
{
    public TextMeshProUGUI pointText;
    public TextMeshProUGUI ResultScoreText;
    public TextMeshProUGUI resultHighScoreText;


    public int Point = 0;


    public void addScore(int amount)
    {
        Point += amount;
        UpdatePointText();
    }

    private void UpdatePointText()
    {
        pointText.text = Point.ToString();
        ResultScoreText.text = Point.ToString();
    }

    public void UpdateHighScore()
    {
        int HighScore = PlayerPrefs.GetInt("HighScore", 0);

        if(Point > HighScore)
        {
            PlayerPrefs.SetInt("HighScore", Point);
            resultHighScoreText.text = Point.ToString();

            PlayerPrefs.Save();
        }
        else
        {
            resultHighScoreText.text = HighScore.ToString();
        }
    }
}
