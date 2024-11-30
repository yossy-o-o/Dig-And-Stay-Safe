using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using System.Drawing;


//Scoreの処理
public class ScoreSystem : MonoBehaviour
{
    public TextMeshProUGUI pointText; //Pointのテキスト
    public TextMeshProUGUI ResultScoreText; //今回取得した点数をリザルトで表すテキスト
    public TextMeshProUGUI resultHighScoreText; // ハイスコアを表すテキスト

    //result画面で判定し表示する画像
    public GameObject firstImage; //Pointが5000以上の場合の画像
    public GameObject secondImage; //Pointが4000以下の場合の画像
    public GameObject thirdImage; //Pointが2000以下の場合の画像

    //result画面で判定し表示するテキスト
    public GameObject firstText; //Pointが5000以上の場合のテキスト
    public GameObject secondText; //Pointが4000以下の場合のテキスト
    public GameObject thirdText; //Pointが2000以下の場合の画像テキスト


    public int Point = 0; //最初のPointは0にする

    
    //Point加算処理
    public void addScore(int amount)
    {
        Point += amount;
        UpdatePointText();
    }

    //ゲーム画面とリザルト画面のテキストの処理
    private void UpdatePointText()
    {
        pointText.text = Point.ToString();
        ResultScoreText.text = Point.ToString();
    }

    //ハイスコアを表示する処理
    public void UpdateHighScore()
    { 
        int HighScore = PlayerPrefs.GetInt("HighScore", 0);

        if(Point > HighScore)
        {
            PlayerPrefs.SetInt("HighScore", Point);
            resultHighScoreText.text = Point.ToString();

            //セーブを行う
            PlayerPrefs.Save();
        }
        else
        {
            resultHighScoreText.text = HighScore.ToString();
        }

        
        ResultOrder();//点数の判定関数
    }

    //点数の判定処理
    public void ResultOrder()
    {
        Inactive();//最初に画像、テキストを非アクティブ

        if (Point <= 2000)
        {
            thirdImage.SetActive(true);
            thirdText.SetActive(true);
        }
        else if (Point <= 4900)
        {
            secondImage.SetActive(true);
            secondText.SetActive(true);
        }
        else if(Point > 6000)
        {
            firstImage.SetActive(true);
            firstText.SetActive(true);
        }
    }


    //最初に画像と非アクティブにする処理
    public void Inactive()
    {
        firstImage.SetActive(false);
        firstText.SetActive(false);

        secondImage.SetActive(false);
        secondText.SetActive(false);

        thirdImage.SetActive(false);
        thirdText.SetActive(false);
    }
}
