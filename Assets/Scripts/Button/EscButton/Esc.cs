using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ESC�{�^������������̏���
public class Esc : MonoBehaviour
{
    public GameObject EscPanel;
    public void OnClickEscButton()
    {
        EscPanel.SetActive(true);
    }
}
