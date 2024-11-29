using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Unity�̏I���m�F�p�l���{�^������������A�ڍs���鏈��
public class QuitGame : MonoBehaviour
{
    AudioSource audio; //�h�A�̉�
    public GameObject checkExitPanel; //�I���m�F�p�l��

    public void Start()
    {
        audio = GetComponent<AudioSource>();
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
}
