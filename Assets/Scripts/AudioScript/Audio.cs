using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


//audio�̊Ǘ�
public class Audio : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer; //audioMixer

    [SerializeField] Slider bgmSlider; //bgm�̃X���C�_�[

    [SerializeField] Slider seSlider; //se�̃X���C�_�[

    public static Audio Instance { get; private set;}

    //�V���O���g�������s���A�X���C�_�[�֘A���ǂ�����ł��A�N�Z�X�ł���悤�ɂ���
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

    //AudioMixer�ɓ���邽�߂̏���
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
