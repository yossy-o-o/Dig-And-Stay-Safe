using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{

    [SerializeField] Tilemap fieldTilemap;//地面のタイルマップ
    Rigidbody2D rb;

    public float speed = 5.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
    
    }




    //自分のいるColliderとの当たり判定を取得
    void OnCollisionEnter2D(Collision2D other)
    {
        Vector3 hitPos = Vector3.zero; //座標の初期化

        foreach (ContactPoint2D point in other.contacts)//ContactPoint2Dで衝突した場所の座標を取得
        {
            hitPos = point.point;
        }


        //衝突した相手のTilemapと、位置(X,Y,Z)を取得
        BoundsInt.PositionEnumerator potiosion = other.gameObject.GetComponent<Tilemap>().cellBounds.allPositionsWithin;


    //タイルがなかったらの処理

        //座標を保存するためのリスト作成
        var allPosition = new List<Vector3>();

        int minPositionNum = 0; //一番近い場所を保存

        //BoundsIntで取得したpositionをvariableに代入
        foreach (var variable in potiosion)
        {
            //otherのTilemapを取得して、GetTile(variable)でタイルがあるか確認、なかったらnull
            if (other.gameObject.GetComponent<Tilemap>().GetTile(variable) != null)
            {
                //さっきの座標を保存するリストに、タイルがある場合、その座標を追加する
                allPosition.Add(variable);
            }
        }

    //最も近い位置をを探す
        //ここ分からないから復習必須
        for (int i = 1; i < allPosition.Count; i++)
        {
            //最初にhitPos - allPosition[i]).magnitudeで現在の座標の差分を出して、それがhitPos - allPosition[minPositionNum]).magnitude
            //より小さかったら、一番近い座標を更新する
            if ((hitPos - allPosition[i]).magnitude < (hitPos - allPosition[minPositionNum]).magnitude)
            {
                minPositionNum = i;
            }
        }


        //座標を一旦わかりやすく格納するために、finalPositionに入れとく
        Vector3Int finalPosition = Vector3Int.RoundToInt(allPosition[minPositionNum]);


        TileBase tiletmp = other.gameObject.GetComponent<Tilemap>().GetTile(finalPosition);


        if (tiletmp != null)
        {
            Tilemap map = other.gameObject.GetComponent<Tilemap>();
            TilemapCollider2D tileCol = other.gameObject.GetComponent<TilemapCollider2D>();

            map.SetTile(finalPosition, null);
            tileCol.enabled = false;
            tileCol.enabled = true;
        }

    }


    
}
