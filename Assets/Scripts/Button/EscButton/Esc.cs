using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ESC�{�^������������̏���
public class Esc : MonoBehaviour
{
    public GameObject EscPanel;

    AudioSource audio;

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
