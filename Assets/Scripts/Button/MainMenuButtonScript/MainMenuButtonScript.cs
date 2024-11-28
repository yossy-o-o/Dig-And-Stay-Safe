using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonScript : MonoBehaviour
{
    public void OnClickMainMenuButton()
    {
        SceneManager.LoadScene("StartScene");
<<<<<<< HEAD
        Time.timeScale = 1f;
=======
        Time.timeScale = 1;
>>>>>>> e6d46d64eab2a801cc9b0cb00e108126842a4fb8
    }
}
