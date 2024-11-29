using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


//audioの管理
public class Audio : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer; //audioMixer

    [SerializeField] Slider bgmSlider; //bgmのスライダー

    [SerializeField] Slider seSlider; //seのスライダー

    public static Audio Instance { get; private set;}

    //シングルトン化を行い、スライダー関連をどこからでもアクセスできるようにする
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
        AudioSystem();
    }

    //AudioMixerに入れるための処理
    void AudioSystem()
    {
        audioMixer.GetFloat("BGM", out float bgmVolume);
        bgmSlider.value = bgmVolume;

        audioMixer.GetFloat("SE", out float seVolume);
        seSlider.value = seVolume;


    }

    public void SetBGM(float volume)
    {
        audioMixer.SetFloat("BGM", volume);
    }

    public void SetSE(float volume)
    {
        audioMixer.SetFloat("SE", volume);
    }


}
