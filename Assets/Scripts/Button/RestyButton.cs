using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestyButton : MonoBehaviour
{
    public string sceneName; // 現在のシーン
    public GameObject resultPanel;
    AudioSource audioSource;
    public float delayTime = 0.5f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnClickRetryButton()
    {
        PlayAudio();
        StartCoroutine(DelaySceneLoad());
    }

    private IEnumerator DelaySceneLoad()
    {
        Time.timeScale = 1f;
        yield return new WaitForSeconds(delayTime);
        Debug.Log($"Loading scene: {sceneName}"); // シーン名を確認するログ
        SceneManager.LoadScene(sceneName); // シーンロード
        resultPanel.SetActive(false);
    }

    void PlayAudio()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
