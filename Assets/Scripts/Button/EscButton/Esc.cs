using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ESCƒ{ƒ^ƒ“‚ğ‰Ÿ‚µ‚½‚ç‚Ìˆ—
public class Esc : MonoBehaviour
{
    public GameObject EscPanel;

    AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    public void OnClickEscButton()
    {
        EscPanel.SetActive(true);
        PlayAudio();
    }


    //Audio‚ÌÄ¶
    void PlayAudio()
    {
        if(audio != null)
        {
            audio.Play();
        }
    }
}
