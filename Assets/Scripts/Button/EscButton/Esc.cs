using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ESCボタンを押したらの処理
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


    //Audioの再生
    void PlayAudio()
    {
        if(audio != null)
        {
            audio.Play();
        }
    }
}
