using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ESCボタンを押したらの処理
public class Esc : MonoBehaviour
{
    public GameObject EscPanel;
    public void OnClickEscButton()
    {
        EscPanel.SetActive(true);
    }
}
