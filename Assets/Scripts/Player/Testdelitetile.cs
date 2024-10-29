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



    // �����̂���Collider�Ƃ̓����蔻����擾
    void OnCollisionEnter2D(Collision2D other)
    {
            Vector3 hitPos = Vector3.zero; // ���W�̏�����

            foreach (ContactPoint2D point in other.contacts) // ContactPoint2D�ŏՓ˂����ꏊ�̍��W���擾
            {
                hitPos = point.point;
            }

            Tilemap tilemap = other.gameObject.GetComponent<Tilemap>();
            if (tilemap != null)
            {
                // �Փˈʒu���^�C�����W�ɕϊ�
                Vector3Int tilePos = tilemap.WorldToCell(hitPos);

                // �^�C�������݂��邩�m�F���A�폜
                if (tilemap.GetTile(tilePos) != null)
                {
                    tilemap.SetTile(tilePos, null);
                }
            }
        }
}
