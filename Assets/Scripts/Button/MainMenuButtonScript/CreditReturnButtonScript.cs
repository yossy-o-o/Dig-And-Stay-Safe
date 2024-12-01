using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�N���W�b�g�{�^������������̏���
public class CreditReturnButtonScript : MonoBehaviour
{
    public float delayTime = 1.0f;

    [SerializeField] GameObject creditsPanel;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnclickCreditReturnButtonScripts()
    {
        PlayAudio();
        StartCoroutine(DelayLoad());
    }

    private IEnumerator DelayLoad()
    {
        yield return new WaitForSeconds(delayTime);
        creditsPanel.SetActive(false);

    }

    void PlayAudio()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
