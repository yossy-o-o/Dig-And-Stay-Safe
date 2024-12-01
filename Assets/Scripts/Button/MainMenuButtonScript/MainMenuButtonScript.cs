using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//ゲーム画面からメイン画面に戻るためのボタン処理
public class MainMenuButtonScript : MonoBehaviour
{

    AudioSource audioSource;
    public float delayTime = 0.5f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnClickMainMenuButton()
    {
        StartCoroutine(DelaySceneLoad());
        PlayAudio();
    }

    private IEnumerator DelaySceneLoad()
    {
        Time.timeScale = 1f;
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene("StartScene");
    }

    void PlayAudio()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }

    }
}
