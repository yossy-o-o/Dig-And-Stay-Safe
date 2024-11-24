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
    4. カメラを動かしたい範囲の最小と最大の一座標を取得する
    5. 移動する
    6. 最大座標まで移動したら、最小座標まで徐々に移動する
    7. 最小座標まで移動したら、最大座標まで徐々に移動する
    8. 繰り返す
    9.
    */

    public Camera mainCamera; //メインカメラの変数

    public float mainCameraTranceform; //メインカメラの座標変数

    private float maxXCameraPosition; //カメラの最大X座標

    private float minXCameraPosition; //カメラの最小X座標

    public float speed = 5.0f; //カメラの移動速度

    public void CameraSystem()
    {
        Vector3 currentPosition = mainCamera.transform.position; //現在のカメラの位置を取得

        mainCameraTranceform = mainCamera.transform.position.x; //カメラのx座標を取得

        mainCameraTranceform = Mathf.Clamp(transform.position.x, minXCameraPosition, maxXCameraPosition);//動かしたい最小と最大を取得

        Vector3 minXCameraPosition = new Vector3();

        Vector3 maxXCameraPosition = new Vector3();

        Vector3 newPosition = Vector3.Lerp(minXCameraPosition, maxXCameraPosition, speed * Time.deltaTime);

        mainCamera.transform.position = newPosition;
    }
    

}
