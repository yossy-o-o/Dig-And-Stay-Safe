using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : DownBarrier
{
    public GameObject resultPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOverSystem()
    {
        if(carrentHp < 0)
        {
            resultPanel.SetActive(true);
        }
    }
}
