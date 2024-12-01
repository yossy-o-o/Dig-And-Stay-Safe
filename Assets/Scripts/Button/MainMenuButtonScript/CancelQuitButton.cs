using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ゲームを終了しなかったときのボタン処理
public class CancelQuitButton : MonoBehaviour
{
    AudioSource audio; //SE

    public GameObject checkExitPanel; //終了確認パネル

    public float delayTime = 1.0f; //コルーチンの遅延時間

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    public void OnClickCheckExitButton()
    {
        StartCoroutine(DelayLoad());
        PlayAudio();
    }

    //コルーチンで遅らせる
    private IEnumerator DelayLoad()
    {
        yield return new WaitForSeconds(delayTime);
        checkExitPanel.SetActive(false);
    }


    void PlayAudio()
    {
        if(audio != null)
        {
            audio.Play();
        }
    }

}
