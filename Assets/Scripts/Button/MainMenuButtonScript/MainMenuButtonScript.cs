using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//�Q�[����ʂ��烁�C����ʂɖ߂邽�߂̃{�^������
public class MainMenuButtonScript : MonoBehaviour
{
    public void OnClickMainMenuButton()
    {
        SceneManager.LoadScene("StartScene");

        Time.timeScale = 1f;
    }
}
