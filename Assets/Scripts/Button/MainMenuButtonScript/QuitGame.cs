using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//Unityの終了確認パネルボタンを押したら、移行する処理
public class QuitGame : MonoBehaviour
{
    AudioSource audio; //ドアの音
    public GameObject checkExitPanel; //終了確認パネル

    public void Start()
    {
        audio = GetComponent<AudioSource>();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (checkExitPanel != null)
        {
            checkExitPanel.SetActive(false);
        }
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

    private void OnDestroy()
    {
        // シーン管理イベントから解除
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
