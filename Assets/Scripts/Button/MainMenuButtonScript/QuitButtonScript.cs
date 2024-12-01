using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//終了確認パネルのゲーム終了ボタンを押したときの処理(ゲームを終了する処理)
public class QuitButtonScript : MonoBehaviour
{
    AudioSource audio;

    public float delayTime = 1.0f; //コルーチンでの遅延時間

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    //ボタンを押したら
    public void OnclickQuitButton()
    {
        StartCoroutine(DelayLoad());
        PlayAudio();
    }

    //コルーチンで遅延を加える
    private IEnumerator DelayLoad()
    {
        yield return new WaitForSeconds(delayTime);

        //Editorの時と、ビルドした後での終了処理
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;

        #else
                    Application.Quit(); //それ以外の時

        #endif
    }


    //AudioSorceでSEを流す
    void PlayAudio()
    {
        if(audio != null)
        {
            audio.Play();
        }
    }

}
