using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubSelectButton1 : MonoBehaviour
{
    SubAttack SubAttack;
    //����I���{�^���̒ǉ�
    public GameObject SelectButton1;
    public GameObject SelectButton2;
    //�C���[�W�̒ǉ�
    public GameObject image;
    public GameObject SubAttack1;
    public static int SubAttackCount = 0;

    public void OnClick()
    {
        //�G�̓�����߂�
        EnemyController.EnemyMove = 100;
        //�C���[�W�̔�\��
        image.SetActive(false);
        //�{�^���̔�\��
        SelectButton1.SetActive(false);
        SelectButton2.SetActive(false);
        //�|�[�Y����������
        Time.timeScale = 1;
        SubAttackCount++;
    }
}
