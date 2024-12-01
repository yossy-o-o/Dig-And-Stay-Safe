using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//StartScene�̃J�����ň��̈ʒu����������X�N���v�g
public class StartSceneCamera : MonoBehaviour
{
    /*�H��
    1. �J�������擾����
    2. �J������x���W���擾����
    3. �ړ����鑬�x���擾����
    4. �J�����𓮂��������͈͂̍ŏ��ƍő�̈���W���擾����(�ŏ��A�ő���W��GameObject��u��)
    5. �ړ�����
    6. �ő���W�܂ňړ�������A�ŏ����W�܂ŏ��X�Ɉړ�����
    7. �ŏ����W�܂ňړ�������A�ő���W�܂ŏ��X�Ɉړ�����
    8. �J��Ԃ�
    */

    public Camera mainCamera; //���C���J�����̕ϐ�

    public Transform minPoint; //�ŏ����W��\���I�u�W�F�N�g

    public Transform maxPoint; //�ő���W��\���I�u�W�F�N�g

    private Vector3 maxXCameraPosition; //�J�����̍ő�X���W

    private Vector3 minXCameraPosition; //�J�����̍ŏ�X���W

    public float cameraMoveSpeed = 0.1f; //�J�����̈ړ����x

    private bool movingToMax = true;//�ő�n�_�ƍŏ��n�_�̐؂�ւ�

    private float moveProgress = 0.0f; //�J�����̍ő�A�ŏ����W�ɐi�ސi�s�x



    public void Start()
    {
        maxXCameraPosition = maxPoint.position; //�ő�n�_���擾
        minXCameraPosition = minPoint.position; //�ŏ��n�_���擾
    }

    public void Update()
    {
        CameraSystem();
    }


    //Camera�̈ړ�����
    public void CameraSystem()
    {
        if (movingToMax)
        {
            //�ő���W�Ɍ�����
            moveProgress += cameraMoveSpeed * Time.deltaTime;
        }
        else
        {
            //�ŏ����W�Ɍ�����
            moveProgress -= cameraMoveSpeed * Time.deltaTime;
        }

        moveProgress = Mathf.Clamp01(moveProgress); //Clamp01���g�p���āA0~1�͈͓̔��Ɏ��߂�

        Vector3 newPosition = Vector3.Lerp(minXCameraPosition, maxXCameraPosition, moveProgress); //Lerp���g�p���āA���X�Ɉړ�

        mainCamera.transform.position = newPosition;

        //�����𔽓]
        changetransform();
    }


    //�������]�̏���
    void changetransform()
    {
        //�ő���W�ɒB������ŏ����W��
        if(moveProgress >= 1.0f)
        {
            movingToMax = false;
        }
        //�ŏ����W�ɒB������ő���W��
        else if(moveProgress <= 0.0f)
        {
            movingToMax = true;
        }
    }

}
