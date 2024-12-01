using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // �V�[���Ǘ��̂��߂ɕK�v

// ESC�{�^������������̏���
public class Esc : MonoBehaviour
{
    public static Esc Instance { get; private set; }
    public GameObject EscPanel;
    AudioSource audio;

    // �V���O���g����
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        EscPanel.SetActive(false);
        audio = GetComponent<AudioSource>();

        // �V�[�����ǂݍ��܂�邽�т� EscPanel �����
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // �V�[�������[�h���ꂽ�Ƃ��ɌĂяo�����
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (EscPanel != null)
        {
            EscPanel.SetActive(false);
        }
    }

    public void OnClickEscButton()
    {
        EscPanel.SetActive(true);
        PlayAudio();
    }

    // Audio �̍Đ�
    void PlayAudio()
    {
        if (audio != null)
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
