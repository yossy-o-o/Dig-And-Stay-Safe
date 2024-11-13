using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//tile�𔭎˂���N���X
public class Tile : MonoBehaviour
{
   // public GameObject TilePrefab;
    Rigidbody2D rb;

    public float minAngle = 170f;//���˂�����E�p�x

    public float maxAngle = 190f;//���˂���ő�z�x

    public List<GameObject> tileList = new List<GameObject>();//�^�C����List�̒��ɓ����

    public float intervel = 1.0f; //�R���[�`���̕b��


    void Start()
    {
        StartCoroutine(shoot());//�R���[�`����shoot�𐧌�
    }

    void Update()
    {
        
    }

    //�����_���ȕ���(limitAngle)�ɔ��˂���֐�
    public Vector2 RandomDirection()
    {
        //randomaAngle��limitangle������ARandomRange�ł���������_���ɔ���
        float randomAngle = Random.Range(minAngle, maxAngle);

        //sin��cos�̊p�x�����߂Ă���BDeg2Rad�Ŋp�x�����W�A���ɕϊ����Ă���B�ϊ����R��Unity�����W�A�����g�p���Ă邽��
        float xDirection = Mathf.Cos(randomAngle * Mathf.Deg2Rad);
        float yDirectiom = Mathf.Sin(randomAngle * Mathf.Deg2Rad);
        
        //���\�b�h�̖߂�l�̌^��Vector2�Ȃ̂ŁAreturn�Ŋp�x��Ԃ�
        return new Vector2(xDirection, yDirectiom);
    }



    //�R���[�`���Ŏ��Ԑ�����s��shoot
    IEnumerator shoot()
    {
        while (true)
        {
            foreach (GameObject gameobject in tileList)//List�̓��e���擾����
            {
                //GameObject���Q�Ƃ��邽�߂ɁAnewObject������āAInstatiate�ŕ���(�����������,�ʒu,��΂�����)
                GameObject newObject = Instantiate(gameobject, transform.position, Quaternion.identity);

                //rigidbody2D��GetComponent����
                rb = newObject.GetComponent<Rigidbody2D>();

                //rigidbody2D�������Ă�����
                if(rb != null)
                {
                    //rigidbody�ɗ͂������������߁AaddFoece���A�����ɗ͂�������������(���񂪃����_�����\�b�h)�A�͂̋���
                    rb.AddForce(RandomDirection() * 500);
                }

                //�R���[�`�����g�p�����ꍇ�Ayield���g�p����K�v������AWaitForSecond�͉��b��ɂ��ĈӖ�
                yield return new WaitForSeconds(intervel);
            }
        }
    }
}
