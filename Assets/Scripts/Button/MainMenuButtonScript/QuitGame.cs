using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//Unity�̏I���m�F�p�l���{�^������������A�ڍs���鏈��
public class QuitGame : MonoBehaviour
{
    AudioSource audio; //�h�A�̉�
    public GameObject checkExitPanel; //�I���m�F�p�l��

    public void Start()
    {
        audio = GetComponent<AudioSource>();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (checkExitPanel != null)
        {
            checkExitPanel.SetActive(false);
        }
    }

    //�I���p�l���Ɉڍs���鏈��
    public void EndCheckGame()
    {
        AudioPlay();
        checkExitPanel.SetActive(true);
    }

    //AudioSorce���擾���āA����炷
    void AudioPlay()
    {
        if(audio != null)
        {
            audio.Play();
        }
    }

    private void OnDestroy()
    {
        // �V�[���Ǘ��C�x���g�������
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
