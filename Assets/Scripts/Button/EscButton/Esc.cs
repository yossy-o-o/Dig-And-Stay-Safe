using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ESCボタンを押したらの処理
public class Esc : MonoBehaviour
{
    public static Esc Instance { get; private set; }
    public GameObject EscPanel;

    AudioSource audio;

    //シングルトン化
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


    //Audioの再生
    void PlayAudio()
    {
        if(audio != null)
        {
            audio.Play();
        }
    }
}
