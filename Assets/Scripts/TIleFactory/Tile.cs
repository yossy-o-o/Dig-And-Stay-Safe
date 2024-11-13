using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//tileを発射するクラス
public class Tile : MonoBehaviour
{
   // public GameObject TilePrefab;
    Rigidbody2D rb;

    public float minAngle = 170f;//発射する限界角度

    public float maxAngle = 190f;//発射する最大額度

    public List<GameObject> tileList = new List<GameObject>();//タイルをListの中に入れる

    public float intervel = 1.0f; //コルーチンの秒間


    void Start()
    {
        StartCoroutine(shoot());//コルーチンでshootを制御
    }

    void Update()
    {
        
    }

    //ランダムな方向(limitAngle)に発射する関数
    public Vector2 RandomDirection()
    {
        //randomaAngleにlimitangleを入れる、RandomRangeでそれをランダムに発射
        float randomAngle = Random.Range(minAngle, maxAngle);

        //sinとcosの角度を求めている。Deg2Radで角度をラジアンに変換している。変換理由はUnityがラジアンを使用してるため
        float xDirection = Mathf.Cos(randomAngle * Mathf.Deg2Rad);
        float yDirectiom = Mathf.Sin(randomAngle * Mathf.Deg2Rad);
        
        //メソッドの戻り値の型がVector2なので、returnで角度を返す
        return new Vector2(xDirection, yDirectiom);
    }



    //コルーチンで時間制御を行うshoot
    IEnumerator shoot()
    {
        while (true)
        {
            foreach (GameObject gameobject in tileList)//Listの内容を取得して
            {
                //GameObjectを参照するために、newObjectを作って、Instatiateで複製(複製するもの,位置,飛ばす方向)
                GameObject newObject = Instantiate(gameobject, transform.position, Quaternion.identity);

                //rigidbody2DをGetComponentする
                rb = newObject.GetComponent<Rigidbody2D>();

                //rigidbody2Dが入っていたら
                if(rb != null)
                {
                    //rigidbodyに力を加えたいため、addFoeceし、引数に力を加えたい方向(今回がランダムメソッド)、力の強さ
                    rb.AddForce(RandomDirection() * 500);
                }

                //コルーチンを使用した場合、yieldを使用する必要がある、WaitForSecondは何秒後にって意味
                yield return new WaitForSeconds(intervel);
            }
        }
    }
}
