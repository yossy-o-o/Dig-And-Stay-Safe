using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�Q�[�����I�����Ȃ������Ƃ��̃{�^������
public class CancelQuitButton : MonoBehaviour
{
    AudioSource audio; //SE

    public GameObject checkExitPanel; //�I���m�F�p�l��

    public float delayTime = 1.0f; //�R���[�`���̒x������

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    public void OnClickCheckExitButton()
    {
        StartCoroutine(DelayLoad());
        PlayAudio();
    }

    //�R���[�`���Œx�点��
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
