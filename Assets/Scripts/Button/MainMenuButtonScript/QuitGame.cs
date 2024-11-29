using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Unityの終了確認パネルボタンを押したら、移行する処理
public class QuitGame : MonoBehaviour
{
    AudioSource audio; //ドアの音
    public GameObject checkExitPanel; //終了確認パネル

    public void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    //終了パネルに移行する処理
    public void EndCheckGame()
    {
        AudioPlay();
        checkExitPanel.SetActive(true);
    }

    //AudioSorceを取得して、音を鳴らす
    void AudioPlay()
    {
        if(audio != null)
        {
            audio.Play();
        }
    }
}
