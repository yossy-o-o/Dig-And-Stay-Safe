using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Playerの限界高度
public class PlayerLimitPosition : MonoBehaviour
{
    public float maxYPlayerPosition;//PlayerのY限界高度

    void Start()
    {
        
    }

    void Update()
    {
        LimitPosition();
    }


    public void LimitPosition()
    {
        Vector3 position = transform.position;//プレイヤーの現在位置を取得

        if(position.y > maxYPlayerPosition)//もしposition.yがmaxYPlayerPositionより大きかったら
        {
            position.y = maxYPlayerPosition;//maxplayerpositionをposition.yにいれる
            transform.position = position;//現在地をその場所にする
        }
    }
}
