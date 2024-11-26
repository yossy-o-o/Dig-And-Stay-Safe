using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ESCƒ{ƒ^ƒ“‚ğ‰Ÿ‚µ‚½‚ç‚Ìˆ—
public class Esc : MonoBehaviour
{
    public GameObject EscPanel;
    public void OnClickEscButton()
    {
        EscPanel.SetActive(true);
    }
}
