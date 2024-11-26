using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//StartSceneのカメラで一定の位置を往復するスクリプト
public class StartSceneCamera : MonoBehaviour
{
    /*工程
    1. カメラを取得する
    2. カメラのx座標を取得する
    3. 移動する速度を取得する
    4. カメラを動かしたい範囲の最小と最大の一座標を取得する(最小、最大座標にGameObjectを置く)
    5. 移動する
    6. 最大座標まで移動したら、最小座標まで徐々に移動する
    7. 最小座標まで移動したら、最大座標まで徐々に移動する
    8. 繰り返す
    */

    public Camera mainCamera; //メインカメラの変数

    public Transform minPoint; //最小座標を表すオブジェクト

    public Transform maxPoint; //最大座標を表すオブジェクト

    private Vector3 maxXCameraPosition; //カメラの最大X座標

    private Vector3 minXCameraPosition; //カメラの最小X座標

    public float cameraMoveSpeed = 0.1f; //カメラの移動速度

    private bool movingToMax = true;//最大地点と最小地点の切り替え

    private float moveProgress = 0.0f; //カメラの最大、最小座標に進む進行度



    public void Start()
    {
        maxXCameraPosition = maxPoint.position; //最大地点を取得
        minXCameraPosition = minPoint.position; //最小地点を取得
    }

    public void Update()
    {
        CameraSystem();
    }


    //Cameraの移動処理
    public void CameraSystem()
    {
        if (movingToMax)
        {
            //最大座標に向かう
            moveProgress += cameraMoveSpeed * Time.deltaTime;
        }
        else
        {
            //最小座標に向かう
            moveProgress -= cameraMoveSpeed * Time.deltaTime;
        }

        moveProgress = Mathf.Clamp01(moveProgress); //Clamp01を使用して、0~1の範囲内に収める

        Vector3 newPosition = Vector3.Lerp(minXCameraPosition, maxXCameraPosition, moveProgress); //Lerpを使用して、徐々に移動

        mainCamera.transform.position = newPosition;

        //方向を反転
        changetransform();
    }


    //方向反転の処理
    void changetransform()
    {
        //最大座標に達したら最小座標へ
        if(moveProgress >= 1.0f)
        {
            movingToMax = false;
        }
        //最小座標に達したら最大座標へ
        else if(moveProgress <= 0.0f)
        {
            movingToMax = true;
        }
    }

}
