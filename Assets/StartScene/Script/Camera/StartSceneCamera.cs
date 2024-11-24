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
    4. �J�����𓮂��������͈͂̍ŏ��ƍő�̈���W���擾����
    5. �ړ�����
    6. �ő���W�܂ňړ�������A�ŏ����W�܂ŏ��X�Ɉړ�����
    7. �ŏ����W�܂ňړ�������A�ő���W�܂ŏ��X�Ɉړ�����
    8. �J��Ԃ�
    9.
    */

    public Camera mainCamera; //���C���J�����̕ϐ�

    public float mainCameraTranceform; //���C���J�����̍��W�ϐ�

    private float maxXCameraPosition; //�J�����̍ő�X���W

    private float minXCameraPosition; //�J�����̍ŏ�X���W

    public float speed = 5.0f; //�J�����̈ړ����x

    public void CameraSystem()
    {
        Vector3 currentPosition = mainCamera.transform.position; //���݂̃J�����̈ʒu���擾

        mainCameraTranceform = mainCamera.transform.position.x; //�J������x���W���擾

        mainCameraTranceform = Mathf.Clamp(transform.position.x, minXCameraPosition, maxXCameraPosition);//�����������ŏ��ƍő���擾

        Vector3 minXCameraPosition = new Vector3();

        Vector3 maxXCameraPosition = new Vector3();

        Vector3 newPosition = Vector3.Lerp(minXCameraPosition, maxXCameraPosition, speed * Time.deltaTime);

        mainCamera.transform.position = newPosition;
    }
    

}
