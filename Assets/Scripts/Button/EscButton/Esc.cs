using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ESC�{�^������������̏���
public class Esc : MonoBehaviour
{
    public static Esc Instance { get; private set; }
    public GameObject EscPanel;

    AudioSource audio;

    //�V���O���g����
    private void Awake()
    {
        if(Instance == null)
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
        audio = GetComponent<AudioSource>();
    }
    public void OnClickEscButton()
    {
        EscPanel.SetActive(true);
        PlayAudio();
    }


    //Audio�̍Đ�
    void PlayAudio()
    {
        if(audio != null)
        {
            audio.Play();
        }
    }
}
