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
            
        }
        else if (SubSelectButton2.SubAttackCount == 2)
        {
           
        }
        else if (SubSelectButton2.SubAttackCount == 3)
        {
            
        }
        else if (SubSelectButton2.SubAttackCount == 4)
        {
            
        }
        else if (SubSelectButton2.SubAttackCount >= 5)
        {
            
        }
    }
}
