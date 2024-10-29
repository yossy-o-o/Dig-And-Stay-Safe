using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//tileを発射するクラス
public class Tile : MonoBehaviour
{
   // public GameObject TilePrefab;
    Rigidbody2D rb;

    public float limitAngle = 40;//発射する限界角度

    public List<GameObject> tileList = new List<GameObject>();//タイルをListの中に入れる

    public float intervel = 1.0f; 
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("shoot", 0, 1);//0秒後に1秒間隔
        StartCoroutine(shoot());//コルーチンでshootを制御
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    //コルーチンで時間制御を行うshoot
    IEnumerator shoot()
    {
        foreach(GameObject gameobject in tileList)//Listの内容を取得して
        {
            //GameObjectを参照するために、newObjectを作って、Instatiateで複製(複製するもの,位置,飛ばす方向)
            GameObject newObject = Instantiate(gameobject,transform.position, Quaternion.identity);

            //rigidbody2DをGetComponentする
            rb = newObject.GetComponent<Rigidbody2D>();

            //rigidbodyに力を加えたいため、addFoeceし、引数に力を加えたい方向、力の強さ
            rb.AddForce(-transform.up * 500);

            //破壊秒数
            Destroy(gameObject, 3.0f);
        }

        //コルーチンを使用した場合、yieldを使用する必要がある、WaitForSecondは何秒後にって意味
        yield return new WaitForSeconds(intervel);
        

        
    }

}
