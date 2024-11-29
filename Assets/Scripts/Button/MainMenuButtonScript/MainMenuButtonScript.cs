using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//ゲーム画面からメイン画面に戻るためのボタン処理
public class MainMenuButtonScript : MonoBehaviour
{
    public void OnClickMainMenuButton()
    {
        SceneManager.LoadScene("StartScene");

        Time.timeScale = 1f;
    }
}
