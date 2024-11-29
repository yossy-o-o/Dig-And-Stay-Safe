using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


//ゲームスタートボタンを押したら、何秒後にゲームシーンに移行する処理
public class StartButton : MonoBehaviour
{
    private AudioSource audio; // AudioSourceのフィールドを作成

    public float waitForSeconds = 2.0f;

    void Awake()
    {
        // AudioSourceコンポーネントを取得
        audio = GetComponent<AudioSource>();

        if (audio == null)
        {
            Debug.LogError("AudioSorce入ってない");
        }
    }

    public void OnClickStartButton()
    {
        // ボタンが押されたらコルーチンを開始
        StartCoroutine(LoadSceneAfterDelay());
    }

    private IEnumerator LoadSceneAfterDelay()
    {
        // 必要であれば音声を再生
        PlayAudio();

        // 指定時間待機
        yield return new WaitForSeconds(waitForSeconds);

        // シーンをロード
        SceneManager.LoadScene("SampleScene");
    }

    private void PlayAudio()
    {
        if (audio != null)
        {
            audio.Play();
        }
    }
}
