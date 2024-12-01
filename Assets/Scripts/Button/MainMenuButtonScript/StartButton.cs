using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


//�Q�[���X�^�[�g�{�^������������A���b��ɃQ�[���V�[���Ɉڍs���鏈��
public class StartButton : MonoBehaviour
{
    private AudioSource audio; // AudioSource�̃t�B�[���h���쐬

    public float waitForSeconds = 2.0f;

    void Awake()
    {
        // AudioSource�R���|�[�l���g���擾
        audio = GetComponent<AudioSource>();

        if (audio == null)
        {
            Debug.LogError("AudioSorce�����ĂȂ�");
        }
    }

    public void OnClickStartButton()
    {
        // �{�^���������ꂽ��R���[�`�����J�n
        StartCoroutine(LoadSceneAfterDelay());
    }

    private IEnumerator LoadSceneAfterDelay()
    {
        // �K�v�ł���Ή������Đ�
        PlayAudio();

        // �w�莞�ԑҋ@
        yield return new WaitForSeconds(waitForSeconds);

        // �V�[�������[�h
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
