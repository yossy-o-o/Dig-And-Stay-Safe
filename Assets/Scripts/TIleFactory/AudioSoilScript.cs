using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSoilScript : MonoBehaviour
{
    /*
    1 audiosorce���擾
    2 ���X�g�ŗ��������Ȃ��擾
    3 �����_���ŗ����������߁A���X�g���擾���āA�C���f�b�N�X�Ŏ擾
    4 �ȑI��
    5 ����
    
    */

    AudioSource audioSorce; //AudioSorce���擾
    [SerializeField] List<AudioClip> audioClips = new List<AudioClip>(); //���������Ȃ����X�g�Ŏ擾

    public void Start()
    {
        audioSorce = GetComponent<AudioSource>();
    }

    public void RandomPlayAudio()
    {
        int randoIndex = Random.Range(0, audioClips.Count);
        AudioClip selectAudio = audioClips[randoIndex];
        audioSorce.clip = selectAudio;
        audioSorce.Play();
    }
}
