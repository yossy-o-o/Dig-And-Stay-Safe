using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//���g���C����
public class RestyButton : MonoBehaviour
{
    public string sceneName; //���݂̃V�[��
    public GameObject resultPanel;

    void Start()
    {
        //sceneName = SceneManager.GetActiveScene().name; //���݂�scene���擾����
    }

    //�{�^�����������烊�g���C����
    public void OnClickRetryButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
        sceneName = SceneManager.GetActiveScene().name; //���݂�scene���擾����
        resultPanel.SetActive(false);
    }
}
