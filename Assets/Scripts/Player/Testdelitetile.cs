using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Testdelitetile : MonoBehaviour
{
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
     
    }



    // 自分のいるColliderとの当たり判定を取得
    void OnCollisionEnter2D(Collision2D other)
    {
            Vector3 hitPos = Vector3.zero; // 座標の初期化

            foreach (ContactPoint2D point in other.contacts) // ContactPoint2Dで衝突した場所の座標を取得
            {
                hitPos = point.point;
            }

            Tilemap tilemap = other.gameObject.GetComponent<Tilemap>();
            if (tilemap != null)
            {
                // 衝突位置をタイル座標に変換
                Vector3Int tilePos = tilemap.WorldToCell(hitPos);

                // タイルが存在するか確認し、削除
                if (tilemap.GetTile(tilePos) != null)
                {
                    tilemap.SetTile(tilePos, null);
                }
            }
        }
}
