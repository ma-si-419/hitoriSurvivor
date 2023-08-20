using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour
{
    //����I���{�^���̒ǉ�
    public GameObject SelectButton1;
    public GameObject SelectButton2;
    public GameObject SelectButton;
    //�C���[�W�̒ǉ�
    public GameObject image;
    public static int PlayerLevelCount = 0;
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
        SelectButton.SetActive(false);
        //�|�[�Y����������
        Time.timeScale = 1;
        PlayerLevelCount++;
    }

    
    void FixedUpdate()
    {        
        if (SubSelectButton2.SubAttackCount == 1)
        {
            charcontroll.playerspeed = 30;
        }
        else if (SubSelectButton2.SubAttackCount == 2)
        {
            charcontroll.playerspeed = 35;
        }
        else if (SubSelectButton2.SubAttackCount == 3)
        {
            charcontroll.playerspeed = 40;
        }
        else if (SubSelectButton2.SubAttackCount == 4)
        {
            charcontroll.playerspeed = 45;
        }
        else if (SubSelectButton2.SubAttackCount >= 5)
        {
            charcontroll.playerspeed = 50;
        }
    }
}
