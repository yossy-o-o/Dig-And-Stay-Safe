using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Unity�̏I������
public class QuitGame : MonoBehaviour
{
    public void EndGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //�G�f�B�^�[�Ńv���C���Ă鎞

        #else
            Application.Quit(); //����ȊO�̎�

        #endif
    }
}
