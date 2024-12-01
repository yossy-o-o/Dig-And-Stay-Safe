using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSoilScript : MonoBehaviour
{
    /*
    1 audiosorceを取得
    2 リストで流したい曲を取得
    3 ランダムで流したいため、リストを取得して、インデックスで取得
    4 曲選ぶ
    5 流す
    
    */

    AudioSource audioSorce; //AudioSorceを取得
    [SerializeField] List<AudioClip> audioClips = new List<AudioClip>(); //流したい曲をリストで取得

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
