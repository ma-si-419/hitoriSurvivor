using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubSelectButton1 : MonoBehaviour
{
    
    //����I���{�^���̒ǉ�
    public GameObject SelectButton1;
    public GameObject SelectButton2;
    public GameObject PlayerLevelUP;
    //�C���[�W�̒ǉ�
    public GameObject image;
    public GameObject SubAttack1;
    public static int SubAttackCount = 0;

    public void OnClick()
    {
        //�G�̓�����߂�
        EnemyController.EnemyMove = 100;
        ToughEnemyController.ToughEnemyMove = 150;
        FastEnemyController.FastEnemyMove = 1;
        BossController.BossStop = 1;
        //�C���[�W�̔�\��
        image.SetActive(false);
        //�{�^���̔�\��
        SelectButton1.SetActive(false);
        SelectButton2.SetActive(false);
        PlayerLevelUP.SetActive(false);

        //�|�[�Y����������
        Time.timeScale = 1;
        SubAttackCount++;
    }
}
