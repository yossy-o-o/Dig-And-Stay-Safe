using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Unityの終了処理
public class QuitGame : MonoBehaviour
{
    public void EndGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //エディターでプレイしてる時

        #else
            Application.Quit(); //それ以外の時

        #endif
    }
}
