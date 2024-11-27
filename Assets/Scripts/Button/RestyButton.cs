using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//リトライ処理
public class RestyButton : MonoBehaviour
{
    public string sceneName; //現在のシーン
    public GameObject resultPanel;

    void Start()
    {
        //sceneName = SceneManager.GetActiveScene().name; //現在のsceneを取得する
    }

    //ボタンを押したらリトライ処理
    public void OnClickRetryButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
        sceneName = SceneManager.GetActiveScene().name; //現在のsceneを取得する
        resultPanel.SetActive(false);
    }
}
