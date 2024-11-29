using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//settingのstartSceneに戻るボタン処理
public class SettingReturnButton : MonoBehaviour
{
    AudioSource audio; //SE

    public GameObject settingPanel; //settingPanel

    public float derayTime = 1.0f; //コルーチンでの遅延時間

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    //ボタンが押されたら
    public void OnClickSettingRetrunButton()
    {
        StartCoroutine(DerayLoad());
        PlayAudio();
    }

    //コルーチンで遅延を書ける
    private IEnumerator DerayLoad()
    {
        yield return new WaitForSeconds(derayTime);
        settingPanel.SetActive(false);
    }

    //SEの再生
    private void PlayAudio()
    {
        if(audio != null)
        {
            audio.Play();
        }
    }
}
