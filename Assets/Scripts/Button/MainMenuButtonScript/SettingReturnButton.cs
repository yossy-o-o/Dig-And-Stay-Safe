using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//setting��startScene�ɖ߂�{�^������
public class SettingReturnButton : MonoBehaviour
{
    AudioSource audio; //SE

    public GameObject settingPanel; //settingPanel

    public float derayTime = 1.0f; //�R���[�`���ł̒x������

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    //�{�^���������ꂽ��
    public void OnClickSettingRetrunButton()
    {
        StartCoroutine(DerayLoad());
        PlayAudio();
    }

    //�R���[�`���Œx����������
    private IEnumerator DerayLoad()
    {
        yield return new WaitForSeconds(derayTime);
        settingPanel.SetActive(false);
    }

    //SE�̍Đ�
    private void PlayAudio()
    {
        if(audio != null)
        {
            audio.Play();
        }
    }
}
