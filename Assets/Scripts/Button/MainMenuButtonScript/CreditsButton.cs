using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�N���W�b�g�{�^������������̏���
public class CreditsButton : MonoBehaviour
{
    public float delayTime = 1.0f;

    [SerializeField] GameObject creditsPanel;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    public void OnclickCreditsButton()
    {
        PlayAudio();
        StartCoroutine(DelayLoad());
    }

    private IEnumerator DelayLoad()
    {
        creditsPanel.SetActive(true);
        yield return new WaitForSeconds(delayTime);

    }

    void PlayAudio()
    {
        if(audioSource != null )
        {
            audioSource.Play();
        }
    }
}
