using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoreSystem : MonoBehaviour
{
    // �X�R�A�̃Z�[�u����
    public void SaveScore(int newScore)
    {
        // ���݂̃X�R�A�����擾
        int scoreCount = PlayerPrefs.GetInt("ScoreCount", 0);

        // �V�����X�R�A��ۑ��i�X�R�A���Ɋ�Â��ăL�[�𓮓I�ɐݒ�j
        PlayerPrefs.SetInt($"Score_{scoreCount}", newScore);

        // �X�R�A�����X�V
        PlayerPrefs.SetInt("ScoreCount", scoreCount + 1);

        // PlayerPrefs�̕ύX��ۑ�
        PlayerPrefs.Save();
    }

    // ���3�ʂ̃X�R�A���擾
    public List<int> GetTop3Scores()
    {
        int scoreCount = PlayerPrefs.GetInt("ScoreCount", 0);
        List<int> scores = new List<int>();

        for (int i = 0; i < scoreCount; i++)
        {
            int score = PlayerPrefs.GetInt($"Score_{i}");
            scores.Add(score);
        }

        // �X�R�A���~���Ƀ\�[�g���A���3��Ԃ�
        scores.Sort((a, b) => b.CompareTo(a));
        return scores.Take(3).ToList();
    }
}
