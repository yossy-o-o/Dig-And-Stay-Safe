using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;
using UnityEngine.UIElements;

public class DeleteTileMap : MonoBehaviour
{
    Rigidbody2D rb;
    public ScoreSystem scoreSystem;
    public ParticleSystem particleSystem;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        particleSystem = GetComponentInChildren<ParticleSystem>();

        if(scoreSystem == null)
        {
            scoreSystem = FindObjectOfType<ScoreSystem>();
        }
    }

    //自分のいるColliderとの当たり判定を取得
    void OnCollisionEnter2D(Collision2D other)
    {
        Vector3 hitPos = Vector3.zero; //座標の初期化

        foreach (ContactPoint2D point in other.contacts)//ContactPoint2Dで接触点の座標を取得
        {
            hitPos = point.point;
        }


        //BoundsInt.PositionEnumeratorですべての座標を列挙し、hitPosに最も近い、タイルの座標をとってくる
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

        //otherについてるtilemapを取得して、finalPositonの位置にあるタイルを取得、無かった場合はnull
        TileBase tiletmp = other.gameObject.GetComponent<Tilemap>().GetTile(finalPosition);


        //その位置にタイルが存在する場合
        if (tiletmp != null)
        {
            //TilemapとtilmaoCollider2Dを取得する
            Tilemap map = other.gameObject.GetComponent<Tilemap>();
            TilemapCollider2D tileCollider = other.gameObject.GetComponent<TilemapCollider2D>();

            //Settileを使って、Tileを削除する、finalPositionで座標を、nullで削除
            map.SetTile(finalPosition, null);
            tileCollider.enabled = false;
            tileCollider.enabled = true;

            PlayPartical(hitPos);
            

            //ScoreSysytemの呼び出し
            scoreSystem.addScore(100);
            scoreSystem.UpdateHighScore();

        }
    }

    public void PlayPartical(Vector3 particalPosition)
    {
        if(particleSystem != null)
        {
            particleSystem.transform.position = particalPosition;
            particleSystem.Play();
        }
        else
        {
            Debug.Log("particalSysytem is not assigned");
        }
    }
}