using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//tile�𔭎˂���N���X
public class Tile : MonoBehaviour
{
   // public GameObject TilePrefab;
    Rigidbody2D rb;

    public float limitAngle = 40;//���˂�����E�p�x

    public List<GameObject> tileList = new List<GameObject>();//�^�C����List�̒��ɓ����

    public float intervel = 1.0f; 
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("shoot", 0, 1);//0�b���1�b�Ԋu
        StartCoroutine(shoot());//�R���[�`����shoot�𐧌�
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    //�R���[�`���Ŏ��Ԑ�����s��shoot
    IEnumerator shoot()
    {
        foreach(GameObject gameobject in tileList)//List�̓��e���擾����
        {
            //GameObject���Q�Ƃ��邽�߂ɁAnewObject������āAInstatiate�ŕ���(�����������,�ʒu,��΂�����)
            GameObject newObject = Instantiate(gameobject,transform.position, Quaternion.identity);

            //rigidbody2D��GetComponent����
            rb = newObject.GetComponent<Rigidbody2D>();

            //rigidbody�ɗ͂������������߁AaddFoece���A�����ɗ͂��������������A�͂̋���
            rb.AddForce(-transform.up * 500);

            //�j��b��
            Destroy(gameObject, 3.0f);
        }

        //�R���[�`�����g�p�����ꍇ�Ayield���g�p����K�v������AWaitForSecond�͉��b��ɂ��ĈӖ�
        yield return new WaitForSeconds(intervel);
        

        
    }

}
