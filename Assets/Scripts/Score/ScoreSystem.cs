using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoreSystem : MonoBehaviour
{
    // スコアのセーブ処理
    public void SaveScore(int newScore)
    {
        // 現在のスコア数を取得
        int scoreCount = PlayerPrefs.GetInt("ScoreCount", 0);

        // 新しいスコアを保存（スコア数に基づいてキーを動的に設定）
        PlayerPrefs.SetInt($"Score_{scoreCount}", newScore);

        // スコア数を更新
        PlayerPrefs.SetInt("ScoreCount", scoreCount + 1);

        // PlayerPrefsの変更を保存
        PlayerPrefs.Save();
    }

    // 上位3位のスコアを取得
    public List<int> GetTop3Scores()
    {
        int scoreCount = PlayerPrefs.GetInt("ScoreCount", 0);
        List<int> scores = new List<int>();

        for (int i = 0; i < scoreCount; i++)
        {
            int score = PlayerPrefs.GetInt($"Score_{i}");
            scores.Add(score);
        }

        // スコアを降順にソートし、上位3つを返す
        scores.Sort((a, b) => b.CompareTo(a));
        return scores.Take(3).ToList();
    }
}
