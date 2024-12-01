using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�I���m�F�p�l���̃Q�[���I���{�^�����������Ƃ��̏���(�Q�[�����I�����鏈��)
public class QuitButtonScript : MonoBehaviour
{
    AudioSource audio;

    public float delayTime = 1.0f; //�R���[�`���ł̒x������

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    //�{�^������������
    public void OnclickQuitButton()
    {
        StartCoroutine(DelayLoad());
        PlayAudio();
    }

    //�R���[�`���Œx����������
    private IEnumerator DelayLoad()
    {
        yield return new WaitForSeconds(delayTime);

        //Editor�̎��ƁA�r���h������ł̏I������
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;

        #else
                    Application.Quit(); //����ȊO�̎�

        #endif
    }


    //AudioSorce��SE�𗬂�
    void PlayAudio()
    {
        if(audio != null)
        {
            audio.Play();
        }
    }

}
