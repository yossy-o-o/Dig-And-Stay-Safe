using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player�̌��E���x
public class PlayerLimitPosition : MonoBehaviour
{
    public float maxYPlayerPosition;//Player��Y���E���x

    void Start()
    {
        
    }

    void Update()
    {
        LimitPosition();
    }


    public void LimitPosition()
    {
        Vector3 position = transform.position;//�v���C���[�̌��݈ʒu���擾

        if(position.y > maxYPlayerPosition)//����position.y��maxYPlayerPosition���傫��������
        {
            position.y = maxYPlayerPosition;//maxplayerposition��position.y�ɂ����
            transform.position = position;//���ݒn�����̏ꏊ�ɂ���
        }
    }
}
