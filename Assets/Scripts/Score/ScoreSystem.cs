using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using System.Drawing;


//Score�̏���
public class ScoreSystem : MonoBehaviour
{
    public TextMeshProUGUI pointText; //Point�̃e�L�X�g
    public TextMeshProUGUI ResultScoreText; //����擾�����_�������U���g�ŕ\���e�L�X�g
    public TextMeshProUGUI resultHighScoreText; // �n�C�X�R�A��\���e�L�X�g

    //result��ʂŔ��肵�\������摜
    public GameObject firstImage; //Point��5000�ȏ�̏ꍇ�̉摜
    public GameObject secondImage; //Point��4000�ȉ��̏ꍇ�̉摜
    public GameObject thirdImage; //Point��2000�ȉ��̏ꍇ�̉摜

    //result��ʂŔ��肵�\������e�L�X�g
    public GameObject firstText; //Point��5000�ȏ�̏ꍇ�̃e�L�X�g
    public GameObject secondText; //Point��4000�ȉ��̏ꍇ�̃e�L�X�g
    public GameObject thirdText; //Point��2000�ȉ��̏ꍇ�̉摜�e�L�X�g


    public int Point = 0; //�ŏ���Point��0�ɂ���

    
    //Point���Z����
    public void addScore(int amount)
    {
        Point += amount;
        UpdatePointText();
    }

    //�Q�[����ʂƃ��U���g��ʂ̃e�L�X�g�̏���
    private void UpdatePointText()
    {
        pointText.text = Point.ToString();
        ResultScoreText.text = Point.ToString();
    }

    //�n�C�X�R�A��\�����鏈��
    public void UpdateHighScore()
    { 
        int HighScore = PlayerPrefs.GetInt("HighScore", 0);

        if(Point > HighScore)
        {
            PlayerPrefs.SetInt("HighScore", Point);
            resultHighScoreText.text = Point.ToString();

            //�Z�[�u���s��
            PlayerPrefs.Save();
        }
        else
        {
            resultHighScoreText.text = HighScore.ToString();
        }

        
        ResultOrder();//�_���̔���֐�
    }

    //�_���̔��菈��
    public void ResultOrder()
    {
        Inactive();//�ŏ��ɉ摜�A�e�L�X�g���A�N�e�B�u

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


    //�ŏ��ɉ摜�Ɣ�A�N�e�B�u�ɂ��鏈��
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
