using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // シーン管理のために必要

// ESCボタンを押したらの処理
public class Esc : MonoBehaviour
{
    public static Esc Instance { get; private set; }
    public GameObject EscPanel;
    AudioSource audio;

    // シングルトン化
    private void Awake()
    {
        if (Instance == null)
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
        EscPanel.SetActive(false);
        audio = GetComponent<AudioSource>();

        // シーンが読み込まれるたびに EscPanel を閉じる
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // シーンがロードされたときに呼び出される
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (EscPanel != null)
        {
            EscPanel.SetActive(false);
        }
    }

    public void OnClickEscButton()
    {
        EscPanel.SetActive(true);
        PlayAudio();
    }

    // Audio の再生
    void PlayAudio()
    {
        if (audio != null)
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
